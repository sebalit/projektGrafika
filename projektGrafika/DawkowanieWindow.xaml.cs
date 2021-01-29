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
        private int pacjentId;
        private int lekId;


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
            addDawka(pacjentId, lekId);
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
                MessageBox.Show(ex.Message + "1!");
            }
        }
        #endregion

        #region LEK COMBO BOX
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
                    lekNameComboBox.Items.Add(lekName + "2!");

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        private void addDawka(int pacjentId, int lekId)
        {

            string dawka;
            string data;

            //pacjentId = getPacjentId(pacjentName);
            //lekId = getLekId(lekName);
            dawka = dawkaBox.Text.ToString();
            data = dataBox.Text;

            //Date dt = Date.Parse(data);

            string connectionString = "SERVER=localhost;DATABASE=projektgrafika;UID=root;PASSWORD=;";
            MySqlConnection con = new MySqlConnection(connectionString);

            try
            {
                con.Open();

                string query = "INSERT INTO dawkowanie VALUES(NULL, '" + dawka + "', '" + data + "', '" +
                                pacjentId + "', '" + lekId + "')";
                MessageBox.Show(query);

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();

                con.Close();
  
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "3!");
            }

        }

        private void pacjentNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int pacjent = this.pacjentNameComboBox.SelectedIndex + 1;
            string pacjentName = pacjent.ToString();
            
            MessageBox.Show(pacjentName);
            
            string connectionString = "SERVER=localhost;DATABASE=projektgrafika;UID=root;PASSWORD=;";
            MySqlConnection con = new MySqlConnection(connectionString);

            if(pacjentNameComboBox.SelectedItem != null)
            {
                try
                {
                    con.Open();
                    string query = "SELECT pacjent.Id FROM pacjent WHERE pacjent.Id='" + pacjentName + "'";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        pacjentId = dr.GetInt32(0);
                    }
                    con.Close();
                    Console.WriteLine(pacjentId);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "4!");
                }
            }
            
        }

        private void lekNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int lek = this.lekNameComboBox.SelectedIndex + 1;
            string lekName = lek.ToString();

            string connectionString = "SERVER=localhost;DATABASE=projektgrafika;UID=root;PASSWORD=;";
            MySqlConnection con = new MySqlConnection(connectionString);
            if(lekNameComboBox.SelectedItem != null)
            {
                try
                {
                    con.Open();

                    string query = "SELECT lek.Id FROM lek WHERE lek.Id='" + lekName + "'";
                    MessageBox.Show(query);

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lekId = dr.GetInt32(0);
                    }
                    

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "5!");
                }
            }
            

        }
    }
}
