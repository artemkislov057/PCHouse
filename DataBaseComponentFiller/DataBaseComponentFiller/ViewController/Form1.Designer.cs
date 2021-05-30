
namespace DataBaseComponentFiller
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.componentsComboBox = new System.Windows.Forms.ComboBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.outputButton = new System.Windows.Forms.Button();
            this.deleteDataBase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // componentsComboBox
            // 
            this.componentsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.componentsComboBox.FormattingEnabled = true;
            this.componentsComboBox.Items.AddRange(new object[] {
            "Процессор",
            "Материнская плата",
            "Видеокарта",
            "Оперативная память",
            "Блок питания",
            "Охлаждение процессора",
            "Корпус",
            "Память (HDD/SSD)",
            "M2",
            "Охлаждение корпуса"});
            this.componentsComboBox.Location = new System.Drawing.Point(12, 12);
            this.componentsComboBox.Name = "componentsComboBox";
            this.componentsComboBox.Size = new System.Drawing.Size(236, 23);
            this.componentsComboBox.TabIndex = 0;
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(12, 41);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(236, 23);
            this.selectButton.TabIndex = 1;
            this.selectButton.Text = "Добавить";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(12, 70);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(236, 23);
            this.outputButton.TabIndex = 2;
            this.outputButton.Text = "Вывести представление базы";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.outputButton_Click);
            // 
            // deleteDataBase
            // 
            this.deleteDataBase.Location = new System.Drawing.Point(12, 99);
            this.deleteDataBase.Name = "deleteDataBase";
            this.deleteDataBase.Size = new System.Drawing.Size(231, 23);
            this.deleteDataBase.TabIndex = 3;
            this.deleteDataBase.Text = "Очистить БД";
            this.deleteDataBase.UseVisualStyleBackColor = true;
            this.deleteDataBase.Click += new System.EventHandler(this.deleteDataBase_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 130);
            this.Controls.Add(this.deleteDataBase);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.componentsComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Заполнение БД";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox componentsComboBox;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.Button deleteDataBase;
    }
}

