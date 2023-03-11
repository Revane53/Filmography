namespace Filmographys.View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Film_ListBox = new System.Windows.Forms.ListBox();
            this.Show_FilmCard_Button = new System.Windows.Forms.Button();
            this.Add_Film_Button = new System.Windows.Forms.Button();
            this.Add_Info_Button = new System.Windows.Forms.Button();
            this.Filtr_ComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Asc_RadioButton = new System.Windows.Forms.RadioButton();
            this.Desc_RadioButton = new System.Windows.Forms.RadioButton();
            this.Sort_Button = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.Genre_ComboBox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_1 = new System.Windows.Forms.DateTimePicker();
            this.Search_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Reset_Button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker_2 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(686, 425);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Пользователь";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Film_ListBox
            // 
            this.Film_ListBox.FormattingEnabled = true;
            this.Film_ListBox.ItemHeight = 16;
            this.Film_ListBox.Location = new System.Drawing.Point(13, 13);
            this.Film_ListBox.Name = "Film_ListBox";
            this.Film_ListBox.Size = new System.Drawing.Size(246, 420);
            this.Film_ListBox.TabIndex = 1;
            // 
            // Show_FilmCard_Button
            // 
            this.Show_FilmCard_Button.Location = new System.Drawing.Point(632, 13);
            this.Show_FilmCard_Button.Name = "Show_FilmCard_Button";
            this.Show_FilmCard_Button.Size = new System.Drawing.Size(156, 48);
            this.Show_FilmCard_Button.TabIndex = 2;
            this.Show_FilmCard_Button.Text = "Просмотр карточки фильма";
            this.Show_FilmCard_Button.UseVisualStyleBackColor = true;
            this.Show_FilmCard_Button.Click += new System.EventHandler(this.Show_FilmCard_Button_Click);
            // 
            // Add_Film_Button
            // 
            this.Add_Film_Button.Location = new System.Drawing.Point(632, 79);
            this.Add_Film_Button.Name = "Add_Film_Button";
            this.Add_Film_Button.Size = new System.Drawing.Size(156, 48);
            this.Add_Film_Button.TabIndex = 3;
            this.Add_Film_Button.Text = "Добавление фильма";
            this.Add_Film_Button.UseVisualStyleBackColor = true;
            this.Add_Film_Button.Click += new System.EventHandler(this.Add_Film_Button_Click);
            // 
            // Add_Info_Button
            // 
            this.Add_Info_Button.Location = new System.Drawing.Point(632, 151);
            this.Add_Info_Button.Name = "Add_Info_Button";
            this.Add_Info_Button.Size = new System.Drawing.Size(156, 65);
            this.Add_Info_Button.TabIndex = 4;
            this.Add_Info_Button.Text = "Добавление справочной информации";
            this.Add_Info_Button.UseVisualStyleBackColor = true;
            this.Add_Info_Button.Click += new System.EventHandler(this.Add_Info_Button_Click);
            // 
            // Filtr_ComboBox
            // 
            this.Filtr_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Filtr_ComboBox.FormattingEnabled = true;
            this.Filtr_ComboBox.Items.AddRange(new object[] {
            "Год выпуска",
            "Алфовитный порядок",
            "Стоимость"});
            this.Filtr_ComboBox.Location = new System.Drawing.Point(280, 36);
            this.Filtr_ComboBox.Name = "Filtr_ComboBox";
            this.Filtr_ComboBox.Size = new System.Drawing.Size(193, 24);
            this.Filtr_ComboBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(280, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Сортировать по:";
            // 
            // Asc_RadioButton
            // 
            this.Asc_RadioButton.AutoSize = true;
            this.Asc_RadioButton.Location = new System.Drawing.Point(280, 67);
            this.Asc_RadioButton.Name = "Asc_RadioButton";
            this.Asc_RadioButton.Size = new System.Drawing.Size(137, 20);
            this.Asc_RadioButton.TabIndex = 7;
            this.Asc_RadioButton.TabStop = true;
            this.Asc_RadioButton.Text = "По возрастанию";
            this.Asc_RadioButton.UseVisualStyleBackColor = true;
            // 
            // Desc_RadioButton
            // 
            this.Desc_RadioButton.AutoSize = true;
            this.Desc_RadioButton.Location = new System.Drawing.Point(280, 94);
            this.Desc_RadioButton.Name = "Desc_RadioButton";
            this.Desc_RadioButton.Size = new System.Drawing.Size(116, 20);
            this.Desc_RadioButton.TabIndex = 8;
            this.Desc_RadioButton.TabStop = true;
            this.Desc_RadioButton.Text = "По убыванию";
            this.Desc_RadioButton.UseVisualStyleBackColor = true;
            // 
            // Sort_Button
            // 
            this.Sort_Button.Location = new System.Drawing.Point(280, 121);
            this.Sort_Button.Name = "Sort_Button";
            this.Sort_Button.Size = new System.Drawing.Size(193, 39);
            this.Sort_Button.TabIndex = 9;
            this.Sort_Button.Text = "Применить";
            this.Sort_Button.UseVisualStyleBackColor = true;
            this.Sort_Button.Click += new System.EventHandler(this.Sort_Button_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(307, 214);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(93, 22);
            this.numericUpDown1.TabIndex = 10;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(451, 210);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(107, 22);
            this.numericUpDown2.TabIndex = 11;
            // 
            // Genre_ComboBox
            // 
            this.Genre_ComboBox.FormattingEnabled = true;
            this.Genre_ComboBox.Location = new System.Drawing.Point(339, 250);
            this.Genre_ComboBox.Name = "Genre_ComboBox";
            this.Genre_ComboBox.Size = new System.Drawing.Size(198, 24);
            this.Genre_ComboBox.TabIndex = 12;
            // 
            // dateTimePicker_1
            // 
            this.dateTimePicker_1.Location = new System.Drawing.Point(328, 310);
            this.dateTimePicker_1.Name = "dateTimePicker_1";
            this.dateTimePicker_1.Size = new System.Drawing.Size(209, 22);
            this.dateTimePicker_1.TabIndex = 13;
            // 
            // Search_button
            // 
            this.Search_button.Location = new System.Drawing.Point(543, 245);
            this.Search_button.Name = "Search_button";
            this.Search_button.Size = new System.Drawing.Size(254, 48);
            this.Search_button.TabIndex = 14;
            this.Search_button.Text = "Найти";
            this.Search_button.UseVisualStyleBackColor = true;
            this.Search_button.Click += new System.EventHandler(this.Search_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Стоимость фильма:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "От";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(406, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "До";
            // 
            // Reset_Button
            // 
            this.Reset_Button.Location = new System.Drawing.Point(543, 299);
            this.Reset_Button.Name = "Reset_Button";
            this.Reset_Button.Size = new System.Drawing.Size(254, 48);
            this.Reset_Button.TabIndex = 18;
            this.Reset_Button.Text = "Сбросить";
            this.Reset_Button.UseVisualStyleBackColor = true;
            this.Reset_Button.Click += new System.EventHandler(this.Reset_Button_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(283, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Жанр";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(283, 288);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Дата выхода:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(283, 315);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "От";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(283, 357);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "До";
            // 
            // dateTimePicker_2
            // 
            this.dateTimePicker_2.Location = new System.Drawing.Point(328, 351);
            this.dateTimePicker_2.Name = "dateTimePicker_2";
            this.dateTimePicker_2.Size = new System.Drawing.Size(209, 22);
            this.dateTimePicker_2.TabIndex = 23;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePicker_2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Reset_Button);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Search_button);
            this.Controls.Add(this.dateTimePicker_1);
            this.Controls.Add(this.Genre_ComboBox);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.Sort_Button);
            this.Controls.Add(this.Desc_RadioButton);
            this.Controls.Add(this.Asc_RadioButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Filtr_ComboBox);
            this.Controls.Add(this.Add_Info_Button);
            this.Controls.Add(this.Add_Film_Button);
            this.Controls.Add(this.Show_FilmCard_Button);
            this.Controls.Add(this.Film_ListBox);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox Film_ListBox;
        private System.Windows.Forms.Button Show_FilmCard_Button;
        private System.Windows.Forms.Button Add_Film_Button;
        private System.Windows.Forms.Button Add_Info_Button;
        private System.Windows.Forms.ComboBox Filtr_ComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton Asc_RadioButton;
        private System.Windows.Forms.RadioButton Desc_RadioButton;
        private System.Windows.Forms.Button Sort_Button;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.ComboBox Genre_ComboBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker_1;
        private System.Windows.Forms.Button Search_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Reset_Button;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePicker_2;
    }
}