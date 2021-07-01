using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife
{
    public class Obstacle
    {
        public static string DefaultObstacleImg { get { return "#"; } }

        public Coordinate coordinate { get; set; }

        public Obstacle(Coordinate coordinate)
        {
            this.coordinate = coordinate;
        }
    }
}
