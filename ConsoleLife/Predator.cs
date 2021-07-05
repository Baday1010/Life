using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife
{
    public class Predator : Prey
    {
        public new Coordinate coordinate { get; set; }

        public new int TimeToReproduce { get; set; } = 6;

        public int TimeToFeed { get; set; } = 6;

        public static string DefaultPredatorImg { get { return "S"; } }

        public new void GetPreyNeighborCoord()
        {

        }

        public void Process()
        {

        }

        public void MoveFrom(int from, int to)
        {

        }

        public override Cell Reproduce(Coordinate coordinate)
        {
            Cell cell = new Cell(Kind.Predator);
            return cell;
        }

        public Predator(Coordinate coordinate)
            :base(coordinate)
        {
            this.coordinate = coordinate;
        }
    }
}
