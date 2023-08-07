// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет 
// находить строку с наименьшей суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки 
// с наименьшей суммой элементов: 1 строка

int ShowTheLeastElementsSumRow(int[,] array)
{
    int minSum = 0;
    int rowNumber = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int tempSum = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            tempSum = tempSum + array[i, j];
        }
        if (i == 0) minSum = tempSum;
        if (tempSum < minSum)
        {
            minSum = tempSum;
            rowNumber = i;
        }
    }
    return rowNumber;
}

void PrintTwoDimensionalArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t", -3);
        }
        Console.WriteLine();
    }
}

int[,] GenerateTwoDimensionalArray(int rows, int columns, int startValue, int finishValue)
{
    int[,] workingArray = new int[rows, columns];
    for (int i = 0; i < workingArray.GetLength(0); i++)
    {
        for (int j = 0; j < workingArray.GetLength(1); j++)
        {
            workingArray[i, j] = new Random().Next(startValue, finishValue + 1);
        }
    }
    return workingArray;
}

int GetInput(string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int rows = GetInput("Введите количество строк массива: ");
int columns = GetInput("Введите количество столбцов массива: ");

if (rows == columns) Console.WriteLine("Массив квадратный, а нужен прямоугольный.");
else
{
    int startValue = GetInput("Введите минимальное число: ");
    int finishValue = GetInput("Введите максимальное число: ");
    int[,] array = GenerateTwoDimensionalArray(rows, columns, startValue, finishValue);
    PrintTwoDimensionalArray(array);
    Console.WriteLine();
    int rowNumber = ShowTheLeastElementsSumRow(array);
    Console.WriteLine($"Строка с наименьшей суммой элементов (если ты программист): {rowNumber} строка.");
    Console.WriteLine($"Строка с наименьшей суммой элементов (если ты не программист): {rowNumber + 1} строка.");
}