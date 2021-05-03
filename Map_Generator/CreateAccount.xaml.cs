using System.Threading;
using System.Windows;
using Map_Generator.Classes;

namespace Map_Generator
{
    public partial class CreateAccount
    {
        private readonly MySQLconnect _sqlconnect;

        public CreateAccount()
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

        private void Login(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCreate(object sender, RoutedEventArgs e)
        {
            if (TxtUsername.Text == "" || TxtPassword.Text == "")
            {
                MessageBox.Show("Please enter your username and/or password");
                return;
            }

            _sqlconnect.CreateUser(TxtUsername.Text, TxtPassword.Text);
            MessageBox.Show("Account successfully created");
            Thread.Sleep(500);

            var mw = new MainWindow();
            Close();
            mw.Show();
        }

        private void BtnBack(object sender, RoutedEventArgs e)
        {
            var mw = new MainWindow();
            Close();
            mw.Show();
        }
    }
}