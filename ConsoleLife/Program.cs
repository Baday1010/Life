using System;
using ConsoleLife.Exception;

namespace Life
{
    class Program
    {
        static void Main(string[] args)
        {
            Ocean ocean = null;
           
            Console.WriteLine("Введите тип игры\n1-Игра по умолчанию\n2-Игра с установкой своих параметров ");
            int switch_on;
            bool succees = Int32.TryParse(Console.ReadLine(), out switch_on);
            if (!succees)
            {
                Console.WriteLine("Введите корректные данные");
            }
            else
            {
                switch (switch_on)
                {
                    case 1:
                        ocean = new Ocean();
                        break;
                    case 2:
                        bool flag;
                        do
                        {

                            Console.WriteLine("Введите кол-во рядков: ");
                            string rowsStr = Console.ReadLine();
                            Console.WriteLine("Введите кол-во столбцов: ");
                            string columnsStr = Console.ReadLine();
                            Console.WriteLine("Введите кол-во итераций: ");
                            string iterationsStr = Console.ReadLine();
                            Console.WriteLine("Введите кол-во Хищников: ");
                            string predatorsStr = Console.ReadLine();
                            Console.WriteLine("Введите кол-во Добычи: ");
                            string preysStr = Console.ReadLine();
                            Console.WriteLine("Введите кол-во Препятствий: ");
                            string obsStr = Console.ReadLine();
                            try
                            {
                                int rowsInt = Convert.ToInt32(rowsStr);
                                int columnsInt = Convert.ToInt32(columnsStr);
                                int iterationsInt = Convert.ToInt32(iterationsStr);
                                int predatorsInt = Convert.ToInt32(predatorsStr);
                                int preysInt = Convert.ToInt32(preysStr);
                                int obsInt = Convert.ToInt32(obsStr);
                                flag = false;

                                ocean = new Ocean(Int32.Parse(rowsStr), Int32.Parse(columnsStr), Int32.Parse(iterationsStr),
                                    Int32.Parse(predatorsStr), Int32.Parse(preysStr), Int32.Parse(obsStr));

                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("One or more values outside the range of the Int32 type.");
                                flag = true;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("One or more values are not in a recognizable format.");
                                flag = true;
                            }
                            catch(OceanException ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                                Console.WriteLine($"Size of ocean outside the range: {ex.Value}");
                                flag = true;
                            }
                            
                        } while (flag == true);

                        break;
                    default:
                        Console.WriteLine("Введите корректные данные");
                        break;
                }
                Console.Clear();
                
                
                ocean.Initialize();
                ocean.Run();

            }
           
           
        }
    }
}
