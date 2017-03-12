using System;
using static System.Console;
using System.Collections;
using System.Linq;

namespace Prog5
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Введите количество элементов первой очереди:");
            int n;
            while (!int.TryParse(ReadLine(), out n))
            {
                WriteLine("Некорректный ввод!");
            }
            WriteLine("Введите элементы первой очереди(в порядке возрастания):");
            int element;
            Queue firstQueue = new Queue();
            for (int i = 0; i < n; i++)
            {
                while (!int.TryParse(ReadLine(), out element))
                {
                    WriteLine("Некорректный ввод!");
                }
                firstQueue.Enqueue(element);
            }
            firstQueue.Enqueue(2000000000);
            WriteLine("Введите количество элементов второй очереди:");
            int m;
            while (!int.TryParse(ReadLine(), out m))
            {
                WriteLine("Некорректный ввод!");
            }
            WriteLine("Введите элементы второй очереди(в порядке возрастания):");
            Queue secondQueue = new Queue();
            for (int i = 0; i < m; i++)
            {
                while (!int.TryParse(ReadLine(), out element))
                {
                    WriteLine("Некорректный ввод!");
                }
                secondQueue.Enqueue(element);
            }
            secondQueue.Enqueue(2000000000);
            Doubly_Linked_List DoublyLinkedList = new Doubly_Linked_List();
            int firstQueueElement = (int) firstQueue.Dequeue();
            int secondQueueElement = (int) secondQueue.Dequeue();
            while (firstQueue.Count != 0 && secondQueue.Count !=0)
            {
                if (firstQueueElement < secondQueueElement)
                {
                    DoublyLinkedList.Push_Back(firstQueueElement);
                    firstQueueElement = (int) firstQueue.Dequeue();
                }
                else
                {
                    DoublyLinkedList.Push_Back(secondQueueElement);
                    secondQueueElement = (int)secondQueue.Dequeue();
                }
            }
            while (firstQueue.Count != 0)
            {
                DoublyLinkedList.Push_Back(firstQueueElement);
                firstQueueElement = (int)firstQueue.Dequeue();
            }
            while (secondQueue.Count != 0)
            {
                DoublyLinkedList.Push_Back(secondQueueElement);
                secondQueueElement = (int)secondQueue.Dequeue();
            }
            WriteLine("Двусвязный список:");
            DoublyLinkedList.Display();
            ReadKey();
        }
    }
}
