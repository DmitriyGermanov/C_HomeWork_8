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

int[,,] FillArray(int depth, int lines, int columns) //Функция заполняет трехмерный массив случайными неповторяющемися целыми числами от 0 до 999
{
    int[,,] array = new int[depth, lines, columns];
    int[] arrayLine = new int[array.GetLength(0) * array.GetLength(1) * array.GetLength(2)];
    Random random = new Random();
    for (int i = 0; i < arrayLine.Length; i++)
    {
        arrayLine[i] = random.Next(0, 1000);
        if (i != 0)
        {
            for (int j = 0; j < i; j++)
            {
                while (arrayLine[j] == arrayLine[i])
                {
                    arrayLine[j] = random.Next(0, 1000);
                }
            }
        }
    }
    int count = 0;
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            for (int k = 0; k < array.GetLength(2); k++)
            {
                array[i, j, k] = arrayLine[count];
                count++;
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
if ((mainArray.GetLength(0) * mainArray.GetLength(1) * mainArray.GetLength(2)) > 999)
    Console.WriteLine("Количество элементов массива более 999, уменьшите количество строк, столбцов или глубину");
else
{
    PrintArray(mainArray);
    Console.WriteLine();
}
