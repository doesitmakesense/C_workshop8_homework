// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить 
// произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

// Новый массив с колвом строк из первого, колвом столбцов из второго

int[,] FindProductOfTwoMatrixes(int[,] array, int[,] array2)
{
    int[,] newArray = new int[array.GetLength(0), array2.GetLength(1)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array2.GetLength(1); j++)
        {
            for (int k = 0; k < array2.GetLength(0); k++)
            {
                newArray[i, j] = newArray[i, j] + array[i, k] * array2[k, j];
            }
        }
    }
    return newArray;
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

int rows = GetInput("Введите количество строк для первой матрицы: ");
int columns = GetInput("Введите количество столбцов для первой матрицы: ");
int startValue = GetInput("Введите минимальное число для первой матрицы: ");
int finishValue = GetInput("Введите максимальное число для первой матрицы: ");
int[,] array = GenerateTwoDimensionalArray(rows, columns, startValue, finishValue);
PrintTwoDimensionalArray(array);
Console.WriteLine();

int rows2 = GetInput("Введите количество строк для второй матрицы: ");
int columns2 = GetInput("Введите количество столбцов для второй матрицы: ");
int startValue2 = GetInput("Введите минимальное число для второй матрицы: ");
int finishValue2 = GetInput("Введите максимальное число для второй матрицы: ");
int[,] array2 = GenerateTwoDimensionalArray(rows2, columns2, startValue2, finishValue2);
PrintTwoDimensionalArray(array2);

if (array.GetLength(1) != array2.GetLength(0)) // столбцы 1 д.б. равны строкам 2 обяз
{
    Console.WriteLine("Невозможно перемножить матрицы!");
}
else
{
    Console.WriteLine();
    int[,] newArray = FindProductOfTwoMatrixes(array, array2);
    Console.WriteLine("В результате произведения двух матриц получилась матрица:");
    PrintTwoDimensionalArray(newArray);
}