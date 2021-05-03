using System;
using System.Windows;
using Map_Generator.Classes;
using static Map_Generator.Classes.Variables;
using static Map_Generator.Classes.ConvertMap;

namespace Map_Generator.Generators
{
    public partial class CellularGenerator
    {
        private readonly PrintMap _pm = new PrintMap();

        public CellularGenerator()
        {
            InitializeComponent();
        }

        private void BtnGenerate(object sender, RoutedEventArgs e)
        {
            CellWidth = CellHeight = 8;
            MapWidth = 50;
            MapHeight = 50;
            SurvivalChance = (100 - Convert.ToDecimal(67)) / 100;

            var generated = new int[MapWidth, MapHeight];

            MapView.Source = ConvertToBitmapImage(_pm.Print_Cell(Processing(Init(generated))));
        }

        private int[,] Init(int[,] terrain)
        {
            var cell = new Random();

            for (var x = 0; x < MapWidth; x++)
                for (var y = 0; y < MapHeight; y++)
                    if (cell.NextDouble() < Convert.ToDouble(SurvivalChance))
                        terrain[x, y] = 1;
                    else
                        terrain[x, y] = 0;


            return terrain;
        }

        public static int CountNeighbours(int[,] generated, int x, int y)
        {
            var count = 0;

            for (var i = -1; i < 2; i++)
                for (var j = -1; j < 2; j++)
                {
                    var nx = x + i;
                    var ny = y + j;
                    if (nx < 0 || ny < 0 || nx >= MapWidth || ny >= MapHeight)
                        count++;
                    else if (generated[nx, ny] == 1)
                        count++;
                }

            return count;
        }

        private int[,] Processing(int[,] generated)
        {
            double j;
            var _ = (double) SurvivalChance > 0.61 && (double) SurvivalChance < 0.74 ? j = 10 :
                (double) SurvivalChance > 0.49 && (double) SurvivalChance < 0.61 ? j = 1000 : j = 5;

            for (var i = 0; i < j; i++)
                for (var x = 0; x < MapWidth; x++)
                    for (var y = 0; y < MapHeight; y++)
                    {
                        var neighbours = CountNeighbours(generated, x, y);

                        if (generated[x, y] == 1)
                        {
                            if (neighbours < DeathRule)
                                generated[x, y] = 0;
                            else
                                generated[x, y] = 1;
                        }
                        else
                        {
                            if (neighbours > BirthRule)
                                generated[x, y] = 1;

                            else
                                generated[x, y] = 0;
                        }
                    }

            return generated;
        }

        private void BtnMinimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnBack(object sender, RoutedEventArgs e)
        {
            var gt = new GenerationType();
            Close();
            gt.Show();
        }
    }
}