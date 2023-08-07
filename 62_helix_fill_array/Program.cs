// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

void PrintTwoDimensionalArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j].ToString("D2")} "); //D2 делает так, чтобы все были
            //по два знака. Если нужно по три, то D3 и т.д.
        }
        Console.WriteLine();
    }
}

int[,] GenerateTwoDimensionalArray(int rows, int columns)
{
    int[,] workingArray = new int[rows, columns];
    int size = rows * columns; // чтобы знать, сколько всего уместится элементов
    int startRow = 0, lastRow = rows - 1;
    int startColumn = 0, lastColumn = columns - 1;
    int number = 01;

    while (number <= size) //чтобы не выйти за пределы массива
    {
        for (int i = startColumn; i <= lastColumn; i++)
        {
            workingArray[startRow, i] = number++;
        }
        startRow++;

        for (int i = startRow; i <= lastRow; i++)
        {
            workingArray[i, lastColumn] = number++;
        }
        lastColumn--;

        if (lastRow >= startRow)
        {
            for (int i = lastColumn; i >= startColumn; i--)
                workingArray[lastRow, i] = number++;
        }
        lastRow--;

        if (lastColumn >= startColumn)
        {
            for (int i = lastRow; i >= startRow; i--)
                workingArray[i, startColumn] = number++;
        }
        startColumn++;
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
int[,] array = GenerateTwoDimensionalArray(rows, columns);
PrintTwoDimensionalArray(array);