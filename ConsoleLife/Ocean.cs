using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    public class Ocean : Cell
    {
        public static int Rows { get; set; } = 3;

        public static int Columns { get; set; } = 3;

        public int Size => Rows * Columns;

        public static int PreyCount { get; set; } = 4;

        public static int PredatorsCount { get; set; } = 2;

        public static int ObstaclesCount { get; set; } = 0;

        public int IterationCount { get; set; } = 1000;

        public int MaxCount { get { return 6; }}

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
                Obstacle obs = new Obstacle(coord);
                Field[coord.Y, coord.X] = obs;
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
                Prey prey = new Prey(coord);
                Field[coord.Y, coord.X] = prey;
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
                Predator predator = new Predator(coord);
                Field[coord.Y, coord.X] = predator;
            }

        }

        private Coordinate GetEmptyCellCoord()
        {
            Random rand = new Random();
            Coordinate empty = new Coordinate();

            do
            {
                empty.X = rand.Next(0, Columns);
                empty.Y = rand.Next(0, Rows);
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
            Console.WriteLine($"Количествово итераций: {iterations + 1}\tКоличествово добычи: {Ocean.PreyCount}" +
                $"\tКоличествово хищников: {Ocean.PredatorsCount}\t");
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
                            Field[i, j].Process();
                        }
                    }
                    //Console.Clear();
                }
                else
                {
                    Console.WriteLine("Конец игры! Для выхода нажмите любую кнопку (на клавиатуре)");
                    Environment.Exit(0);
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
