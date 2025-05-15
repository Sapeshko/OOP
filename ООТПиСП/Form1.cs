using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

using static ООТПиСП.VagEngines;

namespace ООТПиСП
{
    public partial class VagEngines : Form
    {
        private List<Engine> engines;
        private bool isGasPressed = false;
        private bool isDizPressed = false;
        private bool isFazPressed = false;
        private bool isNoFasPressed = false;
        private bool isTurboPressed = false;
        private bool isAtmoPressed = false;
        private bool isImagePressed = false;

        private string previousModelText = "";
        private string previousDisplacementText = "";
        private string previousPowerText = "";
        private string previousTorqueText = "";
        private string previousImagePathText = "";


        private System.Windows.Forms.TextBox[] textBoxes;

        private Dictionary<string, Type> engineTypes;

        private Stack<ActionHistory> _undoStack = new Stack<ActionHistory>();
        private Stack<ActionHistory> _redoStack = new Stack<ActionHistory>();

        Engine engineIndex;

        public VagEngines()
        {
            InitializeComponent();

            textBoxModel.Visible = false;
            textBoxDisplacement.Visible = false;
            textBoxPower.Visible = false;
            textBoxTorque.Visible = false;
            textBoxImagePath.Visible = false;
            buttonYes.Visible = false;
            buttonYes2.Visible = false;
            buttonNo.Visible = false;
            radioButtonAtmospheric.Visible = false;
            radioButtonDiesel.Visible = false;
            radioButtonGasoline.Visible = false;
            radioButtonIsFazeReg.Visible = false;
            radioButtonNoFazeReg.Visible = false;
            radioButtonTurbo.Visible = false;
            buttonImage.Visible = false;

            buttonUndo.Click += ButtonUndo_Click;
            this.Controls.Add(buttonUndo);

            buttonRedo.Click += ButtonRedo_Click;
            this.Controls.Add(buttonRedo);

            buttonSaveXml.Click += buttonSaveXml_Click;
            buttonLoadXml.Click += buttonLoadXml_Click;
            buttonSaveBin.Click += buttonSaveBin_Click;
            buttonLoadBin.Click += buttonLoadBin_Click;


            textBoxModel.MaxLength = 10;
            textBoxDisplacement.MaxLength = 4;
            textBoxPower.MaxLength = 4;
            textBoxTorque.MaxLength = 5;
            textBoxImagePath.MaxLength = 100;

            textBoxes = new System.Windows.Forms.TextBox[] { textBoxModel, textBoxDisplacement, textBoxPower, textBoxTorque, textBoxImagePath };

            this.KeyPreview = true;
            this.KeyDown += VagEngines_KeyDown;

            textBoxModel.TextChanged += TextBox_TextChanged;
            textBoxDisplacement.TextChanged += TextBox_TextChanged;
            textBoxPower.TextChanged += TextBox_TextChanged;
            textBoxTorque.TextChanged += TextBox_TextChanged;
            textBoxImagePath.TextChanged += TextBox_TextChanged;

            foreach (var textBox in textBoxes)
            {
                textBox.GotFocus += TextBox_GotFocus;

                textBox.ForeColor = Color.Gray;
            }

            engineTypes = new Dictionary<string, Type>
    {
        { "GasolineFazeReg", typeof(FazeRegul) },
        { "GasolineNoFazeReg", typeof(NoFazeRegul) },
        { "DieselTurbo", typeof(Turbo) },
        { "DieselAtmo", typeof(Atmo) }
    };

            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Выберите изображение";


            engines = new List<Engine>
            {
                new Engine_1Z(),
                new Engine_AFN(),
                new Engine_AAA(),
                new Engine_AXZ(),
                new Engine_AAB(),
                new Engine_AXQ()
            };

            foreach (var engine in engines)
            {
                listBoxEngines.Items.Add(engine.Model);
            }

            listBoxEngines.SelectedIndexChanged += ListBoxEngines_SelectedIndex;
        }

        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                // Сохраняем текущее значение перед редактированием
                textBox.Tag = textBox.Text;

