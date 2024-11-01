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
                case 4: Program.Task4(); break;
                case 5: Program.Task5(); break;
                case 6: Program.Task6(); break;
                case 7: Program.Task7(); break;
                case 8: Program.Task8(); break;
                
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
            Console.WriteLine("Ошибка: неверный ввод. Убедитесь, что вы ввели корректные данные.");
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
        try
        {
            Console.Write("Введите кол-во генерируемых чисел: ");
            var n = int.Parse(Console.ReadLine());

            FileTasks.GenerateBinaryFile("./task4.txt", n);
            Console.WriteLine($"Сгенерирован файл {Path.Combine(Directory.GetCurrentDirectory(), "task4.txt")}");
            long fileSize = new FileInfo("task4.txt").Length;
            Console.WriteLine($"Размер сгенерированного файла: {fileSize} байт");

            FileTasks.RemoveDuplicatesFromBinaryFile("./task4.txt", "./task4_mod.txt");
            Console.WriteLine($"Файл без дубликатов записан в {Path.Combine(Directory.GetCurrentDirectory(), "task4_mod.txt")}");
        }
        catch (FormatException) 
        {            
            Console.WriteLine("Ошибка: неверный ввод. Убедитесь, что вы ввели именно число.");
        }
    }

    public static void Task5()
    {
        var toys = new List<FileTasks.Toy>();
            
        Console.WriteLine("Введите информацию об игрушках.\n");
        while (true)
        {
            Console.Write("Название игрушки (или оставьте пустым для завершения): ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                break;
            }

            Console.Write("Цена игрушки: ");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price) || price < 0)
            {
                Console.WriteLine("Некорректная цена. Введите положительное число.");
            }

            Console.Write("Минимальный возраст: ");
            int minAge;
            while (!int.TryParse(Console.ReadLine(), out minAge) || minAge < 0)
            {
                Console.WriteLine("Некорректный возраст. Введите неотрицательное целое число.");
            }

            Console.Write("Максимальный возраст: ");
            int maxAge;
            while (!int.TryParse(Console.ReadLine(), out maxAge) || maxAge < minAge)
            {
                Console.WriteLine("Некорректный возраст. Максимальный возраст должен быть не меньше минимального.");
            }

            toys.Add(new FileTasks.Toy { Name = name, Price = price, MinAge = minAge, MaxAge = maxAge });
            Console.WriteLine("Игрушка добавлена.\n");
        }

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "task5.xml");

        FileTasks.GenerateToyXmlFile(filePath, toys);
        Console.WriteLine($"Игрушки сохранены в файл: {filePath}");

        string mostExpensiveToy = FileTasks.FindMostExpensiveToyForAge(filePath, 2, 3);

        if (mostExpensiveToy != null)
        {
            Console.WriteLine($"Самая дорогая игрушка для детей 2-3 лет: {mostExpensiveToy}");
        }
        else
        {
            Console.WriteLine("Нет подходящих игрушек для детей 2-3 лет.");
        }
    }

    public static void Task6()
    {
        try
        {
            Console.Write("Введите кол-во генерируемых чисел: ");
            var n = int.Parse(Console.ReadLine());

            FileTasks.GenerateSingleNumberTextFile("./task6.txt", n);
            Console.WriteLine($"Сгенерирован файл {Path.Combine(Directory.GetCurrentDirectory(), "task6.txt")}");
            long fileSize = new FileInfo("task6.txt").Length;
            Console.WriteLine($"Размер сгенерированного файла: {fileSize} байт");

            Console.Write("Введите последнюю цифру тех элементов, чья сумма вам нужна: ");
            var lastDigit = int.Parse(Console.ReadLine());

            var result = FileTasks.SumElementsEndingWith("./task6.txt", lastDigit);
            Console.WriteLine($"Сумма элементов, заканчивающихся на {lastDigit}, равна {result}");
        }
        catch (FormatException) 
        {            
            Console.WriteLine("Ошибка: неверный ввод. Убедитесь, что вы ввели именно число.");
        }
    }

    public static void Task7()
    {
        try
        {
            Console.Write("Введите кол-во генерируемых строк чисел: ");
            var lines = int.Parse(Console.ReadLine());

            Console.Write("Введите кол-во генерируемых чисел в строке: ");
            var n = int.Parse(Console.ReadLine());

            FileTasks.GenerateMultiNumberTextFile("./task7.txt", lines, n);
            Console.WriteLine($"Сгенерирован файл {Path.Combine(Directory.GetCurrentDirectory(), "task7.txt")}");
            long fileSize = new FileInfo("task7.txt").Length;
            Console.WriteLine($"Размер сгенерированного файла: {fileSize} байт");

            var result = FileTasks.DifferenceBetweenFirstAndMin("./task7.txt");
            Console.WriteLine($"Разница между первым и минимальным числами равна {result}");
        }
        catch (FormatException) 
        {            
            Console.WriteLine("Ошибка: неверный ввод. Убедитесь, что вы ввели именно число.");
        }
    }

    public static void Task8()
    {
        try {
            FileTasks.CopyLinesWithoutPunctuation("./task8.txt", "./task8_mod.txt");
            Console.WriteLine($"Строки без знаков препинания записаны в {Path.Combine(Directory.GetCurrentDirectory(), "task8_mod.txt")}");
        }
        catch (FileNotFoundException) {
            System.Console.WriteLine("Ошибка: файла task8.txt не существует.");
        }
    }
}