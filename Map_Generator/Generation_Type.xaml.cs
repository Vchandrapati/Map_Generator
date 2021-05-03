using System.Windows;
using Map_Generator.Generators;

namespace Map_Generator
{
    public partial class GenerationType : Window
    {
        public GenerationType()
        {
            InitializeComponent();
        }
        private void Cell_Generator(object sender, RoutedEventArgs e)
        {
            var cg = new CellularGenerator();
            this.Close();
            cg.Show();
        }
        private void BtnMinimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void BtnClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Grid_Generator(object sender, RoutedEventArgs e)
        {
            GridmapGenerator gg = new GridmapGenerator();
            this.Close();
            gg.Show();
        }
        private void Dungeon_Generator(object sender, RoutedEventArgs e)
        {
            DungeonGenerator dg = new DungeonGenerator();
            this.Close();
            dg.Show();
        }

        private void Maze_Generator(object sender, RoutedEventArgs e)
        {
            MazeGenerator mg = new MazeGenerator();
            this.Close();
            mg.Show();
        }
    }
}
