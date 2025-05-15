namespace ООТПиСП
{
    partial class VagEngines
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxEngines = new System.Windows.Forms.ListBox();
            this.richTextBoxInfo = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxEngine = new System.Windows.Forms.PictureBox();
            this.buttonAddEngine = new System.Windows.Forms.Button();
            this.buttonEditEngine = new System.Windows.Forms.Button();
            this.buttonDeleteEngine = new System.Windows.Forms.Button();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.textBoxDisplacement = new System.Windows.Forms.TextBox();
            this.textBoxPower = new System.Windows.Forms.TextBox();
            this.textBoxTorque = new System.Windows.Forms.TextBox();
            this.textBoxImagePath = new System.Windows.Forms.TextBox();
            this.radioButtonGasoline = new System.Windows.Forms.RadioButton();
            this.radioButtonDiesel = new System.Windows.Forms.RadioButton();
            this.radioButtonTurbo = new System.Windows.Forms.RadioButton();
            this.radioButtonAtmospheric = new System.Windows.Forms.RadioButton();
            this.radioButtonIsFazeReg = new System.Windows.Forms.RadioButton();
            this.radioButtonNoFazeReg = new System.Windows.Forms.RadioButton();
            this.buttonYes = new System.Windows.Forms.Button();
            this.buttonNo = new System.Windows.Forms.Button();
            this.buttonYes2 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonImage = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.buttonRedo = new System.Windows.Forms.Button();
            this.buttonSaveXml = new System.Windows.Forms.Button();
            this.buttonLoadXml = new System.Windows.Forms.Button();
            this.buttonSaveBin = new System.Windows.Forms.Button();
            this.buttonLoadBin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEngine)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxEngines
            // 
            this.listBoxEngines.FormattingEnabled = true;
            this.listBoxEngines.ItemHeight = 16;
            this.listBoxEngines.Location = new System.Drawing.Point(37, 39);
            this.listBoxEngines.Name = "listBoxEngines";
            this.listBoxEngines.Size = new System.Drawing.Size(142, 164);
            this.listBoxEngines.TabIndex = 0;
            // 
            // richTextBoxInfo
            // 
            this.richTextBoxInfo.Location = new System.Drawing.Point(185, 39);
            this.richTextBoxInfo.Name = "richTextBoxInfo";
            this.richTextBoxInfo.Size = new System.Drawing.Size(230, 163);
            this.richTextBoxInfo.TabIndex = 1;
            this.richTextBoxInfo.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "VagEngines";
            // 
            // pictureBoxEngine
            // 
            this.pictureBoxEngine.Location = new System.Drawing.Point(37, 208);
            this.pictureBoxEngine.Name = "pictureBoxEngine";
            this.pictureBoxEngine.Size = new System.Drawing.Size(751, 276);
            this.pictureBoxEngine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEngine.TabIndex = 3;
            this.pictureBoxEngine.TabStop = false;
            // 
            // buttonAddEngine
            // 
            this.buttonAddEngine.Location = new System.Drawing.Point(421, 39);
            this.buttonAddEngine.Name = "buttonAddEngine";
            this.buttonAddEngine.Size = new System.Drawing.Size(75, 23);
            this.buttonAddEngine.TabIndex = 4;
            this.buttonAddEngine.Text = "Добавить";
            this.buttonAddEngine.UseVisualStyleBackColor = true;
            this.buttonAddEngine.Click += new System.EventHandler(this.buttonAddEngine_Click);
            // 
            // buttonEditEngine
            // 
            this.buttonEditEngine.Location = new System.Drawing.Point(421, 69);
            this.buttonEditEngine.Name = "buttonEditEngine";
            this.buttonEditEngine.Size = new System.Drawing.Size(75, 23);
            this.buttonEditEngine.TabIndex = 5;
            this.buttonEditEngine.Text = "Изменить";
            this.buttonEditEngine.UseVisualStyleBackColor = true;
            this.buttonEditEngine.Click += new System.EventHandler(this.buttonEditEngine_Click);
            // 
            // buttonDeleteEngine
            // 
            this.buttonDeleteEngine.Location = new System.Drawing.Point(421, 99);
            this.buttonDeleteEngine.Name = "buttonDeleteEngine";
            this.buttonDeleteEngine.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteEngine.TabIndex = 6;
            this.buttonDeleteEngine.Text = "Удалить";
            this.buttonDeleteEngine.UseVisualStyleBackColor = true;
            this.buttonDeleteEngine.Click += new System.EventHandler(this.buttonDeleteEngine_Click);
            // 
            // textBoxModel
            // 
            this.textBoxModel.Location = new System.Drawing.Point(513, 39);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(100, 22);
            this.textBoxModel.TabIndex = 7;
            this.textBoxModel.TabStop = false;
            this.textBoxModel.Tag = "";
            this.textBoxModel.Text = "Модель";
            // 
            // textBoxDisplacement
            // 
            this.textBoxDisplacement.Location = new System.Drawing.Point(513, 69);
            this.textBoxDisplacement.Name = "textBoxDisplacement";
            this.textBoxDisplacement.Size = new System.Drawing.Size(100, 22);
            this.textBoxDisplacement.TabIndex = 8;
            this.textBoxDisplacement.Text = "Объем";
            this.textBoxDisplacement.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDisplacement_KeyPress);
            // 
            // textBoxPower
            // 
            this.textBoxPower.Location = new System.Drawing.Point(513, 99);
            this.textBoxPower.Name = "textBoxPower";
            this.textBoxPower.Size = new System.Drawing.Size(100, 22);
            this.textBoxPower.TabIndex = 9;
            this.textBoxPower.Text = "Мощность";
            this.textBoxPower.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPower_KeyPress);
            // 
            // textBoxTorque
            // 
            this.textBoxTorque.Location = new System.Drawing.Point(513, 128);
            this.textBoxTorque.Name = "textBoxTorque";
            this.textBoxTorque.Size = new System.Drawing.Size(100, 22);
            this.textBoxTorque.TabIndex = 10;
            this.textBoxTorque.Text = "Крутящий момент";
            this.textBoxTorque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTorque_KeyPress);
            // 
            // textBoxImagePath
            // 
            this.textBoxImagePath.Location = new System.Drawing.Point(513, 156);
            this.textBoxImagePath.Name = "textBoxImagePath";
            this.textBoxImagePath.Size = new System.Drawing.Size(100, 22);
            this.textBoxImagePath.TabIndex = 11;
            this.textBoxImagePath.Text = "Путь к изображению";
            // 
            // radioButtonGasoline
            // 
            this.radioButtonGasoline.AutoSize = true;
            this.radioButtonGasoline.Location = new System.Drawing.Point(641, 42);
            this.radioButtonGasoline.Name = "radioButtonGasoline";
            this.radioButtonGasoline.Size = new System.Drawing.Size(110, 20);
            this.radioButtonGasoline.TabIndex = 12;
            this.radioButtonGasoline.TabStop = true;
            this.radioButtonGasoline.Text = "Бензиновый";
            this.radioButtonGasoline.UseVisualStyleBackColor = true;
            this.radioButtonGasoline.CheckedChanged += new System.EventHandler(this.radioButtonGasoline_CheckedChanged);
            // 
            // radioButtonDiesel
            // 
            this.radioButtonDiesel.AutoSize = true;
            this.radioButtonDiesel.Location = new System.Drawing.Point(641, 70);
            this.radioButtonDiesel.Name = "radioButtonDiesel";
            this.radioButtonDiesel.Size = new System.Drawing.Size(101, 20);
            this.radioButtonDiesel.TabIndex = 13;
            this.radioButtonDiesel.TabStop = true;
            this.radioButtonDiesel.Text = "Дизельный";
            this.radioButtonDiesel.UseVisualStyleBackColor = true;
            this.radioButtonDiesel.CheckedChanged += new System.EventHandler(this.radioButtonDiesel_CheckedChanged);
            // 
            // radioButtonTurbo
            // 
            this.radioButtonTurbo.AutoSize = true;
            this.radioButtonTurbo.Location = new System.Drawing.Point(641, 99);
            this.radioButtonTurbo.Name = "radioButtonTurbo";
            this.radioButtonTurbo.Size = new System.Drawing.Size(117, 20);
            this.radioButtonTurbo.TabIndex = 14;
            this.radioButtonTurbo.TabStop = true;
            this.radioButtonTurbo.Text = "Турбонаддув";
            this.radioButtonTurbo.UseVisualStyleBackColor = true;
            this.radioButtonTurbo.CheckedChanged += new System.EventHandler(this.radioButtonTurbo_CheckedChanged);
            // 
            // radioButtonAtmospheric
            // 
            this.radioButtonAtmospheric.AutoSize = true;
            this.radioButtonAtmospheric.Location = new System.Drawing.Point(641, 128);
            this.radioButtonAtmospheric.Name = "radioButtonAtmospheric";
            this.radioButtonAtmospheric.Size = new System.Drawing.Size(120, 20);
            this.radioButtonAtmospheric.TabIndex = 15;
            this.radioButtonAtmospheric.TabStop = true;
            this.radioButtonAtmospheric.Text = "Атмосферный";
            this.radioButtonAtmospheric.UseVisualStyleBackColor = true;
            this.radioButtonAtmospheric.CheckedChanged += new System.EventHandler(this.radioButtonAtmospheric_CheckedChanged);
            // 
            // radioButtonIsFazeReg
            // 
            this.radioButtonIsFazeReg.AutoSize = true;
            this.radioButtonIsFazeReg.Location = new System.Drawing.Point(641, 130);
            this.radioButtonIsFazeReg.Name = "radioButtonIsFazeReg";
            this.radioButtonIsFazeReg.Size = new System.Drawing.Size(97, 20);
            this.radioButtonIsFazeReg.TabIndex = 16;
            this.radioButtonIsFazeReg.TabStop = true;
            this.radioButtonIsFazeReg.Text = "С фазарег";
            this.radioButtonIsFazeReg.UseVisualStyleBackColor = true;
            this.radioButtonIsFazeReg.CheckedChanged += new System.EventHandler(this.radioButtonIsFazeReg_CheckedChanged);
            // 
            // radioButtonNoFazeReg
            // 
            this.radioButtonNoFazeReg.AutoSize = true;
            this.radioButtonNoFazeReg.Location = new System.Drawing.Point(641, 101);
            this.radioButtonNoFazeReg.Name = "radioButtonNoFazeReg";
            this.radioButtonNoFazeReg.Size = new System.Drawing.Size(113, 20);
            this.radioButtonNoFazeReg.TabIndex = 17;
            this.radioButtonNoFazeReg.TabStop = true;
            this.radioButtonNoFazeReg.Text = "Без фазарег";
            this.radioButtonNoFazeReg.UseVisualStyleBackColor = true;
            this.radioButtonNoFazeReg.CheckedChanged += new System.EventHandler(this.radioButtonNoFazeReg_CheckedChanged);
            // 
            // buttonYes
            // 
            this.buttonYes.Location = new System.Drawing.Point(485, 185);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(68, 23);
            this.buttonYes.TabIndex = 18;
            this.buttonYes.Text = "ОК";
            this.buttonYes.UseVisualStyleBackColor = true;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // buttonNo
            // 
            this.buttonNo.Location = new System.Drawing.Point(559, 185);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(66, 23);
            this.buttonNo.TabIndex = 19;
            this.buttonNo.Text = "Отмена";
            this.buttonNo.UseVisualStyleBackColor = true;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // buttonYes2
            // 
            this.buttonYes2.Location = new System.Drawing.Point(485, 185);
            this.buttonYes2.Name = "buttonYes2";
            this.buttonYes2.Size = new System.Drawing.Size(68, 23);
            this.buttonYes2.TabIndex = 20;
            this.buttonYes2.Text = "ОК";
            this.buttonYes2.UseVisualStyleBackColor = true;
            this.buttonYes2.Click += new System.EventHandler(this.buttonYes2_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // buttonImage
            // 
            this.buttonImage.Location = new System.Drawing.Point(638, 156);
            this.buttonImage.Name = "buttonImage";
            this.buttonImage.Size = new System.Drawing.Size(100, 23);
            this.buttonImage.TabIndex = 21;
            this.buttonImage.Text = "Изображение";
            this.buttonImage.UseVisualStyleBackColor = true;
            this.buttonImage.Click += new System.EventHandler(this.buttonImage_Click);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Location = new System.Drawing.Point(421, 130);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(75, 23);
            this.buttonUndo.TabIndex = 22;
            this.buttonUndo.Text = "Undo";
            this.buttonUndo.UseVisualStyleBackColor = true;
            // 
            // buttonRedo
            // 
            this.buttonRedo.Location = new System.Drawing.Point(421, 159);
            this.buttonRedo.Name = "buttonRedo";
            this.buttonRedo.Size = new System.Drawing.Size(75, 23);
            this.buttonRedo.TabIndex = 23;
            this.buttonRedo.Text = "Redo";
            this.buttonRedo.UseVisualStyleBackColor = true;
            // 
            // buttonSaveXml
            // 
            this.buttonSaveXml.Location = new System.Drawing.Point(121, 4);
            this.buttonSaveXml.Name = "buttonSaveXml";
            this.buttonSaveXml.Size = new System.Drawing.Size(90, 27);
            this.buttonSaveXml.TabIndex = 24;
            this.buttonSaveXml.Text = "СохрXML";
            this.buttonSaveXml.UseVisualStyleBackColor = true;
            // 
            // buttonLoadXml
            // 
            this.buttonLoadXml.Location = new System.Drawing.Point(217, 4);
            this.buttonLoadXml.Name = "buttonLoadXml";
            this.buttonLoadXml.Size = new System.Drawing.Size(90, 27);
            this.buttonLoadXml.TabIndex = 25;
            this.buttonLoadXml.Text = "ОткрXML";
            this.buttonLoadXml.UseVisualStyleBackColor = true;
            // 
            // buttonSaveBin
            // 
            this.buttonSaveBin.Location = new System.Drawing.Point(313, 4);
            this.buttonSaveBin.Name = "buttonSaveBin";
            this.buttonSaveBin.Size = new System.Drawing.Size(90, 27);
            this.buttonSaveBin.TabIndex = 26;
            this.buttonSaveBin.Text = "СохрBIN";
            this.buttonSaveBin.UseVisualStyleBackColor = true;
            // 
            // buttonLoadBin
            // 
            this.buttonLoadBin.Location = new System.Drawing.Point(409, 4);
            this.buttonLoadBin.Name = "buttonLoadBin";
            this.buttonLoadBin.Size = new System.Drawing.Size(90, 27);
            this.buttonLoadBin.TabIndex = 27;
            this.buttonLoadBin.Text = "ОткрBIN";
            this.buttonLoadBin.UseVisualStyleBackColor = true;
            // 
            // VagEngines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 514);
            this.Controls.Add(this.buttonLoadBin);
            this.Controls.Add(this.buttonSaveBin);
            this.Controls.Add(this.buttonLoadXml);
            this.Controls.Add(this.buttonSaveXml);
            this.Controls.Add(this.buttonRedo);
            this.Controls.Add(this.buttonUndo);
            this.Controls.Add(this.buttonImage);
            this.Controls.Add(this.buttonYes2);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.radioButtonNoFazeReg);
            this.Controls.Add(this.radioButtonIsFazeReg);
            this.Controls.Add(this.radioButtonAtmospheric);
            this.Controls.Add(this.radioButtonTurbo);
            this.Controls.Add(this.radioButtonDiesel);
            this.Controls.Add(this.radioButtonGasoline);
            this.Controls.Add(this.textBoxImagePath);
            this.Controls.Add(this.textBoxTorque);
            this.Controls.Add(this.textBoxPower);
            this.Controls.Add(this.textBoxDisplacement);
            this.Controls.Add(this.textBoxModel);
            this.Controls.Add(this.buttonDeleteEngine);
            this.Controls.Add(this.buttonEditEngine);
            this.Controls.Add(this.buttonAddEngine);
            this.Controls.Add(this.pictureBoxEngine);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxInfo);
            this.Controls.Add(this.listBoxEngines);
            this.KeyPreview = true;
            this.Name = "VagEngines";
            this.Text = "VagEngines";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.VagEngines_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEngine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxEngines;
        private System.Windows.Forms.RichTextBox richTextBoxInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxEngine;
        private System.Windows.Forms.Button buttonAddEngine;
        private System.Windows.Forms.Button buttonEditEngine;
        private System.Windows.Forms.Button buttonDeleteEngine;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.TextBox textBoxDisplacement;
        private System.Windows.Forms.TextBox textBoxPower;
        private System.Windows.Forms.TextBox textBoxTorque;
        private System.Windows.Forms.TextBox textBoxImagePath;
        private System.Windows.Forms.RadioButton radioButtonGasoline;
        private System.Windows.Forms.RadioButton radioButtonDiesel;
        private System.Windows.Forms.RadioButton radioButtonTurbo;
        private System.Windows.Forms.RadioButton radioButtonAtmospheric;
        private System.Windows.Forms.RadioButton radioButtonIsFazeReg;
        private System.Windows.Forms.RadioButton radioButtonNoFazeReg;
        private System.Windows.Forms.Button buttonYes;
        private System.Windows.Forms.Button buttonNo;
        private System.Windows.Forms.Button buttonYes2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonImage;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Button buttonRedo;
        private System.Windows.Forms.Button buttonSaveXml;
        private System.Windows.Forms.Button buttonLoadXml;
        private System.Windows.Forms.Button buttonSaveBin;
        private System.Windows.Forms.Button buttonLoadBin;
    }
}

