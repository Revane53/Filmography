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
            command = "select * from Films;";
            dataSet = Connection.GetTables(command);
            Film_ListBox.DataSource = dataSet.Tables[0];
            Film_ListBox.DisplayMember = "film_name";
            Film_ListBox.ValueMember = "film_id";
            Add_Film_Button.Visible = false;
            Add_Info_Button.Visible = false;
            filtrs.Add("desc");
            filtrs.Add("asc");
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
    }
}
