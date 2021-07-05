using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife
{
    public class Prey : Cell
    {
#pragma warning disable 0108
        public Coordinate coordinate { get; set; }
        public int TimeToReproduce { get; set; } = 6;

        public static string DefaultPreyImg { get { return "f"; } }

        public void Process()
        {

        }

        public void MoveFrom(Coordinate from, Coordinate to)
        {
            Cell toCell = new Cell(Kind.Prey);
            --TimeToReproduce;
            if (to.X != from.X && to.Y != from.Y)
            {
                toCell = GetCellAt(to);
                SetOffset(to);
                AssignCellAt(to, this);

                if (TimeToReproduce <= 0)
                {
                    TimeToReproduce = TimeToReproduce;
                    AssignCellAt(from, Reproduce(from));
                }
                else
                {
                    AssignCellAt(from, new Cell(Kind.Prey, from));
                }
            }
        }

        public override Cell Reproduce(Coordinate coordinate)
        {
            Prey tmp = new Prey(coordinate);
            ocean1.SetNumPrey(ocean1.listOfPreys.Count + 1);
            return tmp;
        }

        public Prey(Coordinate coordinate)
        {
            this.coordinate = coordinate;
            //Cell cell = new Cell(Kind.Prey, coordinate);
        }

    }
}
