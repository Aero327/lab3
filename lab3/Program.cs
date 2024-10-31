using System.Diagnostics;

namespace lab3;

internal class Program
{
    public static void Main(string[] args)
    {
        
        Console.Write("Выберите задание (от 1 до 8): ");
        try
        {
            var task = int.Parse(Console.ReadLine());
            
            switch (task)
            {
                case 1: Program.Task1(); break;
                case 2: Program.Task2(); break;
                case 3: Program.Task3(); break;
                /*case 4: Program.Task4(); break;
                case 5: Program.Task5(); break;
                case 6: Program.Task6(); break;
                case 7: Program.Task7(); break;
                case 8: Program.Task8(); break;
                */
                default:
                    Console.WriteLine("Такого варианта нет."); break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: неверный ввод. Убедитесь, что вы ввели именно число.");
        }
    }

    public static void Task1()
    {
        var m1 = new Arrays2D();
        Console.WriteLine($"Первый массив: \n{m1}\n");

        try
        {
            Console.WriteLine("Введите размерность для второго массива (n): ");
            var n = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Введите максимальное значение для случайно генерируемых чисел: ");
            var ceiling = int.Parse(Console.ReadLine());
            
            var m2 = new Arrays2D(n, n, ceiling);
            Console.WriteLine($"Второй массив: \n{m2}\n");

            Console.WriteLine("Введите размерность для третьего массива (n): ");
            n = int.Parse(Console.ReadLine());
            
            var m3 = new Arrays2D(n);
            Console.WriteLine($"Третий массив: \n{m3}\n");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: неверный ввод. Убедитесь, что вы ввели именно число.");
        }
    }

    public static void Task2()
    {
        try
        {
            Console.WriteLine("Введите кол-во депутатов (n): ");
            var votes_n = int.Parse(Console.ReadLine());

            if (votes_n > 0)
            {
                var votes = new bool[2, votes_n];

                Console.WriteLine(
                    $"Введите {votes_n} голосов депутатов на первом голосовании (true или false, то есть \"Да\" или \"Нет\" соответственно): ");

                for (var i = 0; i < votes_n; i++)
                {
                    votes[0, i] = bool.Parse(Console.ReadLine());
                }

                Console.WriteLine(
                    $"Введите {votes_n} голосов депутатов на втором голосовании (true или false, то есть \"Да\" или \"Нет\" соответственно): ");

                for (var i = 0; i < votes_n; i++)
                {
                    votes[1, i] = bool.Parse(Console.ReadLine());
                }

                Arrays2D.VotesCount(votes);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: неверный ввод. Убедитесь, что вы ввели именно число.");
        }
    }

    public static void Task3()
    {
        Console.WriteLine("\nВведите кол-во столбцов (n) первой матрицы (A): ");
        var n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите кол-во строк (m) первой матрицы (A): ");
        var m = int.Parse(Console.ReadLine());
        
        var A = new Arrays2D(n, m);
        
        Console.WriteLine("\nВведите кол-во столбцов (n) второй матрицы (B): ");
        n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите кол-во строк (m) второй матрицы (B): ");
        m = int.Parse(Console.ReadLine());
        
        var B = new Arrays2D(n, m);
        
        Console.WriteLine("\nВведите кол-во столбцов (n) третьей матрицы (B): ");
        n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите кол-во строк (m) третьей матрицы (B): ");
        m = int.Parse(Console.ReadLine());
        
        var C = new Arrays2D(n, m);
        
        Console.WriteLine("\ntranspose(A) + B - 3C = ");
        Console.WriteLine(A.Transpose() + B - 3 * C);
    }

    public static void Task4()
    {
        // сделать
    }

    public static void Task5()
    {
        // сделать
    }

    public static void Task6()
    {
        // сделать
    }

    public static void Task7()
    {
        // сделать
    }

    public static void Task8()
    {
        // сделать
    }
}