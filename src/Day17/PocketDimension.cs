using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day17
{
    public class PocketDimension
    {
        /// <summary>
        /// Gets or sets whether the pocket dimension contains cubes (i.e. 3-dimensional space) or
        /// hypercubes (i.e. 4-dimension space).
        /// </summary>
        public bool Hyper { get; set; }

        private HashSet<Point> _activeCubesSet;

        private PocketDimension(HashSet<Point> activeCubesSet) =>
            _activeCubesSet = activeCubesSet;

        /// <summary>Returns the number of active cubes in the pocket dimension.</summary>
        public int ActiveCubes => _activeCubesSet.Count;

        /// <summary>Returns a copy of the PocketDimension instance.</summary>
        public PocketDimension Clone() =>
            new PocketDimension(_activeCubesSet.ToHashSet())
            {
                Hyper = Hyper,
            };

        /// <summary>
        /// Initializes a new PocketDimension from a string representing a 2D slice of space.
        /// </summary>
        public static PocketDimension FromString(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var activeCubesSet = new HashSet<Point>();

            int y = 0;
            foreach (string line in input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
            {
                int x = 0;
                foreach (char c in line.ToCharArray())
                {
                    if (c == '#')
                    {
                        activeCubesSet.Add(new Point(x, y, 0, 0));
                    }
                    x++;
                }
                y++;
            }

            return new PocketDimension(activeCubesSet);
        }

        /// <summary>Executes a number of cycles.</summary>
        public void Step(int n = 1)
        {
            foreach (int _ in Enumerable.Range(0, n))
            {
                SingleStep();
            }
        }

        /// <summary>
        /// Executes a single cycle, and returns <c>true</c> if the pocket dimension changed or
        /// <c>false</c> if nothing changed.
        /// </summary>
        private bool SingleStep()
        {
            if (_activeCubesSet.Count == 1)
            {
                return false;
            }

            int x0 = _activeCubesSet.Select(p => p.x).Min() - 1;
            int x1 = _activeCubesSet.Select(p => p.x).Max() + 1;
            int y0 = _activeCubesSet.Select(p => p.y).Min() - 1;
            int y1 = _activeCubesSet.Select(p => p.y).Max() + 1;
            int z0 = _activeCubesSet.Select(p => p.z).Min() - 1;
            int z1 = _activeCubesSet.Select(p => p.z).Max() + 1;
            int w0 = Hyper ? _activeCubesSet.Select(p => p.w).Min() - 1 : 0;
            int w1 = Hyper ? _activeCubesSet.Select(p => p.w).Max() + 1 : 0;

            var newActiveCubesSet = new HashSet<Point>();

            foreach (int w in Enumerable.Range(w0, w1 - w0 + 1))
            {
                foreach (int z in Enumerable.Range(z0, z1 - z0 + 1))
                {
                    foreach (int y in Enumerable.Range(y0, y1 - y0 + 1))
                    {
                        foreach (int x in Enumerable.Range(x0, x1 - x0 + 1))
                        {
                            Point p = new Point(x, y, z, w);
                            bool isActive = _activeCubesSet.Contains(p);
                            int activeNeighbors = ActiveNeighbors(p);

                            if (isActive && (activeNeighbors == 2 || activeNeighbors == 3))
                            {
                                newActiveCubesSet.Add(p);
                            }
                            else if (!isActive && activeNeighbors == 3)
                            {
                                newActiveCubesSet.Add(p);
                            }
                        }
                    }
                }
            }

            bool result = _activeCubesSet != newActiveCubesSet;
            _activeCubesSet = newActiveCubesSet;
            return result;
        }

        /// <summary>
        /// Returns a string representing the contents of the pocket dimension.
        /// </summary>
        public string PrettyPrint()
        {
            int x0 = _activeCubesSet.Select(p => p.x).Min();
            int x1 = _activeCubesSet.Select(p => p.x).Max();
            int y0 = _activeCubesSet.Select(p => p.y).Min();
            int y1 = _activeCubesSet.Select(p => p.y).Max();
            int z0 = _activeCubesSet.Select(p => p.z).Min();
            int z1 = _activeCubesSet.Select(p => p.z).Max();
            int w0 = Hyper ? _activeCubesSet.Select(p => p.w).Min() : 0;
            int w1 = Hyper ? _activeCubesSet.Select(p => p.w).Max() : 0;

            StringBuilder sb = new StringBuilder();

            foreach (int w in Enumerable.Range(w0, w1 - w0 + 1))
            {
                foreach (int z in Enumerable.Range(z0, z1 - z0 + 1))
                {
                    sb.Append($"z={z}");
                    if (Hyper)
                    {
                        sb.Append($", w={w}");
                    }
                    sb.Append('\n');
                    foreach (int y in Enumerable.Range(y0, y1 - y0 + 1))
                    {
                        foreach (int x in Enumerable.Range(x0, x1 - x0 + 1))
                        {
                            sb.Append(_activeCubesSet.Contains(new Point(x, y, z, w)) ? '#' : '.');
                        }
                        sb.Append('\n');
                    }
                    sb.Append('\n');
                }
            }

            return sb.ToString();
        }

        /// <summary>Returns the number of active cubes around a specific point.</summary>
        private int ActiveNeighbors(Point p) =>
            p.Neighbors(Hyper).Where(p => _activeCubesSet.Contains(p)).Count();

        /// <summary>Represents a point in 4-dimensional space.</summary>
        private record Point(int x, int y, int z, int w)
        {
            /// <summary>
            /// Iterator method that returns all points around a point in 3 or 4-dimensional space.
            /// </summary>
            /// <param name="hyper">
            /// Iterate in 3 dimensions if <c>false</c> or 4 dimensions if <c>true</c>.
            /// </param>
            public IEnumerable<Point> Neighbors(bool hyper)
            {
                foreach (int iw in Enumerable.Range(hyper ? w - 1 : 0, hyper ? 3 : 1))
                {
                    foreach (int iz in Enumerable.Range(z - 1, 3))
                    {
                        foreach (int iy in Enumerable.Range(y - 1, 3))
                        {
                            foreach (int ix in Enumerable.Range(x - 1, 3))
                            {
                                if ((ix == x) && (iy == y) && (iz == z) && (iw == w))
                                {
                                    continue;
                                }

                                yield return new Point(ix, iy, iz, iw);
                            }
                        }
                    }
                }
            }
        }
    }
}
