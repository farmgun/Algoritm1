using System;
using System.Linq;

namespace Algoritm1
{
    
    public class Algoritm1
    {
        public static void Change(ref int num1, ref int num2)
        {
            var temp = num1;
            num1 = num2;
            num2 = temp;
        }
        public static int[] Sort( int[] numbers)
        {
            for (var i = 0; i < numbers.Length; i++)
            {
                var j = i;
                var key = numbers[i];
                while ((j >= 1) && (numbers[j - 1] > key))
                {
                    Change(ref numbers[j - 1], ref numbers[j]);
                    j--;
                }

                numbers[j] = key;
            }
            return numbers;
        }
    }

    class Algoritm2
    {
        static void Merge(int[] array, int Index1, int Index2, int highIndex)
        {
            var temp = Index1;
            var temp1 = Index2 + 1;
            var tempArray = new int[highIndex - Index1 + 1];
            var index = 0;

            while ((temp <= Index2) && (temp1 <= highIndex))
            {
                if (array[temp] < array[temp1])
                {
                    tempArray[index] = array[temp];
                    temp++;
                }
                else
                {
                    tempArray[index] = array[temp1];
                    temp1++;
                }

                index++;
            }

            for (var i = temp; i <= Index2; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = temp1; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[Index1 + i] = tempArray[i];
            }
        }
        public static int[] MergeSort(int[] array, int Index1, int highIndex)
        {
            if (Index1 < highIndex)
            {
                var Index2 = (Index1 + highIndex) / 2;
                MergeSort(array, Index1, Index2);
                MergeSort(array, Index2 + 1, highIndex);
                Merge(array, Index1, Index2, highIndex);
            }

            return array;
        }

        public static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }
    }

    class Algoritm3
    {
        static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }
        static int Partition(int[] array, int index1, int index2)
        {
            var temp = index1 - 1;
            for (var i = index1; i < index2; i++)
            {
                if (array[i] < array[index2])
                {
                    temp++;
                    Swap(ref array[temp], ref array[i]);
                }
            }

            temp++;
            Swap(ref array[temp], ref array[index2]);
            return temp;
        }
        public static int[] QuickSort(int[] array, int index1, int index2)
        {
            if (index1 >= index2)
            {
                return array;
            }

            var tempIndex = Partition(array, index1, index2);
            QuickSort(array, index1, tempIndex - 1);
            QuickSort(array, tempIndex + 1, index2);

            return array;
        }

        public static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }
    }

    class Algoritm4
    {
        static void Swap(ref int index1, ref int index2)
        {
            var temp = index1;
            index1 = index2;
            index2 = temp;
        }
        public static int[] ShakerSort(int[] array)
        {
            for (var i = 0; i < array.Length / 2; i++)
            {
                var swapFlag = false;
                for (var j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                for (var j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        swapFlag = true;
                    }
                }

                if (!swapFlag)
                {
                    break;
                }
            }

            return array;
        }
    }

    class Algoritm5
    {
        static int pyramid(double[] array, int i, int N)
        {
            int imax;
            double buf;
            if ((2 * i + 2) < N)
            {
                if (array[2 * i + 1] < array[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (array[i] < array[imax])
            {
                buf = array[i];
                array[i] = array[imax];
                array[imax] = buf;
                if (imax < N / 2) i = imax;
            }
            return i;
        }
        public static void sorting(double[] array, int len)
        {
            for (int i = len / 2 - 1; i >= 0; --i)
            {
                long tempA = i;
                i = pyramid(array, i, len);
                if (tempA != i) ++i;
            }

            double buf;
            for (int k = len - 1; k > 0; --k)
            {
                buf = array[0];
                array[0] = array[k];
                array[k] = buf;
                int i = 0, tempA = -1;
                while (i != tempA)
                {
                    tempA = i;
                    i = pyramid(array, i, k);
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2, 5, 1, 3, 4 };
            double[] arr = new double[51];
            Random rd = new Random();
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = rd.Next(1, 50);
            }
            Console.WriteLine("Впорядкований масив: {0}", string.Join(", ", Algoritm1.Sort(numbers)));
            Console.WriteLine("Впорядкований масив: {0}", string.Join(", ", Algoritm2.MergeSort(numbers)));
            Console.WriteLine("Впорядкований масив: {0}", string.Join(", ", Algoritm3.QuickSort(numbers)));
            Console.WriteLine("Впорядкований масив: {0}", string.Join(", ", Algoritm4.ShakerSort(numbers)));
            Algoritm5.sorting(arr, arr.Length);
            foreach (double x in arr)
            {
               Console.Write(x + " ");
            }
        }
    }
}

    
