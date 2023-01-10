using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace HangMen
{
    public class BoardGenerator
    {
        //---POLA KLASY---
        string password;
        char[] wordArray;
        static int mistakes = 0;
        private Image GameImg;
        private string db_connect;
        private Label password_label;
        public GameBoard gameBrd;
        private int gameTimeInSeconds;
        private bool gameOver = false;
        private DispatcherTimer dispatcherTimer;
        private bool isWin = false;
        public string Nickname { get; set; }

        //---KONSTRUKTOR KLASY USTAWIAJĄCY POSZCZEGÓLNE POLA ORAZ STARTUJĄCY TIMER GRY---
        public BoardGenerator(Image GameImg,Label password_label,string nickname,GameBoard gameBrd,string db_connect)
        {
            mistakes = 0;
            this.GameImg = GameImg;
            this.password_label = password_label;
            this.gameBrd = gameBrd;
            this.db_connect = db_connect;
            Nickname = nickname;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += addSecond;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }
        //---GENEROWANIE PRZYCISKÓW NA PLANSZY I DODAWANIE IM CLICK EVENTU---
        public void GenerateKeyBoard(Grid grid)
        {
            //---WYCIĄGANIE HASŁA Z BAZY---
            password = GetPassFromDb();
            List<char> characters = new List<char>()
            {
                'A','B','C','D','E','F','G','H','I','J','K','L','M',
                'N','O','P','Q','R','S','T','U','V','W','X','Y','Z','-'
            };
            wordArray = EmptyPassword(password);
            password_label.Content = DisplayPassword(wordArray," ");

            int _columnCount = grid.ColumnDefinitions.Count;
            int _rowCount = grid.ColumnDefinitions.Count;

            int _counter = 0;

            for (int i = 2; i < 5; i++)
            {
                for (int j = 1; j < _columnCount-1; j++)
                {
                    Button button = new Button()
                    {
                        Content = characters[_counter],
                        Margin = new System.Windows.Thickness(2),
                        Style = (Style)gameBrd.FindResource("Button-Style")
                };
                    button.Click += AlertButton;
                    Grid.SetColumn(button, j);
                    Grid.SetRow(button, i);
                    grid.Children.Add(button);
                    _counter++;
                }
            }
            GameTime();
        }
        //---LOGIKA GRY---
        public void AlertButton(object sender,RoutedEventArgs e)
        {
            Button button = sender as Button;
            //---POBIERANIE HASŁA Z LISTY---
            var list = copyPassword(password);

            //---SPRAWDZANIE WYGRAJNEJ---
            if (!isWin)
            {
                if (list.Contains((char)button.Content) && !gameOver)
                {
                    do
                    {
                        int index = list.IndexOf((char)button.Content);
                        wordArray[index] = password[index];
                        list[index] = ' ';
                    }while(list.Contains((char)button.Content));
                    button.Background = new SolidColorBrush(Colors.Green);
                }
                else
                {
                    mistakes++;
                    if(mistakes > 9)
                    {
                        gameBrd.game_end_label.Visibility = Visibility.Visible;
                        gameBrd.game_end_label.IsEnabled = true;
                        gameBrd.game_end_label.Content = "GAMEOVER";

                        gameBrd.return_mainpage_button.Visibility = Visibility.Visible;
                        gameBrd.return_mainpage_button.IsEnabled = true;
                        password_label.Content = password.ToString();
                        gameOver = true;
                        dispatcherTimer.Stop();
                        return;
                    }
                    if (!gameOver)
                    {
                        BitmapImage Bitmap = new BitmapImage();
                        Bitmap.BeginInit();
                        Bitmap.UriSource = new Uri($"Image/s{mistakes}.jpg", UriKind.Relative);
                        Bitmap.EndInit();
                        GameImg.Source = Bitmap;
                        button.Background = new SolidColorBrush(Colors.Red);
                    }
                }
                //---MECHANIKA WYŚWIETLANIA HASŁA---
                password_label.Content = DisplayPassword(wordArray," ");
                if (password == DisplayPassword(wordArray, ""))
                {
                    gameBrd.game_end_label.Visibility = Visibility.Visible;
                    gameBrd.game_end_label.IsEnabled = true;
                    gameBrd.game_end_label.Content = Nickname + " YOU WIN!";
                    gameBrd.return_mainpage_button.Visibility = Visibility.Visible;
                    gameBrd.return_mainpage_button.IsEnabled = true;
                    gameOver = true;
                    GameWin();
                    isWin = true;
                }
                button.IsHitTestVisible = false;    
            }
        }

        //---WYCIĄGANIE HASŁA Z LISTY---
        private List<char> copyPassword(string hash)
        {
            List<char> list = new List<char>();
            for (int i = 0; i < hash.Length; i++)
            {
                list.Add(hash[i]);
            }
            return list;
        }

        //---WYŚWIETLANIE HASŁA PO UKOŃCZENIU GRY---
        private string DisplayPassword(char[] words,string separator)
        {
            string pass = "";
            foreach (var element in words)
                pass+= separator + element.ToString() + separator;
            return pass;
        }

        private char[] EmptyPassword(string pass)
        {
            char[] result = new char[pass.Length];
            for (int i = 0; i < pass.Length; i++)
            {
                if(pass[i] == ' ')
                {
                    result[i] = ' ';
                }
                else
                {
                    result[i] = '—';
                }
            }
            return result;
        }

        //---WYCIĄGANIE HASŁA Z BAZY---
        private string GetPassFromDb()
        {
            Random rand = new Random();
            SqlConnection con = new SqlConnection(db_connect);
            con.Open();
            string get_count = "SELECT COUNT(password_id) FROM Pass";
            string get_password = "SELECT * FROM Pass";

            SqlCommand cmd1 = new SqlCommand(get_count, con);
            SqlDataReader count_rows = cmd1.ExecuteReader();
            count_rows.Read();
            int count = int.Parse(count_rows[0].ToString());
            int randPass= rand.Next(1,count+1);
            count_rows.Close();

            SqlCommand cmd2 = new SqlCommand(get_password, con);
            SqlDataReader dr = cmd2.ExecuteReader();
            for (int i = 0; i < randPass; i++)
            {
                dr.Read();
            }
            string? pass = dr[1].ToString();
            dr.Close();
            con.Close();
            return pass.ToUpper();
        }

        private void GameTime()
        {
            dispatcherTimer.Start();
        }
        //---WYŚWIETLANIE POPRAWNEGO FORMATU CZASU---
        private void addSecond(object sender, EventArgs e)
        {
            gameTimeInSeconds += 1;
            int currentTime = gameTimeInSeconds;
            int hours = currentTime / 3600;
            currentTime = currentTime % 3600;
            int minutes = currentTime / 60;
            currentTime = currentTime % 60;
            int seconds = currentTime;

            string time = "";
            time += hours < 10 ? "0" + hours + " : " : hours + " : ";
            time += minutes < 10 ? "0" + minutes + " : " : minutes + " : ";
            time += seconds < 10 ? "0" + seconds : seconds;

            gameBrd.timer_label.Content = $"Timer: " + time;
        }

        //---SPRAWDZANIE WIN CONDITION---
        private void GameWin()
        {
            int score = password.Length * 1000;
            score -= (gameTimeInSeconds * 10);
            gameBrd.score_label.Visibility = Visibility.Visible;
            gameBrd.score_label.IsEnabled = true;
            gameBrd.score_label.Content += score.ToString();
            dispatcherTimer.Stop();
            Add_To_Ranking(score);
        }

        //---DODAWANIE GRACZA I WYNIKU DO RANKINGU
        private void Add_To_Ranking(int sc)
        {
            string query = "INSERT INTO RankingTable (player,score) VALUES ('" + Nickname + "'," + sc + ")";
            SqlConnection con = new SqlConnection(db_connect);
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
