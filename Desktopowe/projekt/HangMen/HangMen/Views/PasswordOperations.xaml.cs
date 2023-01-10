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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HangMen.Views
{
    /// <summary>
    /// Logika interakcji dla klasy PasswordOperations.xaml
    /// </summary>
    public partial class PasswordOperations : UserControl
    {
        public PasswordOperations()
        {
            InitializeComponent();
        }

        //---OTWIERANIE OKNA PASS MANAGMENT---
        //---ZABEZPIECZONE HASŁEM KTÓRE NIE JEST W BAZIE LECZ JEST USTAWIONE LOKALNIE
        private void Load_Password_Managment(object sender, RoutedEventArgs e)
        {
            if(pass.Password == "3PTP2")
            {
                PassManagment passManagment = new PassManagment();
                passManagment.Show();
                Application.Current.Windows[0].Close();
            }
            else
            {
                MessageBox.Show("Invalid password");
            }
        }
    }
}
