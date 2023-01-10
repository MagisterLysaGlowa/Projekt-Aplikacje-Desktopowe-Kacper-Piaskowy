using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Threading;

namespace HangMen.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        private string str_con = @"Server=(localdb)\Local;Database=HangMen;Trusted_Connection=Yes;";
        public Home()
        {
            InitializeComponent();
        }

        //---WALIDACJA NICKU I SPRAWDZANIE POŁĄCZENIA BAZĄ DANYCH
        private void PlayGame(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(str_con);
                con.Open();
            }
            catch
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
                {
                    MessageBox.Show("Problem with DataBase connection!","DB ERROR",MessageBoxButton.OK,MessageBoxImage.Warning);
                }));

                return;
            }

            if (IsValid())
            {
                GameBoard gameBoard = new GameBoard(txtBoxNickname.Text,str_con);
                gameBoard.Show();
                Application.Current.Windows[0].Close();
            }
        }

        //---WALIDACJĄ NICKU GRACZA---
        private bool IsValid()
        {
            if(txtBoxNickname.Text.Length < 5)
            {
                MessageBox.Show("NICK MUST BE MORE THAN 4 CHARACTERS");
                return false;
            }

            SqlConnection con = new SqlConnection(@"Server=(localdb)\Local;Database=HangMen;Trusted_Connection=Yes;");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(password) FROM Pass", con);
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                int num_rows = int.Parse(sdr[0].ToString());
                if(num_rows <= 0)
                {
                    throw new Exception();
                }
            }
            catch
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
                {
                    MessageBox.Show("No passwords into DataBase!", "DB ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                }));
                return false;
            }
            finally
            {
                con.Close();
            }

            return true;
        }
    }
}
