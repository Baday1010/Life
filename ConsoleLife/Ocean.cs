using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife
{
    public class Ocean : Cell
    {
        public static int Rows { get; set; } = 25;

        public static int Columns { get; set; } = 70;

        public int Size => Rows * Columns;

        public static int PreyCount { get; set; } = 150;

        public static int PredatorsCount { get; set; } = 25;

        public static int ObstaclesCount { get; set; } = 1;

        public int IterationCount { get; set; } = 1000;

        public int MaxCount { get { return 12; }}

        public static Cell[,] Field;
      
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
                //listOfObstacles.Add(obs);

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
                Field[coord.Y, coord.X].TimeToReproduce = 6;
                Field[coord.Y, coord.X].TimeToFeed = 0;
                Prey prey = new Prey(coord);
                //listOfPreys.Add(prey);

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
                Field[coord.Y, coord.X].TimeToFeed = 6;
                Field[coord.Y, coord.X].TimeToReproduce = 6;
                Predator predator = new Predator(coord);
                //listOfPredators.Add(predator);

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
        public void DisplayStats(int iterations)
        {
            Console.WriteLine($"Количествово итераций: {iterations + 1}\tКоличествово добычи: {Ocean.PreyCount}\tКоличествово хищников: {Ocean.PredatorsCount}\t");
        }

        /// <summary>
        /// Функции вывода поля на консоль
        /// </summary>
        public void Display(int iterations)
        {
            DisplayStats(iterations);
            DisplayBorder();
            DisplayCells();
            DisplayBorder();
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
                Display(iter);
                //System.Threading.Thread.Sleep(1000);
                if (PreyCount > 0 && PredatorsCount > 0)
                {
                    for (int i = 0; i < Rows; i++)
                    {
                        for (int j = 0; j < Columns; j++)
                        {
                            Process(Field[i, j]);
                            
                            //Console.Clear();
                        }
                    }
                   
                }
                else
                {
                    Console.WriteLine("Конец игры");
                    Environment.Exit(0);
                }
            }
        }

        public void Process(Cell cell)
        {
            if (cell.Img != DefaultEmptyImg)
            {
                if (cell.Img == Prey.DefaultPreyImg)
                {
                    Coordinate toCoord = new Coordinate();
                    Coordinate fromCoord = new Coordinate();
                    toCoord = GetEmptyNeighborCoord(cell.coordinate);
                    fromCoord = cell.coordinate;

                    cell.MoveFrom(fromCoord, toCoord, Kind.Prey);
                }
                else
                {
                    Coordinate toCoord = new Coordinate();
                    Coordinate fromCoord = new Coordinate();
                   
                    toCoord = GetPreyNeighborCoord(cell.coordinate);
                    fromCoord = cell.coordinate;

                    cell.MoveFrom(fromCoord, toCoord, Kind.Predator);
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
            //AddObstacles();
            //ocean1 = this;
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
            //ocean1 = this;
            
        }
        /// <summary>
        /// Инициализация Ocean со своими параметрами
        /// </summary>
        /// <param name="Rows">Кол-во строк</param>
        /// <param name="Columns">Кол-во рядков</param>
        public Ocean(int Rows, int Columns, int IterationCount)
        {
            Ocean.Rows = Rows;
            Ocean.Columns = Columns;
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
