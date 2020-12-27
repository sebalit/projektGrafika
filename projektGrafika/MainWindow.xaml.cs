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

            void fillNameList()
            {
                try
                {
                    string query = "SELECT Name, Lastname FROM pacjent";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    con.Open();
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        string name = dr.GetString(0);
                        string lastName = dr.GetString(1);
                        pacjentList.Items.Add(name + " " + lastName);
                    }
                    con.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

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
    }
}
