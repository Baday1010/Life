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

        public int IterationCount { get; set; } = 1000;

        public int MaxCount { get { return 400; }}


        public List<Prey> listOfPreys = new List<Prey>();

        public List<Predator> listOfPredators = new List<Predator>();

        public List<Obstacle> listOfObstacles = new List<Obstacle>();

        public Cell[,] Field;
        //private readonly Kind kind;

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
            Coordinate coord = new Coordinate();
            for (int i = 0; i < PreyCount; i++)
            {
                coord = GetEmptyCellCoord();
                Field[coord.Y, coord.X].kind = Kind.Prey;
                Prey prey = new Prey(coord);
                listOfPreys.Add(prey);

            }
        }

        public void AddPredator()
        {
            Coordinate coord = new Coordinate();
            for (int i = 0; i < PredatorsCount; i++)
            {
                coord = GetEmptyCellCoord();
                Field[coord.Y, coord.X].kind = Kind.Predator;
                Predator predator = new Predator(coord);
                listOfPredators.Add(predator);

            }

        }

        private Coordinate GetEmptyCellCoord()
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
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    switch (Field[i, j].kind)
                    {
                        case Kind.Empty:
                            Field[i, j].Img = "-";
                            break;
                        case Kind.Prey:
                            Field[i, j].Img = Prey.DefaultPreyImg;
                            break;
                        case Kind.Predator:
                            Field[i, j].Img = Predator.DefaultPredatorImg;
                            break;
                        case Kind.Obstacles:
                            Field[i, j].Img = Obstacle.DefaultObstacleImg;
                            break;
                        default:
                            break;
                    }
                    
                    Console.Write(Field[i, j].Img);
                }
                Console.WriteLine();
            }
            
        }

        public void DisplayBorder()
        {
            for (int i = 0; i < Columns; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }

        public void DisplayStats()
        {

        }
      
        public void Run()
        {
            if (IterationCount > 1000)
                IterationCount = 1000;

            for (int iter = 0; iter < IterationCount; iter++)
            {
                if (PreyCount > 0 && PredatorsCount > 0)
                {
                    for (int i = 0; i < Rows; i++)
                    {
                        for (int j = 0; j < Columns; j++)
                        {
                            Field[i, j].Process();
                            DisplayStats();
                            DisplayCells();
                            DisplayBorder();
                            
                        }
                    }
                }
            }
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
            DisplayBorder();
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
        public Ocean(int Rows, int Columns, int IterationCount)
        {
            this.Rows = Rows;
            this.Columns = Columns;
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
