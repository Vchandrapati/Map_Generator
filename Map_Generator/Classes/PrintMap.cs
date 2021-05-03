using System.Drawing;
using Map_Generator.Generators;
using static Map_Generator.Classes.Variables;

namespace Map_Generator.Classes
{
    public class PrintMap
    {
        public Bitmap Print_Cell(int[,] generated)
        {
            var cellMap = new Bitmap(MapWidth * CellWidth, MapHeight * CellHeight);
            using (var pMap = Graphics.FromImage(cellMap))
            {
                for (var x = 0; x < MapWidth; x++)
                    for (var y = 0; y < MapHeight; y++)
                        pMap.FillRectangle(
                            generated[x, y] == 1 ? Brushes.Black : Brushes.White, x * CellWidth, y * CellHeight, CellWidth,
                            CellHeight);
            }

            return cellMap;
        }

        public Bitmap Print_Grid(int[,] generated)
        {
            var map = new Bitmap(MapWidth * CellWidth, MapHeight * CellHeight);
            using (var pMap = Graphics.FromImage(map))
            {
                pMap.Clear(Color.Black);
                for (var x = 0; x < MapHeight; x++)
                    for (var y = 0; y < MapWidth; y++)
                        switch (generated[x, y])
                        {
                            case 0:
                                pMap.FillRectangle(Brushes.WhiteSmoke, x * CellWidth, y * CellHeight, CellWidth,
                                    CellHeight);
                                break;
                            case 1:
                                pMap.FillRectangle(Brushes.GreenYellow, x * CellWidth, y * CellHeight, CellWidth,
                                    CellHeight);
                                break;
                            case 2:
                                pMap.FillRectangle(Brushes.DeepSkyBlue, x * CellWidth, y * CellHeight, CellWidth,
                                    CellHeight);
                                break;
                            case 3:
                                pMap.FillRectangle(Brushes.Green, x * CellWidth, y * CellHeight, CellWidth, CellHeight);
                                break;
                        }
            }

            return map;
        }

        public Bitmap Print_Maze(MazeGenerator.Direction[,] Maze)
        {
            CellWidth = CellHeight = 8;
            var maze = new Bitmap(MapWidth * CellWidth, MapHeight * CellHeight);
            using (var pMap = Graphics.FromImage(maze))
            {
                for (var x = 0; x < MapWidth; x++)
                    for (var y = 0; y < MapHeight; y++)
                    {
                        for (int cy = 0; cy < CellHeight; cy++)
                            for (int cx = 0; cx < CellWidth; cx++)
                            {
                                if (Maze[x, y].HasFlag(MazeGenerator.Direction.Visited))
                                    pMap.FillRectangle(Brushes.Black, x * (CellWidth + 1) + cx, y * (CellHeight + 1) + cy,
                                        CellWidth, CellHeight);
                                else if (Maze[x, y].HasFlag(MazeGenerator.Direction.Start))
                                    pMap.FillRectangle(Brushes.Green, x * (CellWidth + 1) + cx, y * (CellHeight + 1) + cy,
                                        CellWidth, CellHeight);
                                else if (Maze[x, y].HasFlag(MazeGenerator.Direction.Finish))
                                    pMap.FillRectangle(Brushes.Red, x * (CellWidth + 1) + cx, y * (CellHeight + 1) + cy,
                                        CellWidth, CellHeight);
                            }

                        for (int p = 0; p < CellWidth; p++)
                        {
                            if (Maze[x, y].HasFlag(MazeGenerator.Direction.South))
                                pMap.FillRectangle(Brushes.White, x * (CellWidth + 1) + p, y * (CellHeight + 1) + CellWidth, CellWidth, CellHeight);

                            if (Maze[x, y].HasFlag(MazeGenerator.Direction.East))
                                pMap.FillRectangle(Brushes.White, x * (CellWidth + 1) + CellWidth, y * (CellWidth + 1) + p, CellWidth, CellHeight);
                        }
                    }
            }

            return maze;
        }
    }
}