using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLife
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kind k = Kind.Empty;
            //Coordinate empty = new Coordinate(0, 0);
            //Cell[,] cells = new Cell[25, 70];
            //cells[0, 0] = new Cell(k, empty);
            
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
                        try
                        {
                            int res = Convert.ToInt32(r);
                            int res2 = Convert.ToInt32(c);
                            int res3 = Convert.ToInt32(c);
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine($"{r} or {c} is outside the range of the Int32 type.");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"The value {r} or {c} is not in a recognizable format.");
                        }
                        ocean = new Ocean(Int32.Parse(r), Int32.Parse(c), Int32.Parse(i));
                        Console.Clear();
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
