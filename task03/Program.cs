// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

int GetNumber(string text) // Функция запрашивает у пользователя число
{
    Console.Write($"{text} ");
    return int.Parse(Console.ReadLine()!);
}

int[,,] FillArray(int lines, int columns, int depth) //Функция заполняет массив случайными целыми числами от 0 до 99
{
    int[,,] array = new int[lines, columns, depth];
    Random random = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            for (int k = 0; k < array.GetLength(2); k++)
            {
                    array[i, j, k] = random.Next(0, 100);
                    if(k!=0)
                    {
                    while (array[i, j, k]==array[i,j,k-1])
                    array[i, j, k] = random.Next(0, 100);
                    }
            }

    return array;
}

void PrintArray(int[,,] array) //Функция печатает массив
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
                Console.Write($"{array[i, j, k]}({i}, {j}, {k}) ");

            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

int[,,] mainArray = FillArray(GetNumber("Введите глубину:"),
                           GetNumber("Введите количество строк:"),
                           GetNumber("Введите столбцов:"));

PrintArray(mainArray);
Console.WriteLine();
