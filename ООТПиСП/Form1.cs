using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        
        private System.Windows.Forms.TextBox[] textBoxes;

        private Dictionary<string, Type> engineTypes;

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

            textBoxes = new System.Windows.Forms.TextBox[] { textBoxModel, textBoxDisplacement, textBoxPower, textBoxTorque, textBoxImagePath }; // Добавьте сюда все ваши TextBox

            foreach (var textBox in textBoxes)
            {
                textBox.GotFocus += TextBox_GotFocus;
                textBox.LostFocus += TextBox_LostFocus;

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
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;
            if (textBox != null )
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black; 
            }
        }

        private void TextBox_LostFocus(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            { 
                textBox.ForeColor = Color.Gray;
            }
        }

        private void ListBoxEngines_SelectedIndex(object sender, EventArgs e)
        {
            if (listBoxEngines.SelectedIndex != -1)
            {

                Engine selectedEngine = engines[listBoxEngines.SelectedIndex];

                richTextBoxInfo.Text = selectedEngine.GetInfo();

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

                engines.Remove(selectedEngine);

                UpdateEngineList();
            }
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            string model = textBoxModel.Text;
            double displacement = double.Parse(textBoxDisplacement.Text);
            int power = int.Parse(textBoxPower.Text);
            int torque = int.Parse(textBoxTorque.Text);
            string imagePath = textBoxImagePath.Text;

            string engineTypeKey = GetEngineTypeKey();
            if (engineTypes.ContainsKey(engineTypeKey))
            {
                Type engineType = engineTypes[engineTypeKey];
                Engine newEngine = (Engine)Activator.CreateInstance(engineType, model, displacement, power, torque, imagePath);

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
            string model = textBoxModel.Text;
            double displacement = double.Parse(textBoxDisplacement.Text);
            int power = int.Parse(textBoxPower.Text);
            int torque = int.Parse(textBoxTorque.Text);
            string imagePath = textBoxImagePath.Text;

            string engineTypeKey = GetEngineTypeKey();
            if (engineTypes.ContainsKey(engineTypeKey))
            {

                Type engineType = engineTypes[engineTypeKey];
                Engine newEngine = (Engine)Activator.CreateInstance(engineType, model, displacement, power, torque, imagePath);

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

    }
}