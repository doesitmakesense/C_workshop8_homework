// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию 
// элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

void SortRowElements(int[,] array)
{
    for (int k = 0; k < array.GetLength(1); k++)
    {
        for (int l = 0; l < array.GetLength(1); l++)
        {
            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int j = 0; j < array.GetLength(1) - 1; j++)
                {
                    if (array[i, j] < array[i, j + 1])
                    {
                        int temp = array[i, j];
                        array[i, j] = array[i, j + 1];
                        array[i, j + 1] = temp;
                    }
                }
            }
        }
    }
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
int startValue = GetInput("Введите минимальное число: ");
int finishValue = GetInput("Введите максимальное число: ");
int[,] array = GenerateTwoDimensionalArray(rows, columns, startValue, finishValue); 
PrintTwoDimensionalArray(array);
Console.WriteLine();
Console.WriteLine("Строки отсортированы по убыванию:");
SortRowElements(array);
PrintTwoDimensionalArray(array);