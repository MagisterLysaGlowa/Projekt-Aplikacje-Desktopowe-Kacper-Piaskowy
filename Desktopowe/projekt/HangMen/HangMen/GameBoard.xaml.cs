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

namespace HangMen
{
    /// <summary>
    /// Logika interakcji dla klasy GameBoard.xaml
    /// </summary>
    public partial class GameBoard : Window
    {
        public GameBoard(string nickname,string con_db_string)
        {
            InitializeComponent();
            //---TWORZENIE POLA GRY PRZEZ INSTANCJĘ KLASY BoardGeneraor---
            BoardGenerator boardGenerator = new BoardGenerator(game_img, passlbl,nickname,this, con_db_string);
            boardGenerator.GenerateKeyBoard(gameBoard);
        }

        //POWRÓT DO MAIN PAGE
        private void return_mainpage_button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Application.Current.Windows[0].Close();
        }
    }
}
