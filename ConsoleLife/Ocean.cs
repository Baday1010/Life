using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife
{
    class Ocean
    {
        public int Rows { get; set; } = 25;

        public int Columns { get; set; } = 70;

        public int Size => Rows * Columns;

        public int PreyCount { get; set; } = 150;

        public int PredatorsCount { get; set; } = 20;

        public int ObstaclesCount { get; set; } = 75;

        public int MaxCount { get { return 400; }}

        public Cell[,] Field;
        private readonly Kind kind;

        /*
        public void GetNumPrey()
        {

        }

        public void SetNumPrey(int Count)
        {

        }

        public void GetNumPredators()
        {

        }

        public void SetNumPredators(int Count)
        {

        }
        */

        public void AddObstacles()
        {

        }

        public void AddPrey()
        {
            Coordinate empty = new Coordinate();
            for (int i = 0; i < PreyCount; i++)
            {
                empty = GetEmptyCellCoord();
                Field[empty.Y, empty.X].kind = Kind.Prey;
            }
        }

        public void AddPredator()
        {
            Random rand = new Random();
            
        }

        public Coordinate GetEmptyCellCoord()
        {
            Random rand = new Random();
            Coordinate empty = new Coordinate();
            int x;
            int y;
            do
            {
                x = rand.Next(0, Columns - 1);
                y = rand.Next(0, Rows - 1);
            } while (Field[y ,x].Img != "-");
            empty = Field[y, x].coordinate;
            return empty;
           
        }

        public void DisplayCells()
        {

        }

        public void DisplayBorder()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if(i == 0 || i == Rows - 1 || j == 0 || j == Columns - 1)
                    {
                        Console.Write("#");
                        //Field[i, j].Img = "#";
                        //Field[i, j].kind = Kind.Obstacles;
                    }
                    else
                    {
                        Console.Write("-");
                    }

                }
                Console.WriteLine();

            }
        }
        public void DisplayStats()
        {

        }
      
        public void Run(int Iteration)
        {

        }
        /// <summary>
        /// Устанавливает кол-во добычи, хищников и преград
        /// </summary>
        public void Initialize()
        {
            InitCells();
        }
        /// <summary>
        /// Запрашивает кол-во преград, добычи и хищников
        /// </summary>
        private void InitCells()
        {
            AddPredator();
            AddPrey();
            AddObstacles();
            DisplayStats();
            DisplayCells();
        }
        /// <summary>
        /// Значения по умолчанию
        /// </summary>
        public Ocean()
        {
            Field = new Cell[Rows, Columns];
            Kind empty = Kind.Empty;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Coordinate coordinate = new Coordinate(j, i);
                    Field[i, j] = new Cell(empty, coordinate);
                }
            }
        }
        /// <summary>
        /// Инициализация Ocean со своими параметрами
        /// </summary>
        /// <param name="Rows">Кол-во строк</param>
        /// <param name="Columns">Кол-во рядков</param>
        public Ocean(int Rows, int Columns)
        {
            this.Rows = Rows;
            this.Columns = Columns;
            Field = new Cell[Rows, Columns];
            Kind empty = Kind.Empty;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Coordinate coordinate = new Coordinate(j, i);
                    Field[i, j] = new Cell(empty, coordinate);
                }
            }
        }
        

    }
}
