using System;

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
                        Console.WriteLine("Введите кол-во рядков: ");
                        string r = Console.ReadLine();
                        Console.WriteLine("Введите кол-во столбцов: ");
                        string c = Console.ReadLine();
                        Console.WriteLine("Введите кол-во итераций: ");
                        string i = Console.ReadLine();
                        Console.WriteLine("Введите кол-во Хищников: ");
                        string h = Console.ReadLine();
                        Console.WriteLine("Введите кол-во Добычи: ");
                        string p = Console.ReadLine();
                        Console.WriteLine("Введите кол-во Препятствий: ");
                        string prep = Console.ReadLine();
                        try
                        {
                            int res = Convert.ToInt32(r);
                            int res2 = Convert.ToInt32(c);
                            int res3 = Convert.ToInt32(i);
                            int res4 = Convert.ToInt32(h);
                            int res5 = Convert.ToInt32(p);
                            int res6 = Convert.ToInt32(prep);

                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("One or more values outside the range of the Int32 type.");
                            Environment.Exit(0);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("One or more values are not in a recognizable format.");
                            Environment.Exit(0);
                        }
                        ocean = new Ocean(Int32.Parse(r), Int32.Parse(c), Int32.Parse(i), Int32.Parse(h), Int32.Parse(p), Int32.Parse(prep));
                        
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
