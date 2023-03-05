using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Filmographys.Class;

namespace Filmographys.View
{
    public partial class MaintainingDirectoryForm : Form
    {
        DataSet dataSet, dataSet_humans;
        string command, human_command;
        int id_country = -1;
        int id_country_combobox = -1;
        public MaintainingDirectoryForm()
        {
            InitializeComponent();
            ConnectionToDatabase();
        }
        private void ConnectionToDatabase()
        {
            command = "select * from Country; select * from Citys;" +
                              "select * from Genders; select * from Genres;";
            human_command = "select * from Humans; select * from Actors;" +
                             "select * from Producers; select * from PresidentOfFilmStudio;";
            dataSet = Connection.GetTable(command);
            dataSet_humans = Connection.GetTable(human_command);

            listBox1.DataSource = dataSet.Tables[0];
            listBox1.DisplayMember = "country_name";
            listBox1.ValueMember = "country_id";

            Country_ComboBox.DataSource = dataSet.Tables[0];
            Country_ComboBox.DisplayMember = "country_name";
            Country_ComboBox.ValueMember = "country_id";

            listBox3.DataSource = dataSet.Tables[2];
            listBox3.DisplayMember = "gender_name";
            listBox3.ValueMember = "gender_id";

            Gender_ComboBox.DataSource = dataSet.Tables[2];
            Gender_ComboBox.DisplayMember = "gender_name";
            Gender_ComboBox.ValueMember = "gender_id";

            listBox4.DataSource = dataSet.Tables[3];
            listBox4.DisplayMember = "genre_name";
            listBox4.ValueMember = "genre_id";

            if (City_ComboBox.Items.Count > 0)
                City_ComboBox.SelectedIndex = 0;
            listBox1.SelectedIndex = -1;
            Country_ComboBox.SelectedIndex = -1;
            Gender_ComboBox.SelectedIndex = -1;
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void Add_Gender_Button_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {

                string com = $@"insert into Genders (gender_name) values ('{textBox3.Text.ToString()}');";
                DataTable dt = dataSet.Tables[2];
                DataRow newRow = dt.NewRow();
                newRow["gender_name"] = textBox3.Text.ToString();
                dt.Rows.Add(newRow);

                Connection.InserToTable(dt, com);
                textBox3.Text = "";
            }
        }
        private void Delete_Gender_Button_Click(object sender, EventArgs e)
        {
            string com = $@"DELETE FROM Genders where gender_name = '{listBox3.Text}';";

            DataTable dt = dataSet.Tables[2];
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {

                DataRow dr = dt.Rows[i];
                if (dr["gender_name"].ToString() == listBox3.Text)
                {
                    dr.Delete();
                    break;
                }
            }
            Connection.Delete(dt, com);
        }

        private void Add_Genre_Button_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {

                string com = $@"insert into Genres (genre_name) values ('{textBox4.Text.ToString()}');";
                DataTable dt = dataSet.Tables[3];
                DataRow newRow = dt.NewRow();
                newRow["genre_name"] = textBox4.Text.ToString();
                dt.Rows.Add(newRow);

                Connection.InserToTable(dt, com);
                textBox4.Text = "";
            }
        }

