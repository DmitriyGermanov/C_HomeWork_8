// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int GetNumber(string text) // Функция запрашивает у пользователя число
{
    Console.Write($"{text} ");
    return int.Parse(Console.ReadLine()!);
}

int[,] FillArray(int lines, int columns) //Функция заполняет массив случайными целыми числами от 0 до 99
{
    int[,] array = new int[lines, columns];
    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            array[i, j] = random.Next(0, 100);

    return array;
}

void PrintArray(int[,] array) //Функция печатает массив
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write($"{array[i, j]} ");

        Console.WriteLine();
    }
}

int[,] MatrixMultiplication(int[,] matrix1, int[,] matrix2)
{
    int[,] resultMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            for (int k = 0; k < matrix2.GetLength(0); k++)
                resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
        }
    }
    return resultMatrix;
}

int[,] firstArray = FillArray(GetNumber("Введите количество строк первого массива"),
                              GetNumber("Введите количество столбцов первого массива"));
int[,] secondArray = FillArray(GetNumber("Введите количество строк второго массива"),
                              GetNumber("Введите количество столбцов второго массива"));
if (firstArray.GetLength(1) != secondArray.GetLength(0))
    Console.WriteLine("Количество столбцов 1-й матрицы должно быть равно количеству строк 2-й матрицы");
else
{
    PrintArray(firstArray);
    Console.WriteLine();
    PrintArray(secondArray);
    Console.WriteLine();
    int[,] result = MatrixMultiplication(firstArray, secondArray);
    PrintArray(result);
}