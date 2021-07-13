using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    public class Prey : Cell
    {

        public int TimeToReproduce { get; set; } = 6;

        public static string DefaultPreyImg { get { return "f"; } }

        /// <summary>
        /// Перемещает ячейки согласно правилам каждого подкласса и обновляет массив Field
        /// </summary>
        public override void Process()
        {
            Coordinate toCoord = new Coordinate();
            Coordinate fromCoord = new Coordinate();
            toCoord = GetEmptyNeighborCoord(this.coordinate);
            fromCoord = this.coordinate;
            MoveFrom(fromCoord, toCoord);
            
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
        /// <returns>Возвращает объект типа Prey</returns>
        public override Cell Reproduce(Coordinate coordinate)
        {
            Prey tmp = new Prey(coordinate);
            ++Ocean.PreyCount;
            return tmp;
        }

        /// <summary>
        /// Конструктор объекта Prey
        /// </summary>
        /// <param name="coordinate">Задает местоположение объекта в массиве ячеек Cell</param>
        public Prey(Coordinate coordinate)
        {
            this.coordinate = coordinate;
            Img = DefaultPreyImg;
            kind = Kind.Prey;
        }


    }
}
