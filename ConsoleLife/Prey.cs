using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife
{
    public class Prey
    {
        public Coordinate coordinate { get; set; }
        public int TimeToReproduce { get; set; } = 6;

        public static string DefaultPreyImg { get { return "f"; } }

        public void Process()
        {

        }

        public void MoveFrom(int from, int to)
        {

        }

        public void Reproduce(Coordinate coordinate)
        {

        }

        public Prey(Coordinate coordinate)
        {
            this.coordinate = coordinate;
            //Cell cell = new Cell(Kind.Prey, coordinate);
        }

    }
}
