using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    public class Predator : Cell
    {
        public int TimeToFeed { get; set; } = 6;

        public int TimeToReproduce { get; set; } = 6;

        public static string DefaultPredatorImg { get { return "S"; } }

        /// <summary>
        /// Ищет соседнюю ячейку с добычей
        /// </summary>
        public Coordinate GetPreyNeighborCoord(Coordinate coordinate)
        {
            return GetNeighborWithImg(Prey.DefaultPreyImg, coordinate).coordinate;
        }

        /// <summary>
        /// Перемещает ячейки согласно правилам каждого подкласса и обновляет массив Field
        /// </summary>
        public override void Process()
        {
            Coordinate toCoord = new Coordinate();
            --TimeToFeed;
            if (TimeToFeed <= 0)
            {
                Kill();
            }
            else
            {
                toCoord = GetPreyNeighborCoord(this.coordinate);
                if (toCoord.X != this.coordinate.X || toCoord.Y != this.coordinate.Y)
                {
                    --Ocean.PreyCount;
                    TimeToFeed = 6;
                    MoveFrom(this.coordinate, toCoord);
                }
                else
                {
                    toCoord = GetEmptyNeighborCoord(this.coordinate);
                    MoveFrom(this.coordinate, toCoord);
                }
            }
        }

        private void Kill()
        {
            AssignCellAt(this.coordinate, new Cell(Kind.Empty, this.coordinate));
            --Ocean.PredatorsCount;
        }

        /// <summary>
        /// Перемещает из координаты from в координаты to в массиве Field
        /// </summary>
        /// <param name="from">Нынешнее местоположение</param>
        /// <param name="to">Местоположение для перемещения</param>
        public void MoveFrom(Coordinate from, Coordinate to)
        {
            --TimeToReproduce;
            if (to.X != from.X || to.Y != from.Y)
            {
                this.coordinate = to;
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

        /// <summary>
        /// Воспроизводит себя в ячейке с заданной координатой
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns>Возвращает объект типа Predator</returns>
        public override Cell Reproduce(Coordinate coordinate)
        {
            Predator p = new Predator(coordinate);
            ++Ocean.PredatorsCount;
            return p;
        }
        public Predator()
        {

        }

        /// <summary>
        /// Конструктор объекта Predator
        /// </summary>
        /// <param name="coordinate">Задает местоположение объекта в массиве ячеек Cell</param>
        public Predator(Coordinate coordinate)
        {
            this.coordinate = coordinate;
            Img = DefaultPredatorImg;
            kind = Kind.Predator;
        }
    }
}
