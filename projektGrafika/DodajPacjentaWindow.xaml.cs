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
    /// Interaction logic for DodajPacjentaWindow.xaml
    /// </summary>
    public partial class DodajPacjentaWindow : Window
    {
        public DodajPacjentaWindow()
        {
            InitializeComponent();
            
        }

        private void SanitizeText(string text)
        {


            //TODO sprwadzanie czy string składa sie tylko z liter
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;DATABASE=projektgrafika;UID=root;PASSWORD=;";
            MySqlConnection con = new MySqlConnection(connectionString);

            try
            {
                #region DATA
                string name = nameBox.Text;
                string lastName = lastnameBox.Text;
                string age = ageBox.Text;
                #endregion

                con.Open();

                string query = "INSERT INTO pacjent  VALUES(NULL, '" + name + "', '" + lastName + "', '" + age + "')";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                
                con.Close();

                this.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
