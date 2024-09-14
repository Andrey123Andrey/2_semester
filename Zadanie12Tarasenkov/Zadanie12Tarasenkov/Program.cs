using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath, outputFilePath, name, text;

        Console.Write("Введите имя создаваемого файла с координатами: ");
        name = Console.ReadLine();
        inputFilePath = Environment.CurrentDirectory + @"\" + name + ".txt";
        FileStream file = new FileStream(inputFilePath, FileMode.OpenOrCreate);
        StreamWriter stream = new StreamWriter(file);

        Console.Write("Введите точки: ");
        text = Console.ReadLine();
        stream.Write($"{text}");
        stream.Close();
        file.Close();

        StreamWriter stream1;
        outputFilePath = Environment.CurrentDirectory + @"\segments.txt";
        stream1 = new StreamWriter(outputFilePath, false, Encoding.GetEncoding(1251));
        stream1.Close();

        // Чтение координат из файла
        string[] lines = File.ReadAllLines(inputFilePath);
            List<double[]> points = new List<double[]>();

            foreach (string line in lines)
            {
                string[] pointStrings = line.Split(';');
                foreach (string pointString in pointStrings)
                {
                    string[] coordinates = pointString.Split(',');
                    double[] point = new double[2];
                    point[0] = double.Parse(coordinates[0]);
                    point[1] = double.Parse(coordinates[1]);
                    points.Add(point);
                }
            }

            // Использование StringBuilder для хранения пар точек
            StringBuilder segments = new StringBuilder();

            while (points.Count > 1)
            {
                double minDistance = double.MaxValue;
                int index1 = -1, index2 = -1;

                // Перебор всех пар точек
                for (int i = 0; i < points.Count; i++)
                {
                    for (int j = i + 1; j < points.Count; j++)
                    {
                        double distance = CalculateDistance(points[i], points[j]);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            index1 = i;
                            index2 = j;
                        }
                    }
                }

                // Запись пары точек с минимальным расстоянием
                if (index1 != -1 && index2 != -1)
                {
                    segments.AppendLine($"{points[index1][0]}, {points[index1][1]}; {points[index2][0]}, {points[index2][1]}");

                    // Удаление использованных точек
                    points.RemoveAt(Math.Max(index1, index2)); // Удаляем точку с большим индексом
                    points.RemoveAt(Math.Min(index1, index2)); // Удаляем точку с меньшим индексом
                }
            }

            // Проверка на наличие сегментов перед записью в файл
            if (segments.Length > 0)
            {
                File.WriteAllText(outputFilePath, segments.ToString()); // Запись в файл
                Console.WriteLine($"Данные внесены в файл {outputFilePath}");
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("Нет сегментов для записи.");
                Console.ReadKey(true);
            }
        
    }
    // Метод для вычисления расстояния между двумя точками
    static double CalculateDistance(double[] point1, double[] point2)
    {
        return Math.Sqrt(Math.Pow(point1[0] - point2[0], 2) + Math.Pow(point1[1] - point2[1], 2));
    }
}
