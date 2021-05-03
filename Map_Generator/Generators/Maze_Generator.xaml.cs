using System;
using System.Collections.Generic;
using System.Windows;
using Map_Generator.Classes;
using static Map_Generator.Classes.Variables;
using static Map_Generator.Classes.ConvertMap;

namespace Map_Generator.Generators
{
    public partial class MazeGenerator
    {
        [Flags]
        public enum Direction
        {
            North = 1,
            East = 2,
            South = 4,
            West = 8,
            Visited = 16,
            Start = 32,
            Finish = 64
        }

        public readonly PrintMap Pm = new PrintMap();
        public Direction[,] Maze;
        public int[,] MazeS;
        public Stack<Tuple<int, int>> Path = new Stack<Tuple<int, int>>();

        public MazeGenerator()
        {
            InitializeComponent();
        }

        private void BtnGenerate(object sender, RoutedEventArgs e)
        {
            MapHeight = MapWidth = 10;
            CellWidth = CellHeight = 8;
            Maze = new Direction[MapWidth, MapHeight];
            MazeS = new int[MapWidth, MapHeight];

            MapView.Source = ConvertToBitmapImage(Pm.Print_Maze(Carve(Maze)));
        }

        public Direction[,] Carve(Direction[,] maze)
        {
            var rng = new Random();

            var sx = rng.Next(MapWidth);
            var sy = rng.Next(MapHeight);

            Path.Push(Tuple.Create(sx, sy));
            maze[sx, sy] = Direction.Visited;
            var visited = 1;

            while (visited < MapHeight * MapWidth)
            {
                var (x, y) = Path.Peek();

                var availableCells = new List<int> {Capacity = 4};

                if (Path.Peek().Item2 > 0 && !maze[x, y - 1].HasFlag(Direction.Visited))
                    availableCells.Add(0);

                if (Path.Peek().Item1 < MapWidth - 1 && !maze[x + 1, y].HasFlag(Direction.Visited))
                    availableCells.Add(1);

                if (Path.Peek().Item2 < MapHeight - 1 && !maze[x, y + 1].HasFlag(Direction.Visited))
                    availableCells.Add(2);

                if (Path.Peek().Item1 > 0 && !maze[x - 1, y].HasFlag(Direction.Visited))
                    availableCells.Add(3);

                if (availableCells.Count != 0)
                {
                    var randDir = availableCells[rng.Next(availableCells.Count)];

                    switch (randDir)
                    {
                        case 0:
                            maze[x, y - 1] |= Direction.Visited | Direction.South;
                            maze[x, y] |= Direction.North;
                            Path.Push(Tuple.Create(x, y - 1));
                            break;
                        case 1:
                            maze[x + 1, y] |= Direction.Visited | Direction.West;
                            maze[x, y] |= Direction.East;
                            Path.Push(Tuple.Create(x + 1, y));
                            break;
                        case 2:
                            maze[x, y + 1] |= Direction.Visited | Direction.North;
                            maze[x, y] |= Direction.South;
                            Path.Push(Tuple.Create(x, y + 1));
                            break;
                        case 3:
                            maze[x - 1, y] |= Direction.Visited | Direction.East;
                            maze[x, y] |= Direction.West;
                            Path.Push(Tuple.Create(x - 1, y));
                            break;
                    }

                    visited++;
                    availableCells.Clear();
                }
                else
                    Path.Pop();
                
            }

            Maze[0, 0] = Direction.Start;
            Maze[MapWidth - 2, MapHeight - 2] = Direction.Finish;
            return maze;
        }

        public bool Solve(Direction[,] maze)
        {
            int sx = 0, sy = 0;
            int fx = MapWidth - 2, fy = MapHeight - 2;

            Stack<Tuple<int, int>> solution = new Stack<Tuple<int, int>>();
            solution.Push(Tuple.Create(sx, sy));

            while (solution.Count != 0)
            {
                var (x, y) = Path.Peek();
                Direction dir = maze[x, y];

                if (dir.HasFlag(Direction.North))
                    dir = Direction.East;
                else if (dir.HasFlag(Direction.East))
                    dir = Direction.South;
                else if (dir.HasFlag(Direction.South))
                    dir = Direction.West;
                else if (dir.HasFlag(Direction.West))
                    dir = Direction.North;

                if (x == fx && y == fy)
                    return true;

                if (dir == Direction.West && y - 1 >= 0 && !maze[x, y - 1].HasFlag(Direction.Visited))
                    solution.Push(Tuple.Create(x, y - 1));
              
                else if (dir == Direction.South && x + 1 < MapHeight && !maze[x + 1, y].HasFlag(Direction.Visited))
                    solution.Push(Tuple.Create(x + 1, y));

                else if (dir == Direction.East && y + 1 < MapWidth && !maze[x, y + 1].HasFlag(Direction.Visited))
                    solution.Push(Tuple.Create(x, y + 1));

                else if (dir == Direction.North && x - 1 >= 0 && !maze[x - 1, y].HasFlag(Direction.Visited))
                    solution.Push(Tuple.Create(x - 1, y));
                else
                    solution.Pop();
                
            }

            return false;
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