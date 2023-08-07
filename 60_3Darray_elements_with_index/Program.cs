// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, 
// добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

void Print3DArray(int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                Console.Write($"{matrix[i, j, k]}({i},{j},{k})\t", -3);
            }
            Console.WriteLine();
        }
    }
}

bool Exam(int[,,] matrix, int num) // проверка, что числа не было в новом массиве
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
                if (matrix[i, j, k] == num)
                {
                    return false;
                }
            }
        }
    }
    return true;
}

int[,,] Generate3DArray(int[] array, int firstDim, int secondtDim, int thirdDim, int startValue, int finishValue)
{
    int[,,] matrix = new int[firstDim, secondtDim, thirdDim];
    for (int i = 0; i < firstDim; i++)
    {
        for (int j = 0; j < secondtDim; j++)
        {
            for (int k = 0; k < thirdDim; k++)
            {
                int num = new Random().Next(startValue, finishValue + 1);
                if (Exam(matrix, num)) matrix[i, j, k] = num;
                else k--;
            }
        }
    }
    return matrix;
}

int GetInput(string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int firstDim = GetInput("Введите первое измерение для массива: ");
int secondtDim = GetInput("Введите второе измерение для массива: ");
int thirdDim = GetInput("Введите третье измерение для массива: ");
int startValue = 10;
int finishValue = 99;
Random r = new Random();

//Enumerable.Range - генерирует последовательность чисел в заданном диапазоне
//OrderBy(x => r.Next()) - сортировка в рандомном виде
//ToArray() - превращение в массив
int[] array = Enumerable.Range(startValue, finishValue - startValue + 1).OrderBy(x => r.Next()).ToArray();
// Console.WriteLine($"[{String.Join(",", array)}]"); //чтобы убедиться, что нет повторов
int[,,] matrix = Generate3DArray(array, firstDim, secondtDim, thirdDim, startValue, finishValue);
Print3DArray(matrix);
