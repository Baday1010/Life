using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife
{
    public class Ocean : Cell
    {
        public int Rows { get; set; } = 25;

        public int Columns { get; set; } = 70;

        public int Size => Rows * Columns;

        public int PreyCount { get; set; } = 150;

        public int PredatorsCount { get; set; } = 20;

        public int ObstaclesCount { get; set; } = 75;

        public int IterationCount { get; set; } = 1000;

        public int MaxCount { get { return 400; }}

        /// <summary>
        /// Список добычи размещенный на поле
        /// </summary>
        public List<Prey> listOfPreys = new List<Prey>();

        /// <summary>
        /// Список хищников размещенный на поле
        /// </summary>
        public List<Predator> listOfPredators = new List<Predator>();

        /// <summary>
        /// Список преград размещенных на поле
        /// </summary>
        public List<Obstacle> listOfObstacles = new List<Obstacle>();

        public Cell[,] Field;

        /// <summary>
        /// Устанавливает кол-во добычи
        /// </summary>
        /// <param name="count">Кол-во добычи</param>
        internal void SetNumPrey(int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Возвращает кол-во добычи
        /// </summary>
        internal void GetNumPrey()
        {
            throw new NotImplementedException();
        }

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

        /// <summary>
        /// Добавляет преграды на поле
        /// </summary>
        public void AddObstacles()
        {
            Coordinate coord = new Coordinate();
            for (int i = 0; i < ObstaclesCount; i++)
            {
                coord = GetEmptyCellCoord();
                Field[coord.Y, coord.X].kind = Kind.Obstacles;
                Field[coord.Y, coord.X].Img = Obstacle.DefaultObstacleImg;
                Field[coord.Y, coord.X].coordinate = coord;
                Obstacle obs = new Obstacle(coord);
                listOfObstacles.Add(obs);

            }
        }

        /// <summary>
        /// Добавляет добычу на поле
        /// </summary>
        public void AddPrey()
        {
            Coordinate coord = new Coordinate();
            for (int i = 0; i < PreyCount; i++)
            {
                coord = GetEmptyCellCoord();
                Field[coord.Y, coord.X].kind = Kind.Prey;
                Field[coord.Y, coord.X].Img = Prey.DefaultPreyImg;
                Field[coord.Y, coord.X].coordinate = coord;
                Prey prey = new Prey(coord);
                listOfPreys.Add(prey);

            }
        }

        /// <summary>
        /// Добавляет хищников на поле
        /// </summary>
        public void AddPredator()
        {
            Coordinate coord = new Coordinate();
            for (int i = 0; i < PredatorsCount; i++)
            {
                coord = GetEmptyCellCoord();
                Field[coord.Y, coord.X].kind = Kind.Predator;
                Field[coord.Y, coord.X].Img = Predator.DefaultPredatorImg;
                Field[coord.Y, coord.X].coordinate = coord;
                Predator predator = new Predator(coord);
                listOfPredators.Add(predator);

            }

        }

        private Coordinate GetEmptyCellCoord()
        {
            Random rand = new Random();
            Coordinate empty = new Coordinate();
            //int x;
            //int y;
            do
            {
                empty.X = rand.Next(0, Columns - 1);
                empty.Y = rand.Next(0, Rows - 1);
            } while (Field[empty.Y ,empty.X].Img != "-");
            empty = Field[empty.Y, empty.X].coordinate;
            return empty;
           
        }

        /// <summary>
        /// Пересчитывает и выводит массив Field
        /// </summary>
        public void DisplayCells()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {   
                    Console.Write(Field[i, j].Img);
                }
                Console.WriteLine();
            }
            
        }

        /// <summary>
        /// Отображает максимальную ограниченную область океана 
        /// </summary>
        public void DisplayBorder()
        {
            for (int i = 0; i < Columns; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Отображает статистику по игре
        /// </summary>
        public void DisplayStats()
        {

        }
      
        /// <summary>
        /// Запрашивает у пользователя кол-во итераций и начинает моделирование
        /// </summary>
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
            ocean1 = this;
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
            ocean1 = this;
            
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
