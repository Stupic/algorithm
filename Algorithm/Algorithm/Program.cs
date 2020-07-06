using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Net;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {

            /*           Sort sort = new Sort();

                       Console.WriteLine("");
                       sort.InsertSort();
                       Console.WriteLine("");
                       sort.BubbleSort();
                       Console.WriteLine("");
                       sort.SelectSort();
                       Console.WriteLine("");
                       sort.QuickSort();
                       Console.WriteLine("");
                       sort.MergeSort();
                       Console.WriteLine();
                       sort.HeepSort();

                       Stack stack = new Stack();

                   */

            //아아응



        }
    }


    class Sort
    {

        public void InsertSort()
        {
            int[] list = { 1, 10, 5, 8, 7, 6, 4, 3, 2, 9 };
            int i, j, temp;
            for (i = 0; i < 9; i++)
            {
                j = i;

                while (list[j] > list[j + 1])
                {
                    temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                    j--;
                }


            }

            Console.WriteLine("삽입 소트 :");
            for (i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }



        }

        public void BubbleSort()
        {
            int[] list = { 1, 10, 5, 8, 7, 6, 4, 3, 2, 9 };
            int i, j, temp;

            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 9 - i; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }

            }

            Console.WriteLine("버블 소트 :");
            for (i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
        }

        public void SelectSort()
        {
            int[] list = { 1, 10, 5, 8, 7, 6, 4, 3, 2, 9 };
            int i, j, min, temp, index = 0;


            for (i = 0; i < 10; i++)
            {

                min = 9999;

                for (j = i; j < 10; j++)
                {
                    if (min > list[j])
                    {
                        min = list[j];
                        index = j;
                    }
                }

                temp = list[i];
                list[i] = list[index];
                list[index] = temp;

            }

            Console.WriteLine("선택 소트 :");
            for (i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }
        }

        public void QuickSort()
        {
            int[] QuickMethod(int[] list, int start, int end)
            {
                //원소가 1개인 경우
                if (start >= end)
                {
                    return list;
                }
                int pivot = start;
                int i = start + 1;
                int j = end;
                int temp;


                while (i <= j)
                {


                    while (list[i] <= list[pivot] && i < end)
                    {
                        i++;

                    }
                    while (list[j] >= list[pivot] && j > start)
                    {
                        j--;

                    }



                    if (i >= j)
                    {
                        temp = list[pivot];
                        list[pivot] = list[j];
                        list[j] = temp;
                    }
                    else
                    {
                        temp = list[j];
                        list[j] = list[i];
                        list[i] = temp;
                    }


                }


                list = QuickMethod(list, start, j - 1);
                list = QuickMethod(list, j + 1, end);



                return list;
            }

            int i;
            int[] list = { 1, 10, 5, 8, 7, 6, 4, 3, 2, 9 };

            list = QuickMethod(list, 0, list.Length - 1);


            Console.WriteLine("퀵 소트 :");

            for (i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ");
            }



        }

        public void MergeSort()
        {
            int[] sort = new int[8];

            void Merge(int[] a, int m, int middle, int n)  //a 리스트 m 시작 n 끝 middle 중간
            {
                int i = m;
                int j = middle + 1;
                int k = m;  // 정렬해서 넣을 배열

                while (i <= middle && j <= n)
                {
                    if (a[i] < a[j])
                    {
                        sort[k] = a[i];
                        i++;
                    }
                    else
                    {
                        sort[k] = a[j];
                        j++;
                    }

                    k++;
                }

                if (i > middle)
                {
                    for (int t = j; t <= n; t++)
                    {
                        sort[k] = a[t];
                        k++;
                    }
                }
                else
                {
                    for (int t = i; t <= middle; t++)
                    {
                        sort[k] = a[t];
                        k++;
                    }

                }


                for (int t = m; t <= n; t++)
                {
                    a[t] = sort[t];
                }


            }

            void MergeSplit(int[] a, int m, int n)    //a= 리스트  m은 시작 n은 끝 
            {
                if (m < n) //갯수가 1개가 아님
                {
                    int middle = (m + n) / 2; //중간값
                    MergeSplit(a, m, middle);
                    MergeSplit(a, middle + 1, n);
                    Merge(a, m, middle, n);
                }

            }

            int[] list = { 7, 6, 5, 8, 3, 5, 9, 1 };
            MergeSplit(list, 0, list.Length - 1);

            Console.WriteLine("병합 정렬 : ");
            for (int t = 0; t < list.Length; t++)
            {
                Console.Write(sort[t] + " ");
            }


        }

        public void HeepSort()
        {
            int size = 9;
            int[] list = { 7, 6, 5, 8, 3, 5, 9, 1, 6 };
            int temp;

            for (int i = 1; i < size; i++)
            {
                int child = i;   //자식

                do
                {
                    int root = (child - 1) / 2;
                    if (list[child] > list[root])
                    {
                        temp = list[child];
                        list[child] = list[root];
                        list[root] = temp;
                    }
                    child = root;
                }
                while (child > 0);

            }

            for (int i = size - 1; i > 0; i--)
            {
                int root = 0;
                temp = list[i];
                list[i] = list[root];
                list[root] = temp;

                int child;

                do
                {
                    child = root * 2 + 1;

                    if (child < i - 1 && list[child] < list[child + 1])  // 자식 왼쪽, 오른쪽
                        child++;

                    if (child < i && list[root] < list[child])  // 부모  자식,작은 자식 교환
                    {
                        temp = list[child];
                        list[child] = list[root];
                        list[root] = temp;
                    }
                    root = child;
                }
                while (child < i);

            }

            Console.WriteLine("힙 정렬:");
            for (int i = 0; i < size; i++)
            {

                Console.Write(list[i] + " ");

            }

        }


    }




    class Stack
    {
        int[] stacklist = new int[100];
        int size = 100;
        int top = 0;  // 들어갈 위치 가리킴
        public void push(int data)
        {
            if (top < size)
            {
                stacklist[top++] = data;
                Console.WriteLine("추가된 데이터      :" + data);
                Console.WriteLine("-------현재 데이터 목록 --------");
                check();
            }
            else
            {
                Console.WriteLine("스택이 꽉 찼습니다.");
            }
        }

        public void pop()  //삭제
        {
            if (top == 0)
            {
                Console.WriteLine("스택이 비어있습니다");
            }
            else
            {
                Console.WriteLine("삭제된 데이터    :" + stacklist[top - 1]);
                top--;
                Console.WriteLine("-------현재 데이터 목록 --------");
                check();
            }
        }

        public void check()
        {
            if (top == 0)
            {
                Console.WriteLine("---비어 있음 -----");
                return;
            }

            for (int i = 0; i < top; i++)
            {
                Console.WriteLine(stacklist[i]);
            }

            Console.WriteLine("------출력 완료-------");

        }

    }
}





