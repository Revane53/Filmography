using Filmographys.Class;
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

namespace Filmographys.View
{
    public partial class AddFilmsForm : Form
    {
        string FileName;
        string command;
        DataSet dataSet;
        List<ListBox> formListBoxs = new List<ListBox>();
        List<List<int>>id_Choosing_ListBox_items = new List<List<int>>();
        enum listbox_name
        {
            PresidentOfFilmStudio_ListBox,
            Producers_ListBox,
            Actors_ListBox,
            Genres_ListBox,
            Country_View_ListBox
        }


        public AddFilmsForm()
        {
            InitializeComponent();
            command = "select * from Country;select * from PresidentOfFilmStudio;" +
                        "select * from Producers;select * from Actors;select * from Genres;" +
                        "select * from Humans; select* from Film_PresidentOfFilmStudio; " +
                        $"select * from Film_Producer; select * from Film_Actors;" +
                        $"select * from Film_Country;select * from Film_Genre;";
            dataSet = Connection.GetTables(command);

            DataTable temp = dataSet.Tables[0].Copy();
            Country_ComboBox.DataSource = temp;
            Country_ComboBox.DisplayMember = "country_name";
            Country_ComboBox.ValueMember = "country_id";
            /*
                Президенты студий
                Режиссеры
                Актеры
                Жанры
           */
            Country_ComboBox.SelectedIndex = -1;
            Choosing_Category_ComboBox.SelectedIndex = -1;

            formListBoxs.Add(Country_View_ListBox);
            formListBoxs.Add(PresidentOfFilmStudio_ListBox);
            formListBoxs.Add(Producers_ListBox);
            formListBoxs.Add(Actors_ListBox);
            formListBoxs.Add(Genres_ListBox);
            for (int i = 0; i < formListBoxs.Count; i++)
            {
                id_Choosing_ListBox_items.Add(new List<int>());

            }
            this.Choosing_ListBox.DoubleClick += Add_Category_Button_Click;
        }

        private void Add_Picture_Button_Click(object sender, EventArgs e)
        {
            Bitmap image;
            OpenFileDialog open_dialog = new OpenFileDialog(); 
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; 
            if (open_dialog.ShowDialog() == DialogResult.OK) 
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    FileName = open_dialog.FileName;
                    pictureBox1.Image = image;
                    pictureBox1.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Add_Film_Button_Click(object sender, EventArgs e)
        {
            if (Is_The_Form_Completed())
            {
                string sqlExpression = "InsertFilm";
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "@film_name", Value = Film_Name_TextBox.Text });
                parameters.Add(new SqlParameter() { ParameterName = "@movie_budget", Value = Budget_NumericUpDown.Value });
                parameters.Add(new SqlParameter() { ParameterName = "@number_viewers", Value = Viewers_NumericUpDown.Value });
                parameters.Add(new SqlParameter() { ParameterName = "@number_of_languages", Value = Number_of_languages_NumericUpDown.Value });
                parameters.Add(new SqlParameter() { ParameterName = "@country_film", Value = Country_ComboBox.SelectedValue });
                parameters.Add(new SqlParameter() { ParameterName = "@picture", Value = FileName });
                parameters.Add(new SqlParameter() { ParameterName = "@description", Value = Description_TextBox.Text });
                parameters.Add(new SqlParameter() { ParameterName = "@year_of_release", Value = Filme_release_DateTimePicker.Value });
                int film_id = Connection.Test(sqlExpression, parameters);
                string command = "";
                List<DataTable> dataTables = new List<DataTable>();
                dataTables.Add(dataSet.Tables[9]);
                dataTables.Add(dataSet.Tables[6]);
                dataTables.Add(dataSet.Tables[7]);
                dataTables.Add(dataSet.Tables[8]);
                dataTables.Add(dataSet.Tables[10]);
                DataRow CountryRow = dataTables[0].NewRow();
                DataRow PresidentRow = dataTables[1].NewRow();
                DataRow ProducerRow = dataTables[2].NewRow();
                DataRow ActorsRow = dataTables[3].NewRow();
                DataRow GenreRow = dataTables[4].NewRow();

                for (int i = 0; i < formListBoxs.Count(); i++)
                {
                    foreach (var item in id_Choosing_ListBox_items[i])
                    {
                        switch (i)
                        {
                            case 1:
                                command += $@"insert into Film_PresidentOfFilmStudio (film_id,president_id) values ({film_id}, {item});";
                                PresidentRow["film_id"] = film_id;
                                PresidentRow["president_id"] = item;
                                break;
                            case 2:
                                command += $@"insert into Film_Producer (film_id,producer_id) values ({film_id}, {item});";
                                ProducerRow["film_id"] = film_id;
                                ProducerRow["producer_id"] = item;
                                break;
                            case 3:
                                command += $@"insert into Film_Actors (film_id,actor_id) values ({film_id}, {item});";
                                ActorsRow["film_id"] = film_id;
                                ActorsRow["actor_id"] = item;
                                break;
                            case 4:
                                command += $@"insert into Film_Genre (film_id,genre_id) values ({film_id}, {item});";
                                GenreRow["film_id"] = film_id;
                                GenreRow["genre_id"] = item;
                                break;
                            case 0:
                                command += $@"insert into Film_Country (film_id,country_id) values ({film_id}, {item});";
                                CountryRow["film_id"] = film_id;
                                CountryRow["country_id"] = item;
                                break;
                        }
                    }
                    switch (i)
                    {
                        case 0:
                            dataTables[0].Rows.Add(CountryRow);
                            break;
                        case 1:
                            dataTables[1].Rows.Add(PresidentRow);
                            break;
                        case 2:
                            dataTables[2].Rows.Add(ProducerRow);
                            break;
                        case 3:
                            dataTables[3].Rows.Add(ActorsRow);
                            break;
                        case 4:
                            dataTables[4].Rows.Add(GenreRow);
                            break;
                    }
                    if (command == "")
                        return;
                    Connection.InserToTable(dataTables[i], command);
                    command = "";
                }
                reset_form_info();
            } else
            {
                MessageBox.Show("Не все поля были заполнены");
            }
        }