                if (textBox.ForeColor == Color.Gray)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            }
        }


        private void TextBox_LostFocus2(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            string oldText = textBox.Tag as string ?? "";
            string newText = textBox.Text;

            // Если текст пуст, возвращаем в текстовое поле placeholder
            if (string.IsNullOrWhiteSpace(newText))
            {
                if (textBox == textBoxModel) newText = "Модель";
                else if (textBox == textBoxDisplacement) newText = "Объем";
                else if (textBox == textBoxPower) newText = "Мощность";
                else if (textBox == textBoxTorque) newText = "Крутящий момент";
                else if (textBox == textBoxImagePath) newText = "Путь к изображению";

                textBox.ForeColor = Color.Gray;
            }

            // Регистрация действия если текст изменился
            if (oldText != newText)
            {
                RegisterAction(
                    undoAction: () =>
                    {
                        textBox.Text = oldText;
                        if (string.IsNullOrWhiteSpace(oldText)) textBox.ForeColor = Color.Gray;
                        else textBox.ForeColor = Color.Black;
                    },
                    redoAction: () =>
                    {
                        textBox.Text = newText;
                        if (string.IsNullOrWhiteSpace(newText)) textBox.ForeColor = Color.Gray;
                        else textBox.ForeColor = Color.Black;
                    },
                    description: $"Изменение текста в {textBox.Name}"
                );
            }

            textBox.Tag = null;
        }



        private void ListBoxEngines_SelectedIndex(object sender, EventArgs e)
        {
            if (listBoxEngines.SelectedIndex != -1)
            {

                Engine selectedEngine = engines[listBoxEngines.SelectedIndex];

                richTextBoxInfo.Text = selectedEngine.ToString();

                if (!string.IsNullOrEmpty(selectedEngine.ImagePath))
                {
                    pictureBoxEngine.Image = System.Drawing.Image.FromFile(selectedEngine.ImagePath);
                }
                else
                {
                    pictureBoxEngine.Image = null; 
                }
            }
        }

        private void listBoxEngines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxEngines.SelectedIndex != -1)
            {
                Engine selectedEngine = engines[listBoxEngines.SelectedIndex];

                textBoxModel.Text = selectedEngine.Model;
                textBoxDisplacement.Text = selectedEngine.Displacement.ToString();
                textBoxPower.Text = selectedEngine.Power.ToString();
                textBoxTorque.Text = selectedEngine.Torque.ToString();
                textBoxImagePath.Text = selectedEngine.ImagePath;

                if (selectedEngine is GasolineEngine)
                {
                    radioButtonGasoline.Checked = true;
                }
                else
                {
                    radioButtonDiesel.Checked = true;
                }

                if (selectedEngine is Turbo)
                {
                    radioButtonTurbo.Checked = true;
                }
                else
                {
                    radioButtonAtmospheric.Checked = true;
                }

                if (selectedEngine is FazeRegul)
                {
                    radioButtonIsFazeReg.Checked = true;
                }
                else
                {
                    radioButtonNoFazeReg.Checked = true;
                }
            }
        }

        private void UpdateEngineList()
        {
            listBoxEngines.Items.Clear();

            foreach (var engine in engines)
            {
                listBoxEngines.Items.Add(engine.Model);
            }
        }

        private void buttonAddEngine_Click(object sender, EventArgs e)
        {

            textBoxModel.Visible = true;
            textBoxDisplacement.Visible = true;
            textBoxPower.Visible = true;
            textBoxTorque.Visible = true;
            textBoxImagePath.Visible = true;
            buttonYes.Visible = true;
            buttonNo.Visible = true;
            radioButtonDiesel.Visible = true;
            radioButtonGasoline.Visible = true;
            buttonImage.Visible = true;

        }

        private void buttonEditEngine_Click(object sender, EventArgs e)
        {
            if (listBoxEngines.SelectedIndex != -1)
            {
                Engine selectedEngine = engines[listBoxEngines.SelectedIndex];
                engineIndex = engines[listBoxEngines.SelectedIndex];

                textBoxModel.Text = selectedEngine.Model;
                textBoxDisplacement.Text = selectedEngine.Displacement.ToString();
                textBoxPower.Text = selectedEngine.Power.ToString();
                textBoxTorque.Text = selectedEngine.Torque.ToString();
                textBoxImagePath.Text = selectedEngine.ImagePath ;

                textBoxModel.Visible = true;
                textBoxDisplacement.Visible = true;
                textBoxPower.Visible = true;
                textBoxTorque.Visible = true;
                textBoxImagePath.Visible = true;
                buttonYes2.Visible = true;
                buttonNo.Visible = true;
                radioButtonDiesel.Visible = true;
                radioButtonGasoline.Visible = true;
                buttonImage.Visible = true;
            }
        }

        private void buttonDeleteEngine_Click(object sender, EventArgs e)
        {
            if (listBoxEngines.SelectedIndex != -1)
            {
                Engine selectedEngine = engines[listBoxEngines.SelectedIndex];
                Engine selectedEngine2 = engines[listBoxEngines.SelectedIndex];

                RegisterAction(
                    undoAction: () => { engines.Add(selectedEngine2); UpdateEngineList(); },
                     redoAction: () => { engines.Remove(selectedEngine2); UpdateEngineList(); },
                    description: "Удаление двигателя");

                engines.Remove(selectedEngine); 
                UpdateEngineList(); 
            }
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBoxModel.Text) || string.IsNullOrEmpty(textBoxDisplacement.Text) || string.IsNullOrEmpty(textBoxPower.Text) || string.IsNullOrEmpty(textBoxTorque.Text) || string.IsNullOrWhiteSpace(textBoxImagePath.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены !", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (textBoxDisplacement.Text == "Объем" || textBoxPower.Text == "Мощность" || textBoxTorque.Text == "Крутящий момент")
            {
                MessageBox.Show("Все поля должны быть заполнены !", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string model = textBoxModel.Text;
            double displacement = double.Parse(textBoxDisplacement.Text);
            int power = int.Parse(textBoxPower.Text);
            int torque = int.Parse(textBoxTorque.Text);
            string imagePath = textBoxImagePath.Text;

            try
            {
                pictureBoxEngine.Image = System.Drawing.Image.FromFile(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось найти изображение по указанному пути: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string engineTypeKey = GetEngineTypeKey();
            if (engineTypes.ContainsKey(engineTypeKey))
            {
                Type engineType = engineTypes[engineTypeKey];
                Engine newEngine = EngineFactory.CreateEngine(engineTypeKey, model, displacement, power, torque, imagePath);


                Engine oldEngine = (Engine)Activator.CreateInstance(engineType, model, displacement, power, torque, imagePath);
                oldEngine = newEngine;

                RegisterAction(
                    undoAction: () => { engines.Remove(oldEngine); UpdateEngineList(); },
                    redoAction: () => { engines.Add(newEngine); UpdateEngineList(); },
                    description: "Добавление двигателя");

                engines.Remove(engineIndex);
                engines.Add(newEngine);

                UpdateEngineList();
            }
            else
            {
                MessageBox.Show("Не удалось определить тип двигателя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            HideControls();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            HideControls();
        }

        private void radioButtonGasoline_CheckedChanged(object sender, EventArgs e)
        {
            isDizPressed = false;
            isGasPressed = true;
            radioButtonAtmospheric.Visible = false;
            radioButtonTurbo.Visible = false;
            radioButtonIsFazeReg.Visible = true;
            radioButtonNoFazeReg.Visible = true;
        }

        private void radioButtonDiesel_CheckedChanged(object sender, EventArgs e)
        {
            isGasPressed = false;
            isDizPressed = true;
            radioButtonIsFazeReg.Visible = false;
            radioButtonNoFazeReg.Visible = false;
            radioButtonAtmospheric.Visible = true;
            radioButtonTurbo.Visible = true;
        }

        private void radioButtonTurbo_CheckedChanged(object sender, EventArgs e)
        {
            isAtmoPressed = false;
            isTurboPressed = true;
        }

        private void radioButtonAtmospheric_CheckedChanged(object sender, EventArgs e)
        {
            isTurboPressed = false;
            isAtmoPressed = true;
        }

        private void radioButtonIsFazeReg_CheckedChanged(object sender, EventArgs e)
        {
            isNoFasPressed = false;
            isFazPressed = true;
        }

        private void radioButtonNoFazeReg_CheckedChanged(object sender, EventArgs e)
        {
            isFazPressed = false;
            isNoFasPressed = true;
        }

        private void buttonYes2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxModel.Text) || string.IsNullOrEmpty(textBoxDisplacement.Text) || string.IsNullOrEmpty(textBoxPower.Text) || string.IsNullOrEmpty(textBoxTorque.Text) || string.IsNullOrWhiteSpace(textBoxImagePath.Text))
            {
                MessageBox.Show("Все поля должны быть заполнены !", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (textBoxDisplacement.Text == "Объем" || textBoxPower.Text == "Мощность" || textBoxTorque.Text == "Крутящий момент")
            {
                MessageBox.Show("Все поля должны быть заполнены !", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string model = textBoxModel.Text;
            double displacement = double.Parse(textBoxDisplacement.Text);
            int power = int.Parse(textBoxPower.Text);
            int torque = int.Parse(textBoxTorque.Text);
            string imagePath = textBoxImagePath.Text;

            try
            {
                pictureBoxEngine.Image = System.Drawing.Image.FromFile(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось найти изображение по указанному пути: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string engineTypeKey = GetEngineTypeKey();
            if (engineTypes.ContainsKey(engineTypeKey))
            {

                Type engineType = engineTypes[engineTypeKey];
                Engine newEngine = EngineFactory.CreateEngine(engineTypeKey, model, displacement, power, torque, imagePath);



                Engine oldEngine = (Engine)Activator.CreateInstance(engineType, model, displacement, power, torque, imagePath);
                oldEngine = newEngine;

                RegisterAction(
                    undoAction: () => { engines.Remove(oldEngine); UpdateEngineList(); },
                    redoAction: () => { engines.Add(newEngine); UpdateEngineList(); },
                    description: "Добавление двигателя");

                engines.Remove(engineIndex);

                engines.Add(newEngine);

                UpdateEngineList();
            }
            else
            {
                MessageBox.Show("Не удалось определить тип двигателя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            HideControls();
        }

        private void HideControls()
        {
            textBoxModel.Visible = false;
            textBoxDisplacement.Visible = false;
            textBoxPower.Visible = false;
            textBoxTorque.Visible = false;
            textBoxImagePath.Visible = false;
            buttonYes.Visible = false;
            buttonYes2.Visible = false;
            buttonNo.Visible = false;
            radioButtonAtmospheric.Visible = false;
            radioButtonDiesel.Visible = false;
            radioButtonGasoline.Visible = false;
            radioButtonIsFazeReg.Visible = false;
            radioButtonNoFazeReg.Visible = false;
            radioButtonTurbo.Visible = false;
            buttonImage.Visible = false;
        }

        private void buttonImage_Click(object sender, EventArgs e)
        {
            string imagePath = " ";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                imagePath = openFileDialog.FileName;

                try
                {
                    pictureBoxEngine.Image = System.Drawing.Image.FromFile(imagePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удалось загрузить изображение: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            textBoxImagePath.Text = imagePath ;

        }

        private string GetEngineTypeKey()
        {
            if (isGasPressed)
            {
                if (isFazPressed)
                {
                    return "GasolineFazeReg";
                }
                else
                {
                    return "GasolineNoFazeReg";
                }
            }
            else
            {
                if (isTurboPressed)
                {
                    return "DieselTurbo";
                }
                else
                {
                    return "DieselAtmo";
                }
            }
        }

        private void textBoxDisplacement_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as System.Windows.Forms.TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void textBoxPower_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxTorque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void VagEngines_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z && e.Control && !e.Shift && _undoStack.Count > 0)
            {
                var lastAction = _undoStack.Pop();
                lastAction.UndoAction();
                _redoStack.Push(lastAction);
            }

            if ((e.KeyCode == Keys.Z && e.Control && e.Shift ||
                 e.KeyCode == Keys.Y && e.Control) && _redoStack.Count > 0)
            {
                var lastRedoAction = _redoStack.Pop();
                lastRedoAction.RedoAction();
                _undoStack.Push(lastRedoAction);
            }
        }

        private void RegisterAction(Action undoAction, Action redoAction, string description)
        {
            _undoStack.Push(new ActionHistory
            {
                Description = description,
                UndoAction = undoAction,
                RedoAction = redoAction
            });
            _redoStack.Clear();
        }



        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null || !textBox.Focused) return;

            string currentText = textBox.Text;
            string previousText = textBox.Tag as string ?? "";

            if (currentText != previousText)
            {
                RegisterAction(
                    undoAction: () =>
                    {
                        textBox.Text = previousText;
                        textBox.Tag = previousText;
                    },
                    redoAction: () =>
                    {
                        textBox.Text = currentText;
                        textBox.Tag = currentText;
                    },
                    description: $"Изменение текста в {textBox.Name}"
                );
            }

            textBox.Tag = currentText;
        }




        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            if (_undoStack.Count > 0)
            {
                var lastAction = _undoStack.Pop();
                lastAction.UndoAction();
                _redoStack.Push(lastAction);
            }
        }

        private void ButtonRedo_Click(object sender, EventArgs e)
        {
            if (_redoStack.Count > 0)
            {
                var lastRedoAction = _redoStack.Pop();
                lastRedoAction.RedoAction();
                _undoStack.Push(lastRedoAction);
            }
        }

        private void SaveEnginesToXml(string filePath)
        {
            try
            {
                // Получаем все типы двигателей, которые могут встретиться
                Type[] extraTypes = new Type[]
                {
            typeof(FazeRegul),
            typeof(NoFazeRegul),
            typeof(Turbo),
            typeof(Atmo),
            typeof(Engine_1Z),
            typeof(Engine_AFN),
            typeof(Engine_AAA),
            typeof(Engine_AXZ),
            typeof(Engine_AAB),
            typeof(Engine_AXQ)
                };

                XmlSerializer serializer = new XmlSerializer(typeof(List<Engine>), extraTypes);

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    serializer.Serialize(fs, engines);
                }
                MessageBox.Show("Данные успешно сохранены в XML!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении XML: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEnginesFromXml(string filePath)
        {
            try
            {

                Type[] extraTypes = new Type[]
                {
                    typeof(FazeRegul),
                    typeof(NoFazeRegul),
                    typeof(Turbo),
                    typeof(Atmo),
                    typeof(Engine_1Z),
                    typeof(Engine_AFN),
                    typeof(Engine_AAA),
                    typeof(Engine_AXZ),
                    typeof(Engine_AAB),
                    typeof(Engine_AXQ)
                };

                XmlSerializer serializer = new XmlSerializer(typeof(List<Engine>), extraTypes);

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    engines = (List<Engine>)serializer.Deserialize(fs);
                    UpdateEngineList();

                    if (engines.Count > 0 && !string.IsNullOrEmpty(engines[0].ImagePath))
                    {
                        try
                        {
                            pictureBoxEngine.Image = Image.FromFile(engines[0].ImagePath);
                        }
                        catch
                        {
                            pictureBoxEngine.Image = null;
                        }
                    }
                }
                MessageBox.Show("Данные успешно загружены из XML!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке XML: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveEnginesToBinary(string filePath)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    formatter.Serialize(fs, engines);
                }

                MessageBox.Show("Данные успешно сохранены в бинарном формате!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEnginesFromBinary(string filePath)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple;
                formatter.Binder = new EngineSerializationBinder();

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    engines = (List<Engine>)formatter.Deserialize(fs);
                    UpdateEngineList();

                    if (engines.Count > 0 && !string.IsNullOrEmpty(engines[0].ImagePath))
                    {
                        try
                        {
                            pictureBoxEngine.Image = Image.FromFile(engines[0].ImagePath);
                        }
                        catch
                        {
                            pictureBoxEngine.Image = null;
                        }
                    }
                }

                MessageBox.Show("Данные успешно загружены из бинарного файла!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveXml_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "XML files (*.xml)|*.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SaveEnginesToXml(dialog.FileName);
            }
        }

        private void buttonLoadXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "XML files (*.xml)|*.xml";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadEnginesFromXml(dialog.FileName);
            }
        }

        private void buttonSaveBin_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Binary files (*.bin)|*.bin";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SaveEnginesToBinary(dialog.FileName);
            }
        }

        private void buttonLoadBin_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Binary files (*.bin)|*.bin";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                LoadEnginesFromBinary(dialog.FileName);
            }
        }


    }
    public class ActionHistory
    {
        public string Description { get; set; }
        public Action UndoAction { get; set; }
        public Action RedoAction { get; set; }  
    }
}