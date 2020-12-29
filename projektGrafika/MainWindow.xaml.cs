using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projektGrafika
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string connectionString = "SERVER=localhost;DATABASE=projektgrafika;UID=root;PASSWORD=;";
            MySqlConnection con = new MySqlConnection(connectionString);

            #region WYPEŁNIENIE LISTY
            try
            {
                string query = "SELECT Name FROM pacjent";
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();

                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr.GetString(0);
                    pacjentList.Items.Add(name);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion


            #region previous code
            //DataTable dt = new DataTable();
            //dt.Load(cmd.ExecuteReader());
            //con.Close();
            //pacjentList.Items.Add(dt);
            #endregion
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            DodajPacjentaWindow add = new DodajPacjentaWindow();
            add.Show();
        }

        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            pacjentList.Items.Clear();

            string connectionString = "SERVER=localhost;DATABASE=projektgrafika;UID=root;PASSWORD=;";
            MySqlConnection con = new MySqlConnection(connectionString);

            try
            {
                string query = "SELECT Name FROM pacjent";
                MySqlCommand cmd = new MySqlCommand(query, con);

                con.Open();

                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr.GetString(0);

                    pacjentList.Items.Add(name);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pacjentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string connectionString = "SERVER=localhost;DATABASE=projektgrafika;UID=root;PASSWORD=;";
            MySqlConnection con = new MySqlConnection(connectionString);

            try
            {

                string namePacjent = pacjentList.SelectedItem.ToString();
                

                con.Open();


                string query = "SELECT lek.Nazwa, dawkowanie.Dawka, dawkowanie.Data FROM dawkowanie " + 
                                "LEFT JOIN pacjent ON pacjent.Id = dawkowanie.PacjentId " + 
                                "RIGHT JOIN lek ON lek.Id = dawkowanie.LekId " + 
                                "WHERE dawkowanie.Data <= CURDATE() + INTERVAL 7 DAY " +
                                "AND dawkowanie.Data >= CURDATE() " +
                                "AND pacjent.Name='" + namePacjent + "'";

                MySqlCommand cmd = new MySqlCommand(query, con);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                con.Close();

                dawkaGrid.DataContext = dt;
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btwExitApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
