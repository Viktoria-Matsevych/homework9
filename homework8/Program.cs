using System.ComponentModel.Design;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

string folder = Directory.GetCurrentDirectory();

string fileA = Path.Combine(folder, "a.txt");
string fileB = Path.Combine(folder, "b.txt");
string fileC = Path.Combine(folder, "c.txt");

if (!File.Exists(fileA))
{
    File.WriteAllText(fileA,
        "2 3\n1 2 3\n4 5 6");
}

if (!File.Exists(fileB))
{
    File.WriteAllText(fileB,
        "3 2\n7 8\n9 10\n11 12");
}

try
{
    int[,] a;

    using (StreamReader reader = new StreamReader(fileA))
    {
        string[] size = reader.ReadLine().Split(
            ' ', StringSplitOptions.RemoveEmptyEntries);

        int n = int.Parse(size[0]);
        int m = int.Parse(size[1]);

        a = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            string[] numbers = reader.ReadLine().Split(
                ' ', StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < m; j++)
            {
                a[i, j] = int.Parse(numbers[j]);
            }
        }
    }

    int[,] b;

    using (StreamReader reader = new StreamReader(fileB))
    {
        string[] size = reader.ReadLine().Split(
            ' ', StringSplitOptions.RemoveEmptyEntries);

        int p = int.Parse(size[0]);
        int q = int.Parse(size[1]);

        b = new int[p, q];

        for (int i = 0; i < p; i++)
        {
            string[] numbers = reader.ReadLine().Split(
                ' ', StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < q; j++)
            {
                b[i, j] = int.Parse(numbers[j]);
            }
        }
    }

    if (a.GetLength(1) != b.GetLength(0))
    {
        Console.WriteLine("Матриці неможливо перемножити!");
    }
    else
    {
        int n = a.GetLength(0);
        int m = a.GetLength(1);
        int q = b.GetLength(1);

        int[,] c = new int[n, q];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < q; j++)
            {
                for (int k = 0; k < m; k++)
                {
                    c[i, j] += a[i, k] * b[k, j];
                }
            }
        }

        using (StreamWriter writer = new StreamWriter(fileC))
        {
            writer.WriteLine(n + " " + q);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < q; j++)
                {
                    writer.Write(c[i, j] + " ");
                }

                writer.WriteLine();
            }
        }

        Console.WriteLine("Матриці успішно перемножено!");
        Console.WriteLine("Результат записано у файл c.txt");
        Console.WriteLine("Шлях до файлу: " + fileC);
    }
}
catch (Exception ex)
{
    Console.WriteLine("Помилка: " + ex.Message);
}
