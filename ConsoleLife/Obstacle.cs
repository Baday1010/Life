using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    public class Obstacle : Cell
    {
        public static string DefaultObstacleImg { get { return "#"; } }

        public Obstacle(Coordinate coordinate)
        {
            this.coordinate = coordinate;
        }
    }
}
