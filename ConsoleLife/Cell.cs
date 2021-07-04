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

    public enum Kind {Empty = 1, Prey, Predator, Obstacles};

    class Cell
    {

        public Kind? kind = null;

        public string Img { get; set; } = "-";

        public Coordinate coordinate;

        public void GetImage()
        {

        }


        public void Process()
        {

        }

        public Cell GetNeighborWithImg(string img)
        {
            Cell neighbors = new Cell(kind);

            int step = 0;

            if (North())
                return neighbors;

            if (South())
                return neighbors;

            if (East())
                return neighbors;

            if (West())
            {
                return neighbors;
            }
            else
            {
                return neighbors;
            }
                
        }
        /// <summary>
        /// Ищет пустую соседнюю ячейку
        /// </summary>
        public Coordinate GetEmptyNeighborCoord()
        {
            return GetNeighborWithImg(Img).coordinate;
        }
        /// <summary>
        /// Ищет соседнюю ячейку с добычей
        /// </summary>
        public void GetPreyNeighborCoord()
        {

        }
        /// <summary>
        /// Возвращает смещение
        /// </summary>
        public void GetOffset()
        {

        }
        /// <summary>
        /// Устанавливает смещение в newCoordinate
        /// </summary>
        /// <param name="coordinate">Координаты смещения</param>
        public void SetOffset(Coordinate newCoordinate)
        {

        }

        //public Cell GetCellAt(Coordinate coordinate)
        //{
        //    return Field[coordinate.Y, coordinate.X];
        //}


        /// <summary>
        /// Помещает ячейку cell в место с координатами coordinate в массие Field из Ocean 
        /// </summary>
        /// <param name="coordinate">Координаты ячейки</param>
        /// <param name="cell">Ячейка</param>
        //public void AssignCellAt(Coordinate coordinate, Cell cell)
        //{
        //    Field[coordinate.Y, coordinate.X] = cell;
        //}

        public void DyingObject()
        {

        }

        public bool North()
        {
            int value;
            

            return true;
        }

        public bool South()
        {
            return true;
        }

        public bool West()
        {
            return true;
        }

        public bool East()
        {
            return true;
        }


        public Cell(Kind? kind)
        {
            this.kind = kind;
        }

        public Cell(Kind kind, Coordinate coordinate)
        {
            this.kind = kind;
            this.coordinate = coordinate;
        }
       

    }
}
