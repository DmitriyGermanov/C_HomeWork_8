// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

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

void SmallestRow(int[,] array)  //Функция выводит номер строки с наименьшим значением суммы элементов
{
    int[] summOfLines = new int[array.GetLength(0)];
    int minIndex = 0;

    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            summOfLines[i] += array[i, j];

    for (int i = 1; i < summOfLines.Length; i++)
    {
        if(summOfLines[i]<summOfLines[minIndex])
            minIndex = i;
    }
    Console.WriteLine($"Номер строки с наименьшей суммой: {minIndex+1}");
}

int lines = GetNumber("Введите количество строк:");
int columns = GetNumber("Введите количество столбцов");
if (lines == columns)
    Console.WriteLine("Ошибка - количество строк не должно быть равно количеству столбцов");
else
{
    int[,] mainArray = FillArray(lines, columns);
    PrintArray(mainArray);
    Console.WriteLine();
    SmallestRow(mainArray);
}