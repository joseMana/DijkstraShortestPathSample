using System;
using System.Collections.Generic;
using static System.Console;

namespace DijkstraShortestPathSample
{
    
    class Program
    {
        public static int GRID_SCALE = 50;
        public static Position ENDGAME_POS = Position.CreatePosition();
        public static Position PLAYER_POS = Position.CreatePosition();
        static void Main(string[] args)
        {
            WriteLine($"Destination: {ENDGAME_POS}");
            WriteLine($"Current Position: {PLAYER_POS}\n\n");

            for (int i = 0; i < 50; i++)
            {
                if ((PLAYER_POS.X == ENDGAME_POS.X) && (PLAYER_POS.Y == ENDGAME_POS.Y))
                {
                    WriteLine("Reached Destination");
                }

                GetPath();
            }
        }

        private static void GetPath()
        {
            var neighbors = new List<Position>
            {
                new Position{ X=PLAYER_POS.X + 0, Y=PLAYER_POS.Y+1 },
                new Position{ X=PLAYER_POS.X + 1, Y=PLAYER_POS.Y+1 },
                new Position{ X=PLAYER_POS.X + 1, Y=PLAYER_POS.Y+0 },
                new Position{ X=PLAYER_POS.X + 1, Y=PLAYER_POS.Y-1 },
                new Position{ X=PLAYER_POS.X + 0, Y=PLAYER_POS.Y-1 },
                new Position{ X=PLAYER_POS.X - 1, Y=PLAYER_POS.Y-1 },
                new Position{ X=PLAYER_POS.X - 1, Y=PLAYER_POS.Y+0 },
                new Position{ X=PLAYER_POS.X - 1, Y=PLAYER_POS.Y+1 },

            };

            Position best = new Position();
            double min = 100000000000000;
            for (var i = 0; i < neighbors.Count; i++)
            {
                if (GetDistance(neighbors[i], ENDGAME_POS) < min /*&& !isNotObstacle(neighbors[i])*/)
                {
                    best = neighbors[i];
                    min = GetDistance(neighbors[i], ENDGAME_POS);
                }
            }

            PLAYER_POS = best;
            WriteLine($"Current Position moved to {PLAYER_POS}");
        }

        private static double GetDistance(Position position1, Position position2)
        {
            var xs = position2.X - position1.X;
            xs = xs * xs;
            var ys = position2.Y - position1.Y;
            ys = ys * ys;
            var dist = Math.Sqrt(xs + ys);

            return dist;
        }
        public struct Position
        {
            public int X { get; set; }
            public int Y { get; set; }
            public static Position CreatePosition()
            {
                return new Position
                {
                    X = new Random().Next(0, GRID_SCALE),
                    Y = new Random().Next(0, GRID_SCALE)
                };
            }
            public override string ToString()
            {
                return $"X = {X}, Y = {Y}";
            }
        }
    }
}


