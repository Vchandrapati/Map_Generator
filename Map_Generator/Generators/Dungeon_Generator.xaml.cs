using System.Windows;

namespace Map_Generator.Generators
{
    public partial class DungeonGenerator : Window
    {
        public DungeonGenerator()
        {
            InitializeComponent();
        }
        private void btnBack(object sender, RoutedEventArgs e)
        {
            GenerationType gt = new GenerationType();
            this.Close();
            gt.Show();
        }
        private void btnClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnMinimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnGenerate(object sender, RoutedEventArgs e)
        {

        }
    }
}
