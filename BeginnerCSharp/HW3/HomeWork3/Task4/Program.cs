using System;
using System.Collections.Generic;
using System.Threading;
using static System.Console;

namespace Task4
{
    class Program
    {
        static Random random = new Random();
        static byte block = 1;
        static byte empty = 0;
        static int size = 10;
        static int fieldActualSize = size - 1;
        static byte[,] result = new byte[size, size];

        static void Main(string[] args)
        {
            ClearBoard();

            var isAllShipsPlaced = false;
            bool isFailure = false;
            do
            {
                var shipSize = 4;
                var shipCount = 1;
                for (var i = 0; i < 4; i++)
                {
                    for (var j = 0; j < shipCount; j++)
                    {
                        var direction = Direction.Left;
                                              // Direction.Up,
                                              // Direction.Right,
                                              // Direction.Down


                        var horizontal = direction switch
                                         {
                                             Direction.Left  => random.Next(shipSize - 1, 9),
                                             Direction.Right => random.Next(9 - shipSize + 1),
                                             _               => random.Next(9)
                                         };

                        var vertical = direction switch
                                       {
                                           Direction.Up   => random.Next(shipSize - 1, 9),
                                           Direction.Down => random.Next(9 - shipSize + 1),
                                           _              => random.Next(9)
                                       };

                        if (!CheckShipPlace(direction, vertical, horizontal, shipSize))
                        {
                            isFailure = true;
                            break;
                        }


                        if (!PlaceShip(direction, vertical, horizontal, shipSize))
                        {
                            isFailure = true;
                            break;
                        }

                        WriteLine($"ship size {shipSize}\n");
                    }

                    if (isFailure) break;
                    shipCount++;
                    shipSize--;
                }

                if (isFailure)
                {
                    WriteLine($"ship size {shipSize}\n");
                    isFailure = false;
                    ClearBoard();
                }
                else
                {
                    isAllShipsPlaced = true;
                }
            } while (!isAllShipsPlaced);

            PrintBoard();
            ReadLine();
        }

        static void ClearBoard()
        {
            for (var i = 0; i < size; i++)
            for (var j = 0; j < size; j++)
                result[i, j] = empty;
        }

        static void PrintBoard()
        {
            Clear();
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    Write(result[i, j] + " ");
                }

                WriteLine();
            }

            Thread.Sleep(100);
        }

        static bool PlaceShip(Direction direction, int vertical, int horizontal, int shipSize)
        {
            do
            {
                result[vertical, horizontal] = block;
                switch (direction)
                {
                    case Direction.Up:
                        if (horizontal - 1 < 0) return false;
                        horizontal--;
                        break;
                    case Direction.Down:
                        if (horizontal + 1 >= 9) return false;
                        horizontal++;
                        break;
                    case Direction.Left:
                        if (vertical - 1 < 0) return false;
                        vertical--;
                        break;
                    case Direction.Right:
                        if (vertical + 1 >= 9) return false;
                        vertical++;
                        break;
                }
            } while (--shipSize > 0);

            return true;
        }

        static bool CheckPoint(int vertical, int horizontal)
        {
            List<byte> checkArray = new List<byte>();
            var downVert = vertical - 1;
            var upVert = vertical + 1;
            var downHor = horizontal - 1;
            var upHor = horizontal + 1;

            try
            {
                if (downVert >= 0 && downHor >= 0) checkArray.Add(result[downVert, downHor]);
                if (downHor >= 0) checkArray.Add(result[vertical, downHor]);
                if (upVert <= fieldActualSize && downHor >= 0) checkArray.Add(result[upVert, downHor]);
                if (upVert <= fieldActualSize) checkArray.Add(result[upVert, horizontal]);
                if (upVert <= fieldActualSize && upHor <= fieldActualSize) checkArray.Add(result[upVert, upHor]);
                if (upHor <= fieldActualSize) checkArray.Add(result[vertical, upHor]);
                if (downVert >= 0 && upHor <= fieldActualSize) checkArray.Add(result[downVert, upHor]);
                if (downVert >= 0) checkArray.Add(result[downVert, horizontal]);
            }
            catch (Exception)
            {
                WriteLine($"vertical {vertical}, horizontal {horizontal}");
                throw;
            }


            for (var i = 0; i < checkArray.Count; i++)
            {
                if (checkArray[i] == block)
                    return false;
            }

            return true;
        }

        static bool CheckShipPlace(Direction direction, int x, int y, int shipSize)
        {
            if (result[x, y] == block) return false;
            switch (direction)
            {
                case Direction.Up:
                    for (var i = 0; i < shipSize; i++)
                    {
                        if (y + i > fieldActualSize) return false;
                        if (!CheckPoint(x, y += i)) return false;
                    }

                    return true;
                case Direction.Down:
                    for (var i = 0; i < shipSize; i++)
                    {
                        if (y - i < 0) return false;
                        if (!CheckPoint(x, y -= i)) return false;
                    }

                    return true;
                case Direction.Left:
                    for (var i = 0; i < shipSize; i++)
                    {
                        if (x - i < 0) return false;
                        if (!CheckPoint(x -= i, y)) return false;
                    }

                    return true;
                case Direction.Right:
                    for (var i = 0; i < shipSize; i++)
                    {
                        if (x + i < fieldActualSize) return false;
                        if (!CheckPoint(x += i, y)) return false;
                    }

                    return true;
                default:
                    return false;
            }
        }
    }

    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}