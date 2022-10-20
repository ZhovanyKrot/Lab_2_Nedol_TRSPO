using System;
using System.Threading.Tasks;

class Program
{
    static public List<int> result = new List<int>();
    static object loker = new object();
    static object lokerc = new object();
    static public bool t = true;
    static int c = 0;
    static void Main(string[] args)
    {

        Console.WriteLine("Завдання 1");
        Thread sortTh = new Thread(ListSort);
        sortTh.Start();
        Thread num = new Thread(NumberToList);
        num.Start();
        Thread.Sleep(15000);
        Console.WriteLine("Завдання 2");
        for (int i = 1; i < 6; i++)
        {
            Thread myThread = new(Constukt);
            myThread.Name = $"Поток {i} ";
            myThread.Start();
        }

    }
    static void NumberToList()
    {
        lock (loker)
        {
            while (true)
            {
                Console.WriteLine("Write number");
                var n = Console.ReadLine();
                if (int.TryParse(n, out int number))
                {
                    result.Add(number);
                }
                else if (!n.All(char.IsDigit))
                {
                    Console.WriteLine("Invalid format string");
                }
                else { t = false; break; }
            }
            Console.Write("Masiv: ");
            foreach (var item in result)
            {

                Console.Write(item + " ");
            }
            Console.ReadLine();
        }
    }

    static void ListSort()
    {
        while (t)
        {
            Console.WriteLine("Sort Complite");
            result.Sort();
            Thread.Sleep(5000);
        }
    }

    static void Constukt()
    {
        int k = 0;
        while (k < 5)
        {
            C_metod(c);
            Console.WriteLine($"{Thread.CurrentThread.Name}" + "Закончил сборку Винтика");
            k++;
            Console.WriteLine($"{Thread.CurrentThread.Name}" + "Собрал Винтиков " + k);
        }
    }

    static void C_metod(int cn)
    {
        lock (lokerc)
        {
            int a = 0, b = 0;
            a = A_metod(a);
            Thread.Sleep(1000);
            b = B_metod(b);
            Thread.Sleep(2000);
            cn = Math.Abs(b + a);
            Console.WriteLine($"{Thread.CurrentThread.Name}" + "Сборка в C цеху ");
            Thread.Sleep(3000);
        }
    }

    static int B_metod(int bn)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name}" + "Сборка в B цеху");
        bn = 1;
        return bn;
    }

    static int A_metod(int an)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name}" + "Сборка в A цеху");
        an = 1;
        return an;
    }
}