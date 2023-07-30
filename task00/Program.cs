// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

using System.Globalization;
using System.Net.Sockets;
using System.Runtime.CompilerServices;

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

int[,] SortArray(int[,] array) //Функция сортирует строки массива
{
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int max = array[i, j];
            for (int k = j + 1; k < array.GetLength(1); k++)
            {
                int temp = array[i, j];
                if (array[i, k] > max)
                {
                    max = array[i, k];
                    array[i, j] = array[i, k];
                    array[i, k] = temp;
                }
            }

        }
    return array;
}

int[,] mainArray = FillArray(GetNumber("Введите количество строк:"),
                                         GetNumber("Введите количество столбцов:"));
PrintArray(mainArray);
Console.WriteLine();
mainArray = SortArray(mainArray);
PrintArray(mainArray);
