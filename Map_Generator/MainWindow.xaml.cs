using System;
using System.Threading;
using System.Windows;
using System.Windows.Media.Animation;
using Map_Generator.Classes;

namespace Map_Generator
{
    public partial class MainWindow
    {
        private readonly MySQLconnect _sqlconnect;

        public MainWindow()
        {
            InitializeComponent();
            _sqlconnect = new MySQLconnect();

            _sqlconnect.Connect();
        }

        private void BtnClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMinimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnLogin(object sender, RoutedEventArgs e)
        {
            if (TxtUsername.Text == "" || TxtPassword.Text == "")
                MessageBox.Show("Please enter a username and/or password");
            else
            {
                if (_sqlconnect.Login(TxtUsername.Text, TxtPassword.Text))
                {
                    var sb = FindResource("Login") as Storyboard;
                    sb.Completed += sb_CompletedBL;
                    sb.Begin();
                }
                else
                {
                    MessageBox.Show("Username and/or password are incorrect");
                    TxtUsername.Text = "";
                    TxtPassword.Text = "";
                }
            }
        }

        private void BtnCreate(object sender, RoutedEventArgs e)
        {
            var sb = FindResource("Login") as Storyboard;
            sb.Completed += sb_CompletedC;
            sb.Begin();
        }

        private void BtnBrooker(object sender, RoutedEventArgs e)
        {
            var sb = FindResource("Login") as Storyboard;
            sb.Completed += sb_CompletedBL;
            sb.Begin();
        }

        private void sb_CompletedBL(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            var gt = new GenerationType();
            Hide();
            gt.Show();
        }

        private void sb_CompletedC(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            var ca = new CreateAccount();
            Hide();
            ca.Show();
        }
    }
}