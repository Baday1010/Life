using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife
{

    public struct Coordinate
    {
        public int X;

        public int Y;

        public Coordinate(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }

    public enum Kind { Prey = 1, Predator, Obstacles, Empty };

    class Cell
    {

        public Kind? kind = null;

        public Ocean ocean1;

        public string Img { get; set; } = "-";

        public Coordinate coordinate;

        public void GetImage()
        {

        }

        public void Display()
        {

        }

        public void Process()
        {

        }

        public void GetEmptyNeighborCoord()
        {

        }

        public void GetPreyNeighborCoord()
        {

        }

        public void GetCoordinate()
        {

        }

        public void SetCoordinate(Coordinate coordinate)
        {

        }

        public void GetCellAt(Coordinate coordinate)
        {

        }


        /// <summary>
        /// Помещает ячейку cell в место с координатами coordinate в массие Field из Ocean 
        /// </summary>
        /// <param name="coordinate">Координаты ячейки</param>
        /// <param name="cell">Ячейка</param>
        public void AssignCellAt(Coordinate coordinate, Cell cell)
        {

        }

        public void DyingObject()
        {

        }

        public void North()
        {

        }

        public void South()
        {

        }

        public void West()
        {

        }

        public void East()
        {

        }



        public Cell(Kind kind, Coordinate coordinate)
        {
            this.kind = kind;
            this.coordinate = coordinate;
        }
       

    }
}
