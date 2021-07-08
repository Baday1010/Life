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

        private readonly IOcean _owner;

        public Cell(IOcean owner)
        {
            _owner = owner;
        }

        public Kind? kind = null;

        public int TimeToReproduce { get; set; } = 6;

        public int TimeToFeed { get; set; } = 6;

        public string Img { get; set; } = "-";

        public string DefaultEmptyImg { get; set; } = "-";

        public Coordinate coordinate;

        public Cell GetNeighborWithImg(string img, Coordinate coordinate)
        {
            Cell[] neighbors = new Cell[4];

            int step = 0;


            if (North(coordinate).Img == img)
                neighbors[step++] = North(coordinate);

            if (South(coordinate).Img == img)
                neighbors[step++] = South(coordinate);

            if (East(coordinate).Img == img)
                neighbors[step++] = East(coordinate);

            if (West(coordinate).Img == img)
                neighbors[step++] = West(coordinate);
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
        public Coordinate GetEmptyNeighborCoord(Coordinate coordinate)
        {
            return GetNeighborWithImg(DefaultEmptyImg, coordinate).coordinate;
        }
        /// <summary>
        /// Ищет соседнюю ячейку с добычей
        /// </summary>
        public Coordinate GetPreyNeighborCoord(Coordinate coordinate)
        {
            return GetNeighborWithImg(Prey.DefaultPreyImg, coordinate).coordinate;
        }


        /// <summary>
        /// Метод поиска соседей
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public Cell GetCellAt(Coordinate coordinate)
        {
            return Ocean.Field[coordinate.Y, coordinate.X];
        }

        public virtual void MoveFrom(Coordinate from, Coordinate to, Kind kind)
        {
            if (kind == Kind.Prey)
            {
                --TimeToReproduce;

                if (to.X != from.X || to.Y != from.Y)
                {
                    AssignCellAt(to, this);

                    if (TimeToReproduce <= 0)
                    {
                        TimeToReproduce = 6;
                        AssignCellAt(from, Reproduce(from));
                        
                    }
                    else
                    {
                        AssignCellAt(from, new Cell(Kind.Empty, from));
                    }
                }
            }
               
            else
            {
                --TimeToReproduce;
                --TimeToFeed;
                if (TimeToFeed <= 0)
                {
                    AssignCellAt(from, new Cell(Kind.Empty, from));
                    --Ocean.PredatorsCount;
                }


                if (to.X != from.X || to.Y != from.Y)
                {
                    --Ocean.PreyCount;
                    TimeToFeed = 6;
                    AssignCellAt(to, this);

                    if (TimeToReproduce <= 0)
                    {
                        TimeToReproduce = 6;
                        AssignCellAt(from, Reproduce(from, Kind.Predator));
                    }
                    else
                    {
                        AssignCellAt(from, new Cell(Kind.Empty, from));
                    }
                }
            }
                

            
        }


        /// <summary>
        /// Помещает ячейку cell в место с координатами coordinate в массие Field из Ocean 
        /// </summary>
        /// <param name="coordinate">Координаты ячейки</param>
        /// <param name="cell">Ячейка</param>
        public void AssignCellAt(Coordinate coordinate, Cell cell)
        {
            Ocean.Field[coordinate.Y, coordinate.X] = cell;
        }

        public void DyingObject()
        {

        }

        public Cell North(Coordinate coordinate)
        {
            int y;
            //Cell[,] cells = new Cell[25, 70];
            y = (coordinate.Y > 0) ? (coordinate.Y - 1) : (coordinate.Y);

            return Ocean.Field[y, coordinate.X];
        }

        public Cell South(Coordinate coordinate)
        {
            int y;
            y = (coordinate.Y + 1) % Ocean.Rows;
            return Ocean.Field[y, coordinate.X];
        }

        public Cell West(Coordinate coordinate)
        {
            int x;
            x = (coordinate.X > 0) ? (coordinate.X - 1) : (coordinate.X);
            return Ocean.Field[coordinate.Y, x];
        }

        public Cell East(Coordinate coordinate)
        {
            int x;
            x = (coordinate.X + 1) % Ocean.Columns;
            return Ocean.Field[coordinate.Y, x];

        }

        public virtual Cell Reproduce(Coordinate coordinate)
        {
            Cell tmp = new Cell(Kind.Prey, coordinate);
            return tmp;
        }

        public virtual Cell Reproduce(Coordinate coordinate, Kind kind)
        {
            Cell tmp = new Cell(kind, coordinate);
            return tmp;
        }


        public Cell()
        {

        }
        public Cell(Kind kind, Coordinate coordinate, int timeTo)
        {
            this.kind = kind;
            this.coordinate = coordinate;
            if (kind == Kind.Prey)
            {
                TimeToFeed = 0;
                TimeToReproduce = timeTo;
            }
            else
            {
                TimeToFeed = timeTo;
                TimeToReproduce = 0;
            }
        }
        public Cell(Kind? kind)
        {
            this.kind = kind;
            if (kind == Kind.Empty)
            {
                TimeToReproduce = 0;
                TimeToFeed = 0;
            }
        }

        public Cell(Kind kind, Coordinate coordinate)
        {
            this.kind = kind;
            this.coordinate = coordinate;
            if (kind == Kind.Empty)
            {
                TimeToReproduce = 0;
                TimeToFeed = 0;
            }
            else if(kind == Kind.Prey)
            {
                TimeToReproduce = 6;
                TimeToFeed = 0;
                this.Img = Prey.DefaultPreyImg;
            }
            else if (kind == Kind.Predator)
            {
                TimeToReproduce = 6;
                TimeToFeed = 6;
                this.Img = Predator.DefaultPredatorImg;
            }
        }


    }
}