        private void Delete_Genre_Button_Click(object sender, EventArgs e) 
        {
            string com = $@"DELETE FROM Genres where genre_name = '{listBox4.Text}';";
                     
            DataTable dt = dataSet.Tables[3];
            //DataRow newRow = dt.NewRow();
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {

                DataRow dr = dt.Rows[i];
                if (dr["genre_name"].ToString() == listBox4.Text)
                {
                    dr.Delete();
                    break;
                }
                //Connection.Delete(dt, com);
            }
            Connection.Delete(dt, com);
        }
        
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.Items.Count < 0 || listBox1.SelectedIndex < 0)
                return;
            listBox2.Items.Clear();/*
           var res_id_country = from c in dataSet.Tables[0].AsEnumerable()
                      where c.Field<string>("country_name") == listBox1.Text
                      select c.Field<int>("country_id");
            
            foreach (var item in res_id_country)
            {
                id_country = item;
            }*/
            int.TryParse(listBox1.SelectedValue.ToString(), out id_country);
            
            var res_name_city = from c in dataSet.Tables[1].AsEnumerable()
                  where c.Field<int>("country_id") == id_country
                  select c.Field<string>("city_name");
            foreach (var item in res_name_city)
            {
                listBox2.Items.Add(item);
            }
            
        }

        private void Add_Country_Button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string sqlExpression = "InsertCountry";
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter()
                {
                    ParameterName = "@country_name",
                    Value = textBox1.Text
                });
               // string com = $@"insert into Country (country_name) values ('{textBox1.Text.ToString()}');";
                DataTable dt = dataSet.Tables[0];
               // DataRow newRow = dataSet.Tables[0].NewRow();
                DataRow newRow = dt.NewRow();
                newRow["country_name"] = textBox1.Text.ToString();
                newRow["country_id"] = (int)Connection.Test(sqlExpression,parameters);
                //dt.Rows.Add(newRow);
                dataSet.Tables[0].Rows.Add(newRow);

                //Connection.updatecom(dataSet.Tables[0], "select * from country;");
                //Connection.InserToTable(dt, com);
                textBox1.Text = "";
               // ConnectionToDatabase();
            }

        }

        private void Delete_Country_Button_Click(object sender, EventArgs e)
        {
            AlarmForm alarmForm = new AlarmForm();
            if (true)//alarmForm.ShowDialog() == DialogResult.OK)
            {
                listBox1_SelectedIndexChanged(this, e);
                string com_0 = $@"DELETE FROM Country where country_id = '{id_country}';";
                string com_1 = $@"DELETE FROM Citys where country_id = {id_country};";

                DataTable dt_0 = dataSet.Tables[0];
                DataTable dt_1 = dataSet.Tables[1];
                bool boo = false;
                //Удаление из таблицы городов
                for (int i = dt_1.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr_1 = dt_1.Rows[i];
                    if ((int)dr_1["country_id"] == id_country)
                    {
                        dr_1.Delete();
                        boo = true;
                        break;
                    }
                }
                if(boo)
                    Connection.Delete(dt_1, com_1);
                // Удаоение из таблицы стран
                for (int i = dt_0.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr_0 = dt_0.Rows[i];
                    if ((int)dr_0["country_id"] == id_country)
                    {
                        dr_0.Delete();
                        break;
                    }
                }
                Connection.Delete(dt_0, com_0);
            }
        }

        private void Add_City_Button_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && listBox1.SelectedIndex >= 0)
            {
                string com = $@"insert into Citys (country_id,city_name) values ( {id_country},'{textBox2.Text.ToString()}');";
                DataTable dt = dataSet.Tables[1];
                DataRow newRow = dt.NewRow();
                newRow["country_id"] = id_country;
                newRow["city_name"] = textBox2.Text.ToString();
                dt.Rows.Add(newRow);
                Connection.InserToTable(dt, com);
                listBox2.Items.Add(textBox2.Text.ToString());
                textBox2.Text = "";
            }
        }

        private void Delete_City_Button_Click(object sender, EventArgs e)
        {
            // string com = $@"DELETE FROM Citys where city_name = '{listBox2.Text}';";
            string com = $@"DELETE FROM Citys where city_name = '{listBox2.Text}';";

            DataTable dt = dataSet.Tables[1];
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {

                DataRow dr = dt.Rows[i];
                if (dr["city_name"].ToString() == listBox2.Text)
                {
                    dr.Delete();
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    break;
                }
            }
            Connection.Delete(dt, com);
        }

        private void Country_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           // City_ComboBox.Items.Clear();
            if (Country_ComboBox.SelectedIndex < 0)
                return;
            int.TryParse(Country_ComboBox.SelectedValue.ToString(), out id_country_combobox);
            /*
            var res_name_city = from c in dataSet.Tables[1].AsEnumerable()
                                where c.Field<int>("country_id") == id_country_combobox
                                select c.Field<string>("city_name");
            foreach (var item in res_name_city)
            {
                City_ComboBox.Items.Add(item);
            }
            */
            IEnumerable<DataRow> res_name_city = from c in dataSet.Tables[1].AsEnumerable()
                                where c.Field<int>("country_id") == id_country_combobox
                                select c;
            if (res_name_city.Count<DataRow>() == 0)
                return;

            City_ComboBox.DataSource = res_name_city.CopyToDataTable<DataRow>();
            City_ComboBox.DisplayMember = "city_name";
            City_ComboBox.ValueMember = "city_id";
            //var f = dataSet.Tables[1].AsEnumerable().Where(r => r.Field<int>("country_id") == id_country_combobox).Select(r => r.Field<int>("city_name"));
        }

        private void Add_Human_Button_Click(object sender, EventArgs e)
        {
            int gender = (int)Gender_ComboBox.SelectedValue;
            int country = (int)Country_ComboBox.SelectedValue;
            int residence = -1;
            var res_id = from c in dataSet.Tables[1].AsEnumerable()
                         where c.Field<string>("city_name") == City_ComboBox.SelectedItem.ToString()
                         select c.Field<int>("city_id");
            float annual_income = (int)Income_NumericUpDown.Value;

            foreach (var item in res_id)
            {
                residence = item;
            }
            ///тест
            string sqlExpression = "InsertUser";
            List< SqlParameter > parameters = new List< SqlParameter >();
            parameters.Add(new SqlParameter() {ParameterName = "@name", Value = Name_TextBox.Text});
            parameters.Add(new SqlParameter() {ParameterName = "@surname", Value = Surname_TextBox.Text});
            parameters.Add(new SqlParameter() {ParameterName = "@gender", Value = gender});
            parameters.Add(new SqlParameter() {ParameterName = "@country", Value = country});
            parameters.Add(new SqlParameter() {ParameterName = "@residence", Value = residence});
            parameters.Add(new SqlParameter() {ParameterName = "@annual_income", Value = annual_income});
            int human_id = Connection.Test(sqlExpression, parameters);
            DataTable dt_human = dataSet_humans.Tables[0];
            DataRow newRow_human = dt_human.NewRow();
            newRow_human["human_id"] = human_id;
            newRow_human["name"] = Name_TextBox.Text;
            newRow_human["surname"] = Surname_TextBox.Text;
            newRow_human["gender"] = gender;
            newRow_human["country"] = country;
            newRow_human["residence"] = residence;
            newRow_human["annual_income"] = annual_income;
            dt_human.Rows.Add(newRow_human);
            ///конец теста
            
            string com;
            if (Actors_CheckBox.Checked)
            {
                com = $@"insert into Actors (human_id) values ({human_id})";
                DataTable dt_actors = dataSet_humans.Tables[1];
                DataRow newRow_actors = dt_actors.NewRow();
                newRow_actors["human_id"] = human_id;
                dt_actors.Rows.Add(newRow_actors);
                Connection.InserToTable(dt_actors, com);
            }
            if (Producer_CheckBox.Checked)
            {
                com = $@"insert into Producers (human_id) values ({human_id})";
                DataTable dt_producers = dataSet_humans.Tables[2];
                DataRow newRow_producers = dt_producers.NewRow();
                newRow_producers["human_id"] = human_id;
                dt_producers.Rows.Add(newRow_producers);
                Connection.InserToTable(dt_producers, com);

            }
            if (President_CheckBox.Checked)
            {
                com = $@"insert into PresidentOfFilmStudio (human_id) values ({human_id})";
                DataTable dt_presidentOfFilmStudio = dataSet_humans.Tables[3];
                DataRow newRow_presidentOfFilmStudio = dt_presidentOfFilmStudio.NewRow();
                newRow_presidentOfFilmStudio["human_id"] = human_id;
                dt_presidentOfFilmStudio.Rows.Add(newRow_presidentOfFilmStudio);
                Connection.InserToTable(dt_presidentOfFilmStudio, com);
            }


        }
    }
}
