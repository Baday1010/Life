using System;
using ConsoleLife.Exception;

namespace Life
{
    public class Ocean : Cell
    {
        public static uint Rows { get; set; } = 3;

        public static uint Columns { get; set; } = 3;

        private uint Size { get; set; }

        public static uint PreyCount { get; set; } = 4;

        public static uint PredatorsCount { get; set; } = 2;

        public static uint ObstaclesCount { get; set; } = 1;

        public uint IterationCount { get; set; } = 1000;

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

        /// <summary>
        /// Случайным образом выбирает координаты в массиве Field и проверяет пустая ли ячейка
        /// </summary>
        /// <returns>Возвращает координаты пустой ячейки</returns>
        private Coordinate GetEmptyCellCoord()
        {
            Random rand = new Random();
            Coordinate empty = new Coordinate();

            do
            {
                empty.X = rand.Next(0, (int)Columns);
                empty.Y = rand.Next(0, (int)Rows);
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
                    switch (Field[i, j].Img)
                    {
                        case "-":
                            Console.Write(Field[i, j].Img);
                            break;
                        case "f":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(Field[i, j].Img);
                            Console.ResetColor();
                            break;
                        case "S":
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(Field[i, j].Img);
                            Console.ResetColor();
                            break;
                        case "#":
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(Field[i, j].Img);
                            Console.ResetColor();
                            break;
                        default:
                            break;
                    }

                }
                Console.WriteLine();
            }
            
        }

        /// <summary>
        /// Отображает максимальную ограниченную область океана 
        /// </summary>
        public void DisplayBorder()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < Columns; i++)
            {
                Console.Write("=");
            }
            Console.ResetColor();
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
                System.Threading.Thread.Sleep(1000);
                if (PreyCount > 0 && PredatorsCount > 0)
                {
                    for (int i = 0; i < Rows; i++)
                    {
                        for (int j = 0; j < Columns; j++)
                        {
                            Field[i, j].Process();
                        }
                    }

                    for (int i = 0; i < Rows; i++)
                    {
                        for (int j = 0; j < Columns; j++)
                        {
                            Field[i, j].IsMoved = false;
                        }
                    }
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Конец игры! Для выхода нажмите любую кнопку (на клавиатуре)");
                    break;
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
            //ocean1 = this;
        }

        /// <summary>
        /// Значения по умолчанию
        /// </summary>
        /// 

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
        /// <param name="IterationCount">Кол-во итераций</param>
        /// <param name="PreyCount">Кол-во добычи</param>
        /// <param name="PredatorsCount">Кол-во хищников</param>
        /// <param name="ObstaclesCount">Кол-во препятствий</param>
        public Ocean(int Rows, int Columns, int IterationCount, int PredatorsCount, int PreyCount, int ObstaclesCount)
        {
            Size = (uint)Rows * (uint)Columns;

            if (Size > 2000) { throw new OceanException("Поле игры превышает 2000 ячеек", Size); }

            if ((PreyCount + PredatorsCount + ObstaclesCount) > Size)
            {
                int sum = PreyCount + PredatorsCount + ObstaclesCount;
                throw new OceanException("Объекты не помещаются на заданном поле", (uint)sum);
            }


            Ocean.Rows = (uint)Rows;
            Ocean.Columns = (uint)Columns;
            Ocean.PreyCount = (uint)PreyCount;
            Ocean.PredatorsCount = (uint)PredatorsCount;
            Ocean.ObstaclesCount = (uint)ObstaclesCount;
            this.IterationCount = (uint)IterationCount;
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
