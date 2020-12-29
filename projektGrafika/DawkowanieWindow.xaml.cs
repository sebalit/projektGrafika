using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace projektGrafika
{
    /// <summary>
    /// Interaction logic for DawkowanieWindow.xaml
    /// </summary>
    public partial class DawkowanieWindow : Window
    {
        public DawkowanieWindow()
        {
            InitializeComponent();
            //getPacjentId();
           // getLekId();
            fillPacjentCombo();
            fillLekCombo();
            
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            addDawka(getPacjentId(), 1);
        }

        #region PACJENT COMBO BOX
        private void fillPacjentCombo()
        {
            string connectionString = "SERVER=localhost;DATABASE=projektgrafika;UID=root;PASSWORD=;";
            MySqlConnection con = new MySqlConnection(connectionString);

            try
            {
                string query = "SELECT pacjent.Name FROM pacjent";
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();

                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string pacjentName = dr.GetString(0);
                    pacjentNameComboBox.Items.Add(pacjentName);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region
        private void fillLekCombo()
        {
            string connectionString = "SERVER=localhost;DATABASE=projektgrafika;UID=root;PASSWORD=;";
            MySqlConnection con = new MySqlConnection(connectionString);

            try
            {
                string query = "SELECT lek.Nazwa FROM lek";
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();

                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string lekName = dr.GetString(0);
                    lekNameComboBox.Items.Add(lekName);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addDawka(int pacjentId, int lekId)
        {

            string dawka;
            string data;

            //pacjentId = getPacjentId(pacjentName);
            //lekId = getLekId(lekName);
            dawka = dawkaBox.Text.ToString();
            data = dataBox.Text;

            DateTime dt = DateTime.Parse(data);

            string connectionString = "SERVER=localhost;DATABASE=projektgrafika;UID=root;PASSWORD=;";
            MySqlConnection con = new MySqlConnection(connectionString);

            try
            {
                con.Open();

                string query = "INSERT INTO dawkowanie VALUES(NULL, '" + dawka + "', '" + data + "', '" +
                                pacjentId + "', '" + lekId + "'";
                MessageBox.Show(query);

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();

                con.Close();

                

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private int getPacjentId()
        {

            string pacjentName;
            pacjentName = pacjentNameComboBox.SelectedValue.ToString();

            int pacjentId = 0;

            string connectionString = "SERVER=localhost;DATABASE=projektgrafika;UID=root;PASSWORD=;";
            MySqlConnection con = new MySqlConnection(connectionString);

            try
            {
                con.Open();

                string query = "SELECT pacjent.Id FROM pacjent WHERE pacjent.Name='" + pacjentName + "'";

                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dr = cmd.ExecuteReader();
                MessageBox.Show(query);
                while (dr.HasRows)
                {
                    pacjentId = Int32.Parse(dr.GetString(0));
                }

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return pacjentId;
        }

        private int getLekId()
        {

            string lekName;
            lekName = lekNameComboBox.SelectedValue.ToString();

            int lekId = 0;

            string connectionString = "SERVER=localhost;DATABASE=projektgrafika;UID=root;PASSWORD=;";
            MySqlConnection con = new MySqlConnection(connectionString);

            try
            {
                con.Open();

                string query = "SELECT lek.Id FROM lek WHERE lek.Nazwa='" + lekName + "'";
                MessageBox.Show(query);

                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader dr = cmd.ExecuteReader();

                lekId = dr.GetInt32(0);

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return lekId;
        }
        #endregion
    }
}
