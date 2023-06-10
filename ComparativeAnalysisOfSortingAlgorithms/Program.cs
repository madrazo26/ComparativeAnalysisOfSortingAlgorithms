using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        int randNumber;
        Console.Write("Введите желаемую размерность массива для рандомного заполнения(0-2^31):");
        while (true)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out randNumber))
                if (randNumber>0)
                break; // обработка при успехе 
            else // обработка при ошибке
            {
                Console.WriteLine("Ошибка, неверный формат данных.");
                return;
            }
        }
        int[] array = new int[randNumber];
        int[] buff = new int[randNumber];
        Random rand = new Random();
        for (int i = 0; i < array.Length; i++)
            array[i] = rand.Next(); // [0 - 2^31)
        PrintTheArray(array);
        Stopwatch sw = new Stopwatch();
        for (int i = 0; i < array.Length; i++)
            buff[i] = array[i];
        sw.Start();
        QuickSort(buff, 0, buff.Length - 1);
        sw.Stop();
        Console.WriteLine("\nПродолжительность быстрой сортировки: " + sw.ElapsedMilliseconds + " мс");
        PrintTheArray(buff);
        for (int i = 0; i < array.Length; i++)
            buff[i] = array[i];
        sw.Start();
        BubbleSort(buff);// Сортировка пузырьком
        sw.Stop();
        Console.WriteLine("\nПродолжительность сортировки пузырьком: " + sw.ElapsedMilliseconds + " мс");
        PrintTheArray(buff);
        for (int i = 0; i < array.Length; i++)
            buff[i] = array[i];
        sw.Reset();
        sw.Start();
        InsertionSort(buff);// сортировка вставками
        sw.Stop();
        Console.WriteLine("\nПродолжительность сортировки вставками: " + sw.ElapsedMilliseconds + " мс");
        PrintTheArray(buff);
        for (int i = 0; i < array.Length; i++)
            buff[i] = array[i];
        sw.Reset();
        sw.Start();
        ShakerSort(buff);// Сортировка перемешиванием
        sw.Stop();
        Console.WriteLine("\nПродолжительность сортировки перемешиванием: " + sw.ElapsedMilliseconds + " мс");
        PrintTheArray(buff);
        for (int i = 0; i < array.Length; i++)
            buff[i] = array[i];
        sw.Reset();
        sw.Start();
        SelectionSort(buff);// Сортировка выбором
        sw.Stop();
        Console.WriteLine("\nПродолжительность сортировки выбором: " + sw.ElapsedMilliseconds + " мс");
        PrintTheArray(buff);
        Console.ReadLine();
    }

    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    static void ShakerSort(int[] arr)
    {
        int left = 0;
        int right = arr.Length - 1;
        while (left < right)
        {
            for (int i = left; i < right; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    int temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;
                }
            }
            right--;

            for (int i = right; i > left; i--)
            {
                if (arr[i] < arr[i - 1])
                {
                    int temp = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = temp;
                }
            }
            left++;
        }
    }

    static void QuickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);
            QuickSort(arr, left, pivot - 1);
            QuickSort(arr, pivot + 1, right);
        }
    }

    static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[right];
        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

        }
        int temp2 = arr[i + 1];
        arr[i + 1] = arr[right];
        arr[right] = temp2;
        return i + 1;
    }

    static void InsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
    }

    static void SelectionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = arr[i];
            arr[i] = arr[minIndex];
            arr[minIndex] = temp;
        }
    }

    static void PrintTheArray(int[] arr)
    {
        Console.Write("Вывести массив на консоль? y - да, другие кнопки - нет\n");
        char key;
        key = Console.ReadKey(true).KeyChar;
        switch (key)
        {
            case 'y':
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        Console.Write(" " + arr[i] + "|");
                    }
                    break;
                }
            default :
                Console.Write("Ожидайте, идет сортировка...\n");
                break;
        }
    }
}