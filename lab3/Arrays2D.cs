namespace lab3;

public class Arrays2D
{
    public int[,] Matrix { get; set; }
    
    public Arrays2D()
    {
        try
        {
            Console.WriteLine("Введите кол-во столбцов двумерного массива (n): ");
            var input = Console.ReadLine();
            var n = uint.Parse(input);

            Console.WriteLine("Введите кол-во строк двумерного массива (m): ");
            input = Console.ReadLine();
            var m = uint.Parse(input);
            
            Matrix = new int[m, n];

            Console.WriteLine($"В массиве {m + n - 1} диагоналей");

            int count = 1, length = 1, i = 0, j = (int)m - count;
            while (count <= m + n - 1)
            {
                Console.WriteLine($"Введите {length} элемент(ов), находящихся по {m - j} диагонали, через пробел: ");
                input = Console.ReadLine();
                
                var array = input.Split(' ').Select(int.Parse).ToArray();
                if (array.Length != length)
                {
                    Console.WriteLine("Вы ввели неверное кол-во значений, попробуйте еще раз");
                }
                else
                {
                    foreach (var num in array)
                    {
                        Matrix[j, i] = num;
                        i++;
                        j++;
                    }

                    count++;

                    if ((int)m - count >= 0)
                    {
                        i = 0;
                        j = (int)m - count;
                        if (length < n) length++;
                    }
                    else
                    {
                        i = count - (int)m;
                        j = 0;
                        length--;
                    }
                }
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: неверный ввод. Убедитесь, что вы ввели именно число.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Ошибка: неверный ввод. Убедитесь, что вы ввели корректное значение.");
        }
    }
    
    public Arrays2D(int n, int m)
    {
        Matrix = new int[m, n];

        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"Элемент [{i},{j}]: ");
                Matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }

    public Arrays2D(int n)
    {
        Matrix = new int[n, n];

        int i = 0, j = 0, count = 1;
        var step = n;

        var direction = true; // true - идем вниз и вправо, false - вверх и влево

        while (step > 0)
        {
            if (direction)
            {
                for (var c = 0; c < step; c++)
                {
                    Matrix[j, i] = count;
                    j++;
                    count++;
                }

                j--;
                i++;
                step--;

                for (var c = 0; c < step; c++)
                {
                    Matrix[j, i] = count;
                    i++;
                    count++;
                }

                i--;
                j--;
            }
            else
            {
                for (var c = step; c > 0; c--)
                {
                    Matrix[j, i] = count;
                    j--;
                    count++;
                }

                j++;
                i--;
                step--;

                for (var c = step; c > 0; c--)
                {
                    Matrix[j, i] = count;
                    i--;
                    count++;
                }

                i++;
                j++;
            }
            
            direction = !direction;
        }
    }

    public Arrays2D(int n, int m, int ceiling)
    {
        Matrix = new int[n, m];
        var random = new Random();

        for (var i = 0; i < n; i++)
        {
            var row = new int[n];

            for (var j = 0; j < n; j++)
            {
                row[j] = random.Next(0, ceiling);
            }

            Array.Sort(row);
            Array.Reverse(row);

            for (var j = 0; j < n; j++)
            {
                Matrix[i, j] = row[j];
            }
        }
    }

    public static void VotesCount(bool[,] votes)
    {
        int sameVote = 0, diffVote = 0;

        for (var i = 0; i < votes.GetLength(1); i++)
        {
            if (votes[0, i] == votes[1, i]) sameVote++;
            else diffVote++;
        }
        
        if (sameVote > diffVote) 
            Console.WriteLine("Депутатов, кто оба раза проголосовал одинаково, больше, чем тех, кто изменил свое решение");
        else 
            Console.WriteLine("Депутатов, кто изменил свое решение, больше, чем тех, кто оба раза проголосовал одинаково");
    }

    public Arrays2D Transpose()
    {
        var rows = Matrix.GetLength(0);
        var cols = Matrix.GetLength(1);

        var transposed = new Arrays2D(rows, cols, 0);

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                transposed.Matrix[j, i] = Matrix[i, j];
            }
        }

        return transposed;
    }
    
    public static Arrays2D operator +(Arrays2D m1, Arrays2D m2)
    {
        var newM = new Arrays2D(m1.Matrix.GetLength(0), m1.Matrix.GetLength(1), 0);

        for (var i = 0; i < m1.Matrix.GetLength(0); i++)
        {
            for (var j = 0; j < m1.Matrix.GetLength(1); j++)
            {
                newM.Matrix[i, j] = m1.Matrix[i, j] + m2.Matrix[i, j];
            }
        }
        
        return newM;
    }

    public static Arrays2D operator -(Arrays2D m1, Arrays2D m2)
    {
        var newM = new Arrays2D(m1.Matrix.GetLength(0), m1.Matrix.GetLength(1), 0);

        for (var i = 0; i < m1.Matrix.GetLength(0); i++)
        {
            for (var j = 0; j < m1.Matrix.GetLength(1); j++)
            {
                newM.Matrix[i, j] = m1.Matrix[i, j] - m2.Matrix[i, j];
            }
        }
        
        return newM;
    }
    
    public static Arrays2D operator *(Arrays2D m1, Arrays2D m2)
    {
        var rows1 = m1.Matrix.GetLength(0);
        var cols1 = m1.Matrix.GetLength(1);
        var rows2 = m2.Matrix.GetLength(0);
        var cols2 = m2.Matrix.GetLength(1);

        if (cols1 != rows2)
        {
            throw new InvalidOperationException("Ошибка: матрицы не могут быть перемножены. Количество столбцов первой матрицы должно совпадать с количеством строк второй.");
        }

        var newM = new Arrays2D(rows1, cols2, 0);

        for (var i = 0; i < rows1; i++)
        {
            for (var j = 0; j < cols2; j++)
            {
                var sum = 0;
                for (var k = 0; k < cols1; k++)
                {
                    sum += m1.Matrix[i, k] * m2.Matrix[k, j];
                }
                newM.Matrix[i, j] = sum;
            }
        }

        return newM;
    }

    public static Arrays2D operator *(int num, Arrays2D m1)
    {
        var newM = new Arrays2D(m1.Matrix.GetLength(0), m1.Matrix.GetLength(1), 0);
        
        for (var i = 0; i < m1.Matrix.GetLength(0); i++)
        {
            for (var j = 0; j < m1.Matrix.GetLength(1); j++)
            {
                newM.Matrix[i, j] = num * m1.Matrix[i, j];
            }
        }
        
        return newM;
    }

    public override string ToString()
    {
        return string.Join(Environment.NewLine,
            Enumerable.Range(0, Matrix.GetUpperBound(0) + 1)
                .Select(i => "(" + string.Join("\t", Enumerable.Range(0, Matrix.GetUpperBound(1) + 1)
                    .Select(j => Matrix[i, j].ToString("F2"))) + ")"));
    }
}