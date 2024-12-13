internal class Program
{
    static void Print<T>(T[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write($"{item,-10}");
        }
        Console.WriteLine();
    }

    static void Print<T>(T[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write($"{arr[i, j],-10} ");
            }
            Console.WriteLine();
        }
    }

    static void Fill(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"Enter A[{i}] = ");
            arr[i] = int.Parse(Console.ReadLine());
        }
    }

    static void Fill(double[,] arr, double min = 0, double max = 50)
    {
        Random rnd = new Random();
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = rnd.NextDouble() * (max - min) + min;
            }
        }
    }

    static void Fill(int[,] arr, int min, int max)
    {
        Random rnd = new Random();
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                arr[i, j] = rnd.Next(min, max + 1);
            }
        }
    }

    private static void Main(string[] args)
    {
        // Task 1
        int[] A = new int[5];
        double[,] B = new double[3, 4];

        Fill(A);
        Fill(B);

        Console.WriteLine("\nArray A:");
        Print(A);

        Console.WriteLine("\nArray B:");
        Print(B);

        double maxEl = Math.Max(A.Max(), B.Cast<double>().Max());
        double minEl = Math.Min(A.Min(), B.Cast<double>().Min());
        Console.WriteLine($"\nMax: {maxEl}");
        Console.WriteLine($"Min: {minEl}");

        double Sum = A.Sum() + B.Cast<double>().Sum();
        Console.WriteLine($"Sum: {Sum}");

        double Product = A.Aggregate(1, (prod, x) => prod * x) * B.Cast<double>().Aggregate(1.0, (prod, x) => prod * x);
        Console.WriteLine($"Product: {Product}");

        int evenSum = A.Where(x => x % 2 == 0).Sum();
        Console.WriteLine($"Sum even in A: {evenSum}");

        double oddSum = 0;
        for (int j = 1; j < B.GetLength(1); j += 2)
        {
            for (int i = 0; i < B.GetLength(0); i++)
            {
                oddSum += B[i, j];
            }
        }
        Console.WriteLine($"Sum odd in B: {oddSum}");

        // Task 2
        int[,] C = new int[5, 5];
        Fill(C, 100, 200);

        Console.WriteLine("\nArray C:");
        Print(C);

        int minElC = C[0, 0], maxElC = C[0, 0];
        int minI = 0, maxI = 0;

        for (int i = 0; i < C.GetLength(0); i++)
        {
            for (int j = 0; j < C.GetLength(1); j++)
            {
                if (C[i, j] < minElC)
                {
                    minElC = C[i, j];
                    minI = i * C.GetLength(1) + j;
                }
                if (C[i, j] > maxElC)
                {
                    maxElC = C[i, j];
                    maxI = i * C.GetLength(1) + j;
                }
            }
        }

        Console.WriteLine($"\nMin: {minElC}");
        Console.WriteLine($"Max: {maxElC}");

        int start = Math.Min(minI, maxI);
        int end = Math.Max(minI, maxI);
        int sumBetween = 0;

        for (int i = start + 1; i < end; i++)
        {
            int row = i / C.GetLength(1);
            int col = i % C.GetLength(1);
            sumBetween += C[row, col];
        }

        Console.WriteLine($"Sum between min and max: {sumBetween}");
    }
}
