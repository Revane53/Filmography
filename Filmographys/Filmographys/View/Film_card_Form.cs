using Filmographys.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filmographys.View
{
    public partial class Film_card_Form : Form
    {
        public Film_card_Form(int film_id)
        {
            InitializeComponent();
            string command = $"select * from Films where film_id = {film_id};";
            DataTable film_table = Connection.GetTable(command);
            Bitmap image = new Bitmap(film_table.Rows[0]["Picture"].ToString());
            pictureBox1.Image = image;
            pictureBox1.Invalidate();
            int index = (film_table.Rows[0]["year_of_release"].ToString()).IndexOf(' ');
            Filme_release_Label.Text = (film_table.Rows[0]["year_of_release"].ToString()).Remove(index);
            Budget_Label.Text = film_table.Rows[0]["movie_budget"].ToString();
            command = $"select * from Country where country_id = {(int)film_table.Rows[0]["country_film"]}";
            DataTable country_table = Connection.GetTable(command);
            Country_Label.Text = country_table.Rows[0]["country_name"].ToString();
            Viewers_Label.Text = film_table.Rows[0]["number_viewers"].ToString();
            Number_of_languages_Label.Text = film_table.Rows[0]["number_of_languages"].ToString();
            Description_TextBox.Text = film_table.Rows[0]["Description"].ToString();
            Film_Name_Label.Text = film_table.Rows[0]["film_name"].ToString();
            command = "";
            command = $"select * from PresidentOfFilmStudio where president_id in (select president_id from Film_PresidentOfFilmStudio where film_id = {film_id});" +
                $"select * from Producers where producer_id in ( select producer_id from Film_Producer where film_id = {film_id});" +
                $"select * from Actors where actors_id in (select actor_id from Film_Actors where film_id = {film_id});" +
                $"select * from Genres where genre_id in (select genre_id from Film_Genre where film_id = {film_id});" +
                $"select * from Country where country_id in ( select country_id from Film_Country where film_id = {film_id});" +
                $"select * from Humans; select * from PresidentOfFilmStudio;" +
                $"select * from Actors; select * from Producers;";
            DataSet Film_info = Connection.GetTables(command);
            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(PresidentOfFilmStudio_TextBox);
            textBoxes.Add(Producers_TextBox);
            textBoxes.Add(Actors_TextBox);
            textBoxes.Add(Genres_TextBox);
            textBoxes.Add(Country_View_TextBox);

            IEnumerable<DataRow> a;
            for (int i = 0; i < 5; i++)
            {
                foreach (var item in Film_info.Tables[i].AsEnumerable())
                {
                    if (i < 3)
                    {
                        a = from c in Film_info.Tables[5].AsEnumerable()
                            where c.Field<int>("human_id") == (int)item[1]
                            select c;
                        foreach (var items in a)
                        {
                            textBoxes[i].Text += items["surname"].ToString();
                            textBoxes[i].Text += " ";
                            textBoxes[i].Text += items["name"].ToString();
                            textBoxes[i].Text += Environment.NewLine;
                        }
                    }
                    else
                    { 
                            textBoxes[i].Text += item[1].ToString();
                            textBoxes[i].Text += Environment.NewLine;
                    }
                }
            }
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
