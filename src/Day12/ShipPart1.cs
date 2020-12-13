using System;
using System.Collections.Generic;

namespace Day12
{
    public class ShipPart1 : AbstractShip
    {
        private int pos = 1; // 0 = north, 1 = east, 2 = south, 3 = west

        public override void ProcessAction(string action, int value)
        {
            switch (action)
            {
                case "N":
                    Y += value;
                    break;
                case "S":
                    Y -= value;
                    break;
                case "E":
                    X += value;
                    break;
                case "W":
                    X -= value;
                    break;
                case "L":
                    pos = (pos + ((360 - value) / 90)) % 4;
                    break;
                case "R":
                    pos = (pos + (value / 90)) % 4;
                    break;
                case "F":
                    switch (pos)
                    {
                        case 0:
                            Y += value;
                            break;
                        case 1:
                            X += value;
                            break;
                        case 2:
                            Y -= value;
                            break;
                        case 3:
                            X -= value;
                            break;
                        default:
                            throw new InvalidOperationException($"Unexpected pos: {pos}");
                    }
                    break;
                default:
                    throw new ArgumentException($"Unexpected action: {action}");
            }
        }
    }
}
