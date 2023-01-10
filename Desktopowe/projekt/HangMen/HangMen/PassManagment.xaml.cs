using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace HangMen
{
    /// <summary>
    /// Logika interakcji dla klasy PassManagment.xaml
    /// </summary>
    public partial class PassManagment : Window
    {
        private SqlConnection con;
        //---OTWIERANIE POŁĄCZENIA Z BAZĄ DANYCH W KONSTRUKTORZE KLASY---
        public PassManagment()
        {
            InitializeComponent();
            bool correctConnection = true;
            try
            {
                //---LOCAL STRING DO POŁĄCZENIA Z BAZĄ---
                con = new SqlConnection(@"Server=(localdb)\Local;Database=HangMen;Trusted_Connection=Yes;");
                con.Open();
            }
            catch
            {
                main_elm_1.Visibility = Visibility.Hidden;
                main_elm_2.Visibility = Visibility.Hidden;
                main_elm_3.Visibility = Visibility.Hidden;
                datagrid.Visibility = Visibility.Hidden;
                db_Error.Visibility = Visibility.Visible;
                correctConnection = false;

            }
            con.Close();
            if (correctConnection)
            {
                LoadGrid();
            }
        }

        //---ŁADOWANIE TABLEKI Z HASŁAMI DO GRY---
        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Pass",con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            datagrid.ItemsSource = dt.DefaultView;
        }

        //---WALIDACJA HASEŁ KTÓRE CHCEMY DODAĆ DO BAZY---
        private bool IsValid()
        {
            SqlCommand cmd = new SqlCommand("SELECT COUNT(password) FROM Pass WHERE password='"+ name_txt.Text +"'", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            int num_rows = int.Parse(sdr[0].ToString());
            con.Close();
            if(num_rows > 0)
            {
                MessageBox.Show("This password is in database now!");
                return false;
            }

            if(name_txt.Text.Length < 3 || name_txt.Text.Length > 22)
            {
                MessageBox.Show("Invalid input password must be between 3 and 22 characters");
                return false;
            }
            return true;
        }

        //---DODAWANIE HASŁA DO BAZY DANYCH---
        private void Insert()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Pass (password) VALUES ('" + name_txt.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            name_txt.Text = "";
            LoadGrid();
        }

        //---EVENT PRZYCISKU
        private void Insert_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                Insert();
            }
        }

        //---EVENT WRAZ Z LOGIKĄ USUWAJĄCY HASŁO Z BAZY---
        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Pass WHERE password_id="+ search_txt.Text +"",con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            LoadGrid();
        }

        //---POWRÓT DO MENU GŁÓWNEGO---
        private void Back_Btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }        

        //---CZYSZCZENIE WSZYSTKICH HASEŁ KTÓRE ZNAJDUJĄ SIE W BAZIE---
        private void Clear_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("You want clear all records?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                SqlCommand cmd = new SqlCommand("TRUNCATE TABLE Pass", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                LoadGrid();
            }
        }
    }
}
