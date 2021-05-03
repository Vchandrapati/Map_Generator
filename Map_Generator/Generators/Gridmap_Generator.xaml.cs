using System;
using System.Collections.Generic;
using System.Windows;
using Map_Generator.Classes;
using static Map_Generator.Classes.Variables;
using static Map_Generator.Classes.ConvertMap;

namespace Map_Generator.Generators
{
    public partial class GridmapGenerator
    {
        public enum Terrain
        {
            Snow = 2,
            Grassland = 73,
            Forest = 20,
            Lake = 5
        }

        private readonly List<int> _terrain = new List<int>();

        private readonly PrintMap _pm = new PrintMap();

        public GridmapGenerator()
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
            WeightedList();
            MapView.Source = ConvertToBitmapImage(_pm.Print_Grid(Init(generated)));
        }

        private int[,] Init(int[,] generated)
        {
            var getType = new Random();

                for (var x = 0; x < MapWidth; x++)
                    for (var y = 0; y < MapHeight; y++)
                    {
                        var type = _terrain[getType.Next(_terrain.Count)];

                        switch (type)
                        {
                            case 0:
                                generated[x, y] = 0;
                                break;
                            case 1:
                                generated[x, y] = 1;
                                break;
                            case 2:
                                generated[x, y] = 2;
                                break;
                            case 3:
                                generated[x, y] = 3;
                                break;
                        }
                    }

            return generated;
        }

        private void WeightedList()
        {
            for (var i = 0; i < (int) Terrain.Snow; i++)
                _terrain.Add(0);
            for (var i = 0; i < (int) Terrain.Grassland; i++)
                _terrain.Add(1);
            for (var i = 0; i < (int) Terrain.Lake; i++)
                _terrain.Add(2);
            for (var i = 0; i < (int) Terrain.Forest; i++)
                _terrain.Add(3);
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