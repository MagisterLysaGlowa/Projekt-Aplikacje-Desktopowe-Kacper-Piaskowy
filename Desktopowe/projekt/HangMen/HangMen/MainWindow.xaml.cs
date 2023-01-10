using HangMen.ViewModel;
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

namespace HangMen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*---DATA CONTEXT MAIN WINDOW CZYLI POSZCZEGÓLNE TZW PAGE CZYLI JAKBY ZAKŁADKI POJAWIAJĄĆE SIĘ NA STRONIE GŁÓWNEJ KTÓRE
            SĄ USTAWIANIE I KONFIGUROWANE PRZEZ INTERFEJS ICOMMAND*/
            DataContext = new MainViewModel();

        }

        //---HOVER WYGLĄD KOSMETYCZNY PRZYCISKÓW---
        private void Btn_Hover_Main_Win_Enter(object sender, MouseEventArgs e)
        {
            Button? btn = sender as Button;
            var color = new BrushConverter().ConvertFrom("#FFCC8535");
            btn.Background = color as Brush;
        }
    }
}
