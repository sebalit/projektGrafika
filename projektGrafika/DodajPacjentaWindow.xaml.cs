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
            if (!string.IsNullOrEmpty(nameBox.Text) && !string.IsNullOrEmpty(ageBox.Text) && !string.IsNullOrEmpty(lastnameBox.Text))
            {
                string connectionString = "SERVER=localhost;DATABASE=projektgrafika;UID=root;PASSWORD=;";
                MySqlConnection con = new MySqlConnection(connectionString);

                try
                {
                    #region DATA
                    string name = nameBox.Text;
                    string description = lastnameBox.Text; //TODO ZMIENIC TEXT BOXA 
                    string age = ageBox.Text;
                    #endregion

                    con.Open();

                    string query = "INSERT INTO pacjent  VALUES(NULL, '" + name + "', '" + age + "', '" + description + "')";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Wypełnij wszystkie pola");
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = IsTextNumeric(e.Text);
        }
        private static bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
