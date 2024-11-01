using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace lab3;

public static class FileTasks
{
    // Задание 4
    public static void GenerateBinaryFile(string filePath, int count)
    {
        var random = new Random();
        using (var writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            for (var i = 0; i < count; i++)
            {
                writer.Write(random.Next(1, 100)); // Случайные числа от 1 до 100
            }
        }
    }

    public static void RemoveDuplicatesFromBinaryFile(string inputFilePath, string outputFilePath)
    {
        var numbers = new List<int>();
        using (var reader = new BinaryReader(File.Open(inputFilePath, FileMode.Open)))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                var num = reader.ReadInt32();
                
                if (!numbers.Contains(num)) 
                {
                    System.Console.WriteLine($"Прочитано: {num}");
                    numbers.Add(num);
                }
            }
        }
        using (var writer = new BinaryWriter(File.Open(outputFilePath, FileMode.Create)))
        {
            var count = 0;
            foreach (var number in numbers)
            {
                count++;

                writer.Write(number);
            }

            System.Console.WriteLine($"Чисел без дубликатов: {count}");
        }
    }

    // Задание 5
    [Serializable]
    public struct Toy
    {
        public string Name;
        public decimal Price;
        public int MinAge;
        public int MaxAge;
    }

    public static void GenerateToyXmlFile(string filePath, List<Toy> toys)
    {
        var serializer = new XmlSerializer(typeof(List<Toy>));
        using (var writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, toys);
        }
    }

    public static string FindMostExpensiveToyForAge(string filePath, int minAge, int maxAge)
    {
        var serializer = new XmlSerializer(typeof(List<Toy>));
        List<Toy> toys;
        using (var reader = new StreamReader(filePath))
        {
            toys = (List<Toy>)serializer.Deserialize(reader);
        }
        
        return toys.Where(t => t.MinAge <= minAge && t.MaxAge >= maxAge)
                   .OrderByDescending(t => t.Price)
                   .FirstOrDefault().Name;
    }

    // Задание 6
    public static void GenerateSingleNumberTextFile(string filePath, int count)
    {
        var random = new Random();
        using (var writer = new StreamWriter(filePath))
        {
            for (var i = 0; i < count; i++)
            {
                writer.WriteLine(random.Next(1, 100)); // Случайные числа от 1 до 100
            }
        }
    }

    public static int SumElementsEndingWith(string filePath, int lastDigit)
    {
        var sum = 0;
        foreach (var line in File.ReadLines(filePath))
        {
            if (int.TryParse(line, out var number) && number % 10 == lastDigit)
            {
                sum += number;
            }
        }
        return sum;
    }

    // Задание 7
    public static void GenerateMultiNumberTextFile(string filePath, int lines, int numbersPerLine)
    {
        var random = new Random();
        using (var writer = new StreamWriter(filePath))
        {
            for (var i = 0; i < lines; i++)
            {
                var numbers = Enumerable.Range(0, numbersPerLine).Select(_ => random.Next(1, 100));
                writer.WriteLine(string.Join(" ", numbers));
            }
        }
    }

    public static int DifferenceBetweenFirstAndMin(string filePath)
    {
        int? firstNumber = null;
        var minNumber = int.MaxValue;

        foreach (var line in File.ReadLines(filePath))
        {
            foreach (var numStr in line.Split(' '))
            {
                if (int.TryParse(numStr, out var number))
                {
                    if (!firstNumber.HasValue) firstNumber = number;
                    if (number < minNumber) minNumber = number;
                }
            }
        }

        return firstNumber.HasValue ? firstNumber.Value - minNumber : 0;
    }

    // Задание 8
    public static void CopyLinesWithoutPunctuation(string inputFilePath, string outputFilePath)
    {
        var regex = new Regex(@"^[\w\s]+$"); // Только буквы и пробелы
        using (var writer = new StreamWriter(outputFilePath))
        {
            foreach (var line in File.ReadLines(inputFilePath))
            {
                if (regex.IsMatch(line))
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
