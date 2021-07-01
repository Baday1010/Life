using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife
{
    public class Predator
    {
        public Coordinate coordinate { get; set; }

        public int TimeToReproduce { get; set; } = 6;

        public int TimeToFeed { get; set; } = 6;

        public static string DefaultPredatorImg { get { return "S"; } }

        public void GetPreyNeighborCoord()
        {

        }

        public void Process()
        {

        }

        public void MoveFrom(int from, int to)
        {

        }

        public void Reproduce(Coordinate coordinate)
        {

        }

        public Predator(Coordinate coordinate)
        {
            this.coordinate = coordinate;
        }
    }
}
