using Filmographys.Class;
using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Filmographys.View
{
    public partial class MainForm : Form
    {
        String command;
        DataSet dataSet;
        Film_card_Form film_Card_Form;
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
        }

        private void Show_FilmCard_Button_Click(object sender, EventArgs e)
        {
            film_Card_Form = new Film_card_Form((int)Film_ListBox.SelectedValue);
            film_Card_Form.Show();
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
        }

        private void Add_Info_Button_Click(object sender, EventArgs e)
        {
            MaintainingDirectoryForm maintainingDirectoryForm = new MaintainingDirectoryForm();
            maintainingDirectoryForm.Show();
        }
    }
}
