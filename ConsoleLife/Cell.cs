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

    public enum Kind { Empty = 1, Prey, Predator, Obstacles };

    public class Cell
    {

        public Kind? kind = null;

        public string Img { get; set; } = "-";

        public Coordinate coordinate;

        public Ocean ocean1;


        public virtual void Process()
        {
            Coordinate toCoord = new Coordinate();
            toCoord = GetEmptyNeighborCoord();
        }

        public Cell GetNeighborWithKind(Kind? kind)
        {
            string img = "";
            switch (kind)
            {
                case Kind.Empty:
                    img = "-";
                    break;
                case Kind.Prey:
                    img = "f";
                    break;
                case Kind.Predator:
                    img = "S";
                    break;
                case Kind.Obstacles:
                    img = "#";
                    break;
                default:
                    break;
            }
            Cell[] neighbors = new Cell[4];
            //Coordinate c = new Coordinate();

            int step = 0;

            if (North().Img == img)
                neighbors[step++] = North();

            if (South().Img == img)
                neighbors[step++] = South();

            if (East().Img == img)
                neighbors[step++] = East();

            if (West().Img == img)
                neighbors[step++] = West();
            if (step == 0)
            {
                return this;
            }
            else
            {
                Random rand = new Random();
                int nextIntBetween = rand.Next(0, step - 1);
                return neighbors[nextIntBetween];
            }

        }
        /// <summary>
        /// Ищет пустую соседнюю ячейку
        /// </summary>
        public Coordinate GetEmptyNeighborCoord()
        {
            //GetOffset();
            //Cell cell = new Cell();
            //cell = GetNeighborWithImg(Img);
            return GetNeighborWithKind(Kind.Empty).coordinate;
        }
        /// <summary>
        /// Ищет соседнюю ячейку с добычей
        /// </summary>
        public Coordinate GetPreyNeighborCoord()
        {
            return GetNeighborWithKind(Kind.Prey).coordinate;
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

        /// <summary>
        /// Метод поиска соседей
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public Cell GetCellAt(Coordinate coordinate)
        {
            return ocean1.Field[coordinate.Y, coordinate.X];
        }


        /// <summary>
        /// Помещает ячейку cell в место с координатами coordinate в массие Field из Ocean 
        /// </summary>
        /// <param name="coordinate">Координаты ячейки</param>
        /// <param name="cell">Ячейка</param>
        public void AssignCellAt(Coordinate coordinate, Cell cell)
        {
            ocean1.Field[coordinate.Y, coordinate.X] = cell;
        }

        public void DyingObject()
        {

        }

        public Cell North()
        {
            int y;
            //Cell[,] cells = new Cell[25, 70];
            y = (coordinate.Y > 0) ? (coordinate.Y - 1) : (coordinate.Y);
            
            return ocean1.Field[y, coordinate.X];
        }

        public Cell South()
        {
            //Cell[,] cells = new Cell[25, 70];
            int y;
            y = (coordinate.Y + 1) % ocean1.Rows;
            return ocean1.Field[y, coordinate.X];
        }

        public Cell West()
        {
            //Cell[,] cells = new Cell[25, 70];
            int x;
            x = (coordinate.X > 0) ? (coordinate.X - 1) : (coordinate.X);
            return ocean1.Field[coordinate.Y, x];
        }

        public Cell East()
        {
            //Cell[,] cells = new Cell[25, 70];
            int x;
            x = (coordinate.X + 1) % ocean1.Columns;
            return ocean1.Field[coordinate.Y, x];

        }

        public virtual Cell Reproduce(Coordinate coordinate)
        {
            Cell tmp = new Cell(Kind.Empty, coordinate);
            return tmp;
        }

        public Cell()
        {

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
