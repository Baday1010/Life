using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife
{
    public class Predator : Cell
    {
        public int TimeToFeed { get; set; } = 6;

        public static string DefaultPredatorImg { get { return "S"; } }

        /// <summary>
        /// Ищет соседнюю ячейку с добычей
        /// </summary>
        public Coordinate GetPreyNeighborCoord(Coordinate coordinate)
        {
            return GetNeighborWithImg(Prey.DefaultPreyImg, coordinate).coordinate;
        }

        public void Process(Cell cell)
        {
            Coordinate toCoord = new Coordinate();
            --cell.TimeToFeed;
            if (cell.TimeToFeed <= 0)
            {
                Kill(cell);
            }
            else
            {
                toCoord = GetPreyNeighborCoord(cell.coordinate);
                if (toCoord.X != cell.coordinate.X || toCoord.Y != cell.coordinate.Y)
                {
                    --Ocean.PreyCount;
                    cell.TimeToFeed = 6;
                    MoveFrom(cell.coordinate, toCoord, Kind.Predator);
                }
                else
                {
                    toCoord = GetEmptyNeighborCoord(cell.coordinate);

                }
            }
        }

        private void Kill(Cell cell)
        {
            AssignCellAt(cell.coordinate, new Cell(Kind.Empty, cell.coordinate));
            --Ocean.PredatorsCount;
        }

        public void MoveFrom(int from, int to)
        {

        }

        //public override Cell Reproduce(Coordinate coordinate)
        //{
        //    Cell cell = new Cell(Kind.Predator);
        //    return cell;
        //}

        //public Predator(Coordinate coordinate)
        //    :base(coordinate)
        //{
        //    this.coordinate = coordinate;
        //}

        public Predator()
        {

        }

        public Predator(Coordinate coordinate)
        {
            this.coordinate = coordinate;
        }
    }
}
