using System;
using System.Threading;
using static System.Console;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var block = 'X';
            var empty = 'O';
            var size = 10;
            var result = new char[10,10]
            {
                {empty,empty,empty,empty,empty,empty,empty,empty,empty,empty},
                {empty,empty,empty,empty,empty,empty,empty,empty,empty,empty},
                {empty,empty,empty,empty,empty,empty,empty,empty,empty,empty},
                {empty,empty,empty,empty,empty,empty,empty,empty,empty,empty},
                {empty,empty,empty,empty,empty,empty,empty,empty,empty,empty},
                {empty,empty,empty,empty,empty,empty,empty,empty,empty,empty},
                {empty,empty,empty,empty,empty,empty,empty,empty,empty,empty},
                {empty,empty,empty,empty,empty,empty,empty,empty,empty,empty},
                {empty,empty,empty,empty,empty,empty,empty,empty,empty,empty},
                {empty,empty,empty,empty,empty,empty,empty,empty,empty,empty}
            };
            
            void PrintBoard()
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
            
            bool PlaceShip(Direction direction, int x, int y, int shipSize)
            {
                do
                {
                    
                    result[x, y] = block;
                    switch (direction)
                    {
                        case Direction.Up:
                            if (y - 1 < 0) return false;
                            y--;
                            break;
                        case Direction.Down:
                            if (y + 1 >= 9) return false;
                            y++;
                            break;
                        case Direction.Left:
                            if (x - 1 < 0) return false;
                            x--;
                            break;
                        case Direction.Right:
                            if (x + 1 >= 9) return false;
                            x++;
                            break;
                    }
                } while (--shipSize>0);

                return true;
            }

            bool CheckPoint(int x, int y)
            {
                var isFailPoint = false;
                if (x > 0 && y > 0 &&  result[x - 1, y - 1] == block) isFailPoint = true;
                else if (y > 0 && result[x, y - 1] == block) isFailPoint = true;
                else if (x < 9 && y > 0 && result[x + 1, y - 1] == block) isFailPoint = true;
                else if (x < 9 && result[x + 1, y] == block) isFailPoint = true;
                else if (x < 9 && y < 9 && result[x + 1, y + 1] == block) isFailPoint = true;
                else if (x > 0 && y < 9 && result[x - 1, y + 1] == block) isFailPoint = true;
                else if (x > 0 && result[x - 1, y] == block) isFailPoint = true;

                return isFailPoint;
            }

            bool CheckShipPlace(Direction direction, int x, int y, int shipSize)
            {
                if (result[x, y] == block) return false;
                switch (direction)
                {
                    case Direction.Up:
                        for (var i = 0; i < shipSize; i++)
                        {
                            if (!CheckPoint(x, y += i)) return false;
                        }
                        return true;
                    case Direction.Down:
                        for (var i = 0; i < shipSize; i++)
                        {
                            if (!CheckPoint(x, y -= i)) return false;
                        }
                        return true;
                    case Direction.Left:
                        for (var i = 0; i < shipSize; i++)
                        {
                            if (!CheckPoint(x -= i, y)) return false;
                        }
                        return true;
                    case Direction.Right:
                        for (var i = 0; i < shipSize; i++)
                        {
                            if (!CheckPoint(x += i, y)) return false;
                        }
                        return true;
                    default:
                        return false;
                }
            }
            
            var isAllShipsPlaced = false;
            do
            {
                bool isFailure = false;
                var shipSize = 4;
                var shipCount = 1;
                for (var i = 0; i < 4; i++)
                {
                    
                    for (var j = 0; j < shipCount; j++)
                    {
                        var direction = random.Next(100) switch
                                        {
                                            <25 => Direction.Left,
                                            <50 => Direction.Up,
                                            <75 => Direction.Right,
                                            _   => Direction.Down
                                        };
                        
                             
                        
                        var x = direction switch
                                {
                                    Direction.Left  => random.Next(shipSize,9),
                                    Direction.Right => random.Next(9-shipSize),
                                    _               => random.Next(9)
                                };
                        
                        var y = direction switch
                                {
                                    Direction.Up   => random.Next(shipSize,9),
                                    Direction.Down => random.Next(9-shipSize),
                                    _              => random.Next(9)
                                };

                        if (!CheckShipPlace(direction, y, x, shipSize))
                        {
                            isFailure = true;
                            break;
                        }


                        if (!PlaceShip(direction, y, x, shipSize))
                        {
                            isFailure = true;
                            break;
                        }
                        PrintBoard();
                    }
                    
                    if(isFailure) break;
                    shipCount++;
                    shipSize--;
                }

                if (isFailure)
                {
                    PrintBoard();
                }
                else
                {
                    isAllShipsPlaced = true;
                }
            } while (!isAllShipsPlaced);

            PrintBoard();
            ReadLine();
        }
    }

    enum Direction
    {
        Up,Down,Left,Right
    }
}