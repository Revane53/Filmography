using Filmographys.Class;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace Filmographys.View
{
    public partial class MainForm : Form
    {
        String command;
        DataSet dataSet;
        Film_card_Form film_Card_Form;
        List<string> filtrs = new List<string>();

        public MainForm()
        {
            InitializeComponent();
            command = "select * from Films; select * from Genres;";
            dataSet = Connection.GetTables(command);
            Film_ListBox.DataSource = dataSet.Tables[0];
            Film_ListBox.DisplayMember = "film_name";
            Film_ListBox.ValueMember = "film_id";
            Add_Film_Button.Visible = false;
            Add_Info_Button.Visible = false;
            filtrs.Add("desc");
            filtrs.Add("asc");
            Genre_ComboBox.SelectedIndex = -1;
            Genre_ComboBox.DataSource = dataSet.Tables[1];
            Genre_ComboBox.DisplayMember = "genre_name";
            Genre_ComboBox.ValueMember = "genre_id";
            dateTimePicker_1.Value = dateTimePicker_1.MinDate;
            dateTimePicker_2.Value = dateTimePicker_2.MinDate;
            Genre_ComboBox.SelectedIndex = -1;
        }

        private void Show_FilmCard_Button_Click(object sender, EventArgs e)
        {
            if (Film_ListBox.SelectedIndex >= 0)
            {
                film_Card_Form = new Film_card_Form((int)Film_ListBox.SelectedValue);
                film_Card_Form.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (label1.Text == "Пользователь")
            {
                LoginForm loginForm = new LoginForm();
                if(loginForm.ShowDialog() == DialogResult.OK)
                {
                    label1.Text = "Администратор";
                    Add_Film_Button.Visible = true;
                    Add_Info_Button.Visible = true;
                }
            }
            else
            {
                label1.Text = "Пользователь";
                Add_Film_Button.Visible = false;
                Add_Info_Button.Visible = false;
            }
        }

        private void Add_Film_Button_Click(object sender, EventArgs e)
        {
            AddFilmsForm addFilmsForm = new AddFilmsForm();
            addFilmsForm.Show();
            Film_ListBox.Update();

        }

        private void Add_Info_Button_Click(object sender, EventArgs e)
        {
            MaintainingDirectoryForm maintainingDirectoryForm = new MaintainingDirectoryForm();
            maintainingDirectoryForm.Show();
        }

        private void Sort_Button_Click(object sender, EventArgs e)
        {
            if(Filtr_ComboBox.SelectedIndex >= 0)
            {
                DataTable dt = new DataTable();
                int i = Asc_RadioButton.Checked ?  i = 1 :  i = 0;
                string column_filtr = "";
                switch (Filtr_ComboBox.SelectedIndex)
                {
                    /*
                     Год выпуска
                     Алфовитный порядок
                     Стоимость
                    */
                    case 0:
                        column_filtr = "year_of_release";
                        break;
                    case 1:
                        column_filtr = "film_name";
                        break;
                    case 2:
                        column_filtr = "movie_budget";
                        break;
                }
                dataSet.Tables[0].DefaultView.Sort = $"{column_filtr} {filtrs[i]}";
                dt = dt.DefaultView.ToTable();
            }
        }

        private void Search_button_Click(object sender, EventArgs e)
        {
            string commands = "select * from Films where ";
            int length = commands.Length;
            if (Genre_ComboBox.SelectedIndex >= 0)
            {
                commands += "film_id in ( ";
                DataTable dt = Connection.GetTable($"Select * from Film_Genre where genre_id = {int.Parse(Genre_ComboBox.SelectedValue.ToString())}");
                var film_id = from c in dt.AsEnumerable()
                    select c.Field<int>("film_id");
                int temp = commands.Length;
                foreach (var item in film_id)
                {
                    if (commands.Length > temp)
                        commands += ", ";
                    commands += $"{ item.ToString()}";
                }
                commands += " )";
            }
            if (numericUpDown1.Value > 0 && numericUpDown2.Value > 0)
            {
                if (commands.Length > length)
                    commands += " and ";

                commands += $" film_id between {numericUpDown1.Value} and {numericUpDown2.Value}";
            } else if(numericUpDown1.Value > 0)
            {
                if (commands.Length > length)
                    commands += " and ";

                commands += $" film_id > {numericUpDown1.Value}";
            } else if (numericUpDown2.Value > 0)
            {
                if (commands.Length > length)
                    commands += " and ";

                commands += $" film_id < {numericUpDown2.Value}";
            }
            if (dateTimePicker_1.Value > dateTimePicker_1.MinDate && dateTimePicker_2.Value > dateTimePicker_2.MinDate)
            {
                if (commands.Length > length)
                    commands += " and ";

                string date = dateTimePicker_2.Value.ToString().Replace(".", "-");
                commands += $" year_of_release between {dateTimePicker_1.Value.ToString().Replace(".","-")} and {dateTimePicker_2.Value.ToString().Replace(".", "-")}";
            } else if (dateTimePicker_1.Value > dateTimePicker_1.MinDate)
            {
                if (commands.Length > length)
                    commands += " and ";

                string date = dateTimePicker_1.Value.ToString().Replace(".", "-");
                commands += $" year_of_release > '{date.Substring(0, date.IndexOf(' '))}'";
            } else if(dateTimePicker_2.Value > dateTimePicker_2.MinDate)
            {
                if (commands.Length > length)
                    commands += " and ";

                string date = dateTimePicker_2.Value.ToString().Replace(".", "-");
                commands += $" year_of_release < '{date.Substring(0,date.IndexOf(' '))}'";
            }
            if (commands.Length == length)
                return;
            commands += ";";
            dataSet = Connection.GetTables(commands);
            Film_ListBox.DataSource = dataSet.Tables[0];
            Film_ListBox.DisplayMember = "film_name";
            Film_ListBox.ValueMember = "film_id";

        }

        private void Reset_Button_Click(object sender, EventArgs e)
        {
            command = "select * from Films; select * from Genres;";
            dataSet = Connection.GetTables(command);
            Film_ListBox.DataSource = dataSet.Tables[0];
            Film_ListBox.DisplayMember = "film_name";
            Film_ListBox.ValueMember = "film_id";
            dateTimePicker_1.Value = dateTimePicker_1.MinDate;
            dateTimePicker_2.Value = dateTimePicker_2.MinDate;
            Genre_ComboBox.SelectedIndex = -1;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;

        }
    }
}