        private void Choosing_Category_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = dataSet.Tables[Choosing_Category_ComboBox.SelectedIndex];
            if (Choosing_Category_ComboBox.SelectedIndex != 4 && Choosing_Category_ComboBox.SelectedIndex != 0)
            {
                var id_humanInProfession = from id in dataTable.AsEnumerable()
                                           select id.Field<int>("human_id");

                DataTable boundTable = new DataTable();
                IEnumerable<DataRow> res_name_city = null;
                foreach (var items in id_humanInProfession)
                {
                    res_name_city = from c in dataSet.Tables[5].AsEnumerable()
                                    where c.Field<int>("human_id") == (int)items
                                    select c;
                    boundTable.Merge(res_name_city.CopyToDataTable<DataRow>());
                }
                if (boundTable.Rows.Count == 0)
                {
                    Choosing_ListBox.DataSource = boundTable;
                    return;
                }
                DataColumn computedColumn = new DataColumn("Sum", typeof(string));
                computedColumn.Expression = $"{boundTable.Columns[2].ColumnName} + '   ' + {boundTable.Columns[1].ColumnName}";
                boundTable.Columns.Add(computedColumn);
                Choosing_ListBox.DataSource = boundTable;
                Choosing_ListBox.DisplayMember = "Sum";
                Choosing_ListBox.ValueMember = boundTable.Columns[0].ColumnName;
            }
            else
            {
                Choosing_ListBox.DataSource = dataTable;
                Choosing_ListBox.DisplayMember = dataTable.Columns[1].ColumnName;
                Choosing_ListBox.ValueMember = dataTable.Columns[0].ColumnName;
            }
        }
        private void Add_Category_Button_Click(object sender, EventArgs e)
        {
            if (Choosing_Category_ComboBox.SelectedIndex >= 0)
            {
                DataTable dataTable = dataSet.Tables[Choosing_Category_ComboBox.SelectedIndex];
                formListBoxs[Choosing_Category_ComboBox.SelectedIndex].Items.Add(Choosing_ListBox.Text);
                int res = 0;
                    if (Choosing_Category_ComboBox.SelectedIndex != 0 && Choosing_Category_ComboBox.SelectedIndex != 4)
                    {
                        var profession_id = from id in dataTable.AsEnumerable()
                                            where id.Field<int>("human_id") == (int)Choosing_ListBox.SelectedValue
                                            select id;

                        foreach (var item in profession_id)
                        {
                            int.TryParse((item[0]).ToString(), out res);
                            id_Choosing_ListBox_items[Choosing_Category_ComboBox.SelectedIndex].Add(res);
                        }
                    }
                    else
                    {
                        id_Choosing_ListBox_items[Choosing_Category_ComboBox.SelectedIndex].Add((int)Choosing_ListBox.SelectedValue);
                    }
            }
        }
        private void PresidentOfFilmStudio_ListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(PresidentOfFilmStudio_ListBox.SelectedIndex >=0)
                Del_items(listbox_name.PresidentOfFilmStudio_ListBox, PresidentOfFilmStudio_ListBox.SelectedIndex);
        }
        private void Del_items(listbox_name name, int selected_index)
        {
            switch (name)
            {
                case listbox_name.PresidentOfFilmStudio_ListBox:
                    PresidentOfFilmStudio_ListBox.Items.RemoveAt(selected_index);
                    id_Choosing_ListBox_items[1].RemoveAt(selected_index);
                    break;
                case listbox_name.Producers_ListBox:
                    Producers_ListBox.Items.RemoveAt(selected_index);
                    id_Choosing_ListBox_items[2].RemoveAt(selected_index);
                    break;
                case listbox_name.Actors_ListBox:
                    Actors_ListBox.Items.RemoveAt(selected_index);
                    id_Choosing_ListBox_items[3].RemoveAt(selected_index);
                    break;
                case listbox_name.Genres_ListBox:
                    Genres_ListBox.Items.RemoveAt(selected_index);
                    id_Choosing_ListBox_items[4].RemoveAt(selected_index);
                    break;
                case listbox_name.Country_View_ListBox:
                    Country_View_ListBox.Items.RemoveAt(selected_index);
                    id_Choosing_ListBox_items[0].RemoveAt(selected_index);
                    break;
            }
        }
        private void Producers_ListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Producers_ListBox.SelectedIndex >= 0)
                Del_items(listbox_name.Producers_ListBox, Producers_ListBox.SelectedIndex);

        }
        private void Actors_ListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Actors_ListBox.SelectedIndex >= 0)
                Del_items(listbox_name.Actors_ListBox, Actors_ListBox.SelectedIndex);

        }
        private void Genres_ListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (Genres_ListBox.SelectedIndex >= 0)
                Del_items(listbox_name.Genres_ListBox, Genres_ListBox.SelectedIndex);

        }
        private void Country_View_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Country_View_ListBox.SelectedIndex >= 0)
                Del_items(listbox_name.Country_View_ListBox, Country_View_ListBox.SelectedIndex);
        }

        private void reset_form_info()
        {
            Budget_NumericUpDown.Value = 0;
            Viewers_NumericUpDown.Value = 0;
            Country_ComboBox.SelectedIndex = -1;
            Film_Name_TextBox.Clear();
            Choosing_Category_ComboBox.SelectedIndex = 0;
            Number_of_languages_NumericUpDown.Value = 0;
            PresidentOfFilmStudio_ListBox.Items.Clear();
            Actors_ListBox.Items.Clear();
            Genres_ListBox.Items.Clear();
            Country_View_ListBox.Items.Clear();
            Description_TextBox.Clear();
            pictureBox1.Image = null;
        }
        private bool Is_The_Form_Completed()
        {
            if(Film_Name_TextBox.Text != "" &&  Country_ComboBox.SelectedIndex != -1 
                && PresidentOfFilmStudio_ListBox.Items != null && Actors_ListBox.Items != null
                && Genres_ListBox.Items != null && Country_View_ListBox.Items != null
                && Description_TextBox.Text != "" && Country_View_ListBox.Items != null
                && pictureBox1.Image != null)
            {
                return true;
            }
            return false;
        }
    }
}
