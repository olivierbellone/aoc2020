using System;
using System.Collections.Generic;

namespace Day12
{
    public class ShipPart2 : AbstractShip
    {
        private int pos = 1; // 0 = north, 1 = east, 2 = south, 3 = west

        private int wayX = 10;
        private int wayY = 1;

        private static IDictionary<int, int> cos = new Dictionary<int, int>
        {
            {0, 1},
            {90, 0},
            {180, -1},
            {270, 0},
        };

        private static IDictionary<int, int> sin = new Dictionary<int, int>
        {
            {0, 0},
            {90, 1},
            {180, 0},
            {270, -1},
        };

        public override void ProcessAction(string action, int value)
        {
            switch (action)
            {
                case "N":
                    wayY += value;
                    break;
                case "S":
                    wayY -= value;
                    break;
                case "E":
                    wayX += value;
                    break;
                case "W":
                    wayX -= value;
                    break;
                case "L":
                    (wayX, wayY) = Rotate(wayX, wayY, value);
                    break;
                case "R":
                    (wayX, wayY) = Rotate(wayX, wayY, 360 - value);
                    break;
                case "F":
                    switch (pos)
                    {
                        case 0:
                            X -= value * wayX;
                            Y += value * wayY;
                            break;
                        case 1:
                            X += value * wayX;
                            Y += value * wayY;
                            break;
                        case 2:
                            X += value * wayX;
                            Y -= value * wayY;
                            break;
                        case 3:
                            X -= value * wayX;
                            Y -= value * wayY;
                            break;
                        default:
                            throw new InvalidOperationException($"Unexpected pos: {pos}");
                    }
                    break;
                default:
                    throw new ArgumentException($"Unexpected action: {action}");
            }
        }

        private static (int, int) Rotate(int x, int y, int angle)
        {
            int c = cos[angle];
            int s = sin[angle];
            int newX = (x * c) - (y * s);
            int newY = (x * s) + (y * c);
            return (newX, newY);
        }
    }
}
