// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07


int[,] FillArray(int[,] array) //Функция заполняет массив двузначными целыми числами по спирали с числа 10 (для красоты)
{
    int count1 = 0;
    int number = 10;
    while (count1 < (array.GetLength(1) - 1 - count1))
    {
        for (int i = count1; i < (array.GetLength(1) - count1); i++)
        {
            array[count1, i] = number;
            number++;
        }
        for (int j = count1 + 1; j < (array.GetLength(0) - count1); j++)
        {
            array[j, (array.GetLength(1) - 1) - count1] = number;
            number++;
        }
        for (int k = ((array.GetLength(1) - 1) - (count1 + 1)); k >= count1; k -= 1)
        {
            array[(array.GetLength(0) - 1) - count1, k] = number;
            number++;
        }
        for (int l = ((array.GetLength(0) - 1) - (count1 + 1)); l >= (count1 + 1); l -= 1)
        {
            array[l, count1] = number;
            number++;
        }
        count1++;
    }

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

int[,] array = new int[4, 4]; //Взял массив 4 на 4, но функция работает для любого квадратного массива
array = FillArray(array);
PrintArray(array);

