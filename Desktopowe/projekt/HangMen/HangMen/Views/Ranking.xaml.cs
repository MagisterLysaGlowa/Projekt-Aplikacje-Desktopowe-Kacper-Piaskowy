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
    /// Logika interakcji dla klasy Ranking.xaml
    /// </summary>
    public partial class Ranking : UserControl
    {
        public Ranking()
        {
            InitializeComponent();
            Show_Ranking(this);
        }

        //---WYŚWIETLANIE RANKINGU GRACZY---
        private void Show_Ranking(Ranking rankBrd)
        {
            string str_con = @"Server=(localdb)\Local;Database=HangMen;Trusted_Connection=Yes;";
            SqlConnection con;
            try
            {
                con = new SqlConnection(str_con);
                con.Open();
            }
            catch
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Action)(() =>
                {
                    MessageBox.Show("Problem with DataBase connection!", "DB ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
                }));
                return;
            }
            string query = "SELECT * FROM RankingTable ORDER BY score DESC";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            int ranking_place = 1;
            for (int i = 0; i < 10; i++)
            {
                if(reader.Read())
                {
                    BrushConverter brush = new BrushConverter();
                    //---STYLIZACJA KAŻDEGO WYNIKU W CODE BEHIND---
                    Label label = new Label
                    {
                        Content = reader["player"].ToString() + " " + reader["score"].ToString(),
                        Background = (Brush)brush.ConvertFromString("white"),
                        BorderBrush = (Brush)brush.ConvertFromString("Black"),
                        BorderThickness = new Thickness(2),
                        FontSize = 20,
                        Margin = new Thickness(0,2,0,0),
                        Width = 590,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                    };
                    ranking_stack.Children.Add(label);
                }
            }
        }
    }
}
