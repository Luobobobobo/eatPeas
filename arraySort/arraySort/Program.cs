using System;

namespace arraySort
{
    class Program
    {
        public static int[] arr = new int[] { 1, 20, 65, 30, 24, 22, 8, 33 };
        static void Main(string[] args)
        {
            Console.WriteLine("冒泡排序法：");
            Bubble_sort(arr);
            _outPut();
            Console.WriteLine("选择排序法：");
            selection_sort(arr);
            _outPut();
            Console.WriteLine("插入排序法：");
            insertion_sort(arr);
            _outPut();
            Console.WriteLine("希尔排序法：");
            shell_sort(arr);
            _outPut();
            Console.WriteLine("快速排序法：");
            quick_sort(arr, 0, arr.Length - 1);
            _outPut();
            Console.ReadKey();
        }
        public static void _outPut()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        //冒泡排序
        public static void Bubble_sort(int[] arr)
        {
            bool isSort = false;
            for (int i = 0; i < arr.Length; i++)
            {
                isSort = false;
                for (int j = arr.Length - 1; j > i; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                        isSort = true;
                    }
                }
                if (!isSort)
                {
                    break;
                }
            }
        }
        //选择排序
        public static void selection_sort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minNum = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minNum])
                    {
                        minNum = j;
                    }
                }
                if (i != minNum)
                {
                    int temp = arr[i];
                    arr[i] = arr[minNum];
                    arr[minNum] = temp;
                }
            }
        }
        //插入排序
        public static void insertion_sort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        //希尔排序
        public static void shell_sort(int[] arr)
        {
            int incre = arr.Length;
            while (true)
            {
                incre = incre / 2;
                for (int k = 0; k < incre; k++)
                {
                    for (int i = k + incre; i < arr.Length; i += incre)
                    {
                        for (int j = i; j > k; j -= incre)
                        {
                            if (arr[j] < arr[j - incre])
                            {
                                int temp = arr[j - incre];
                                arr[j - incre] = arr[j];
                                arr[j] = temp;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                if (incre == 1)
                {
                    break;
                }
            }
        }
        //快速排序
        public static void quick_sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int i = l;
                int j = r;
                int keyNum = arr[l];
                while (i < j)
                {
                    while (arr[j] >= keyNum && i < j)
                    {
                        j--;
                    }
                    if (i < j)
                    {
                        arr[i] = arr[j];
                        i++;
                    }
                    while (arr[i] < keyNum && i < j)
                    {
                        i++;
                    }
                    if (i < j)
                    {
                        arr[j] = arr[i];
                        j--;
                    }
                }
                arr[i] = keyNum;
                quick_sort(arr, l, i - 1);
                quick_sort(arr, i + 1, r);
            }
        }
    }
}
