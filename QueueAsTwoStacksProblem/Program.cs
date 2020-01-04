using System;
using System.Collections.Generic;

namespace QueueAsTwoStacksProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            TestQueue1();
            TestQueue2();
            ReadData();
        }

        private static void ReadData()
        {
            //CustomQueue<int> queue = new CustomQueue<int>();

            //string line = Console.ReadLine();
            //int n = Convert.ToInt32(line);

            //for (int i = 0; i < n; i++)
            //{
            //    int operation = scan.nextInt();
            //    int value;

            //    switch (operation)
            //    {
            //        case 1:
            //            value = scan.nextInt();
            //            queue.Enqueue(value);
            //            break;

            //        case 2:
            //            queue.Dequeue();
            //            break;

            //        case 3:
            //            value = queue.Peek();
            //            Console.WriteLine(value);
            //            break;
            //    }
            //}
        }

        private static void TestQueue1()
        {
            CustomQueue<int> customQueue = new CustomQueue<int>();
            const int limit = 100;

            for (int n = 1; n <= limit; n++)
            {
                customQueue.Enqueue(n);
            }

            for (int n = 1; n <= limit; n++)
            {
                Console.WriteLine(customQueue.Dequeue());
            }

        }

        private static void TestQueue2()
        {
            CustomQueue<int> customQueue = new CustomQueue<int>();

            for (int n = 0; n < 5; n++)
            {
                customQueue.Enqueue(n + 1);
                customQueue.Enqueue(n + 2);
                customQueue.Enqueue(n + 3);
                customQueue.Enqueue(n + 4);

                Console.WriteLine(customQueue.Peek());
                Console.WriteLine(customQueue.Dequeue());

                Console.WriteLine(customQueue.Peek());
                Console.WriteLine(customQueue.Dequeue());

                Console.WriteLine(customQueue.Peek());
                Console.WriteLine(customQueue.Dequeue());

                Console.WriteLine(customQueue.Peek());
                Console.WriteLine(customQueue.Dequeue());

                Console.WriteLine();
            }
        }
    }

    internal class CustomQueue<T>
    {
        private readonly Stack<T> _stack1 = new Stack<T>();
        private readonly Stack<T> _stack2 = new Stack<T>();

        public void Enqueue(T item)
        {
            _stack1.Push(item);
        }

        public T Dequeue()
        {
            bool stack1IsEmpty = _stack1.Count == 0;
            bool stack2IsEmpty = _stack2.Count == 0;
            T value;

            if (!stack2IsEmpty)
            {
                value = _stack2.Pop();
            }
            else if (!stack1IsEmpty)
            {
                MoveStack1ToStack2();
                value = _stack2.Pop();
            }
            else
            {
                throw new Exception("Cannot dequeue empty queue");
            }

            return value;
        }

        public T Peek()
        {
            bool stack1IsEmpty = _stack1.Count == 0;
            bool stack2IsEmpty = _stack2.Count == 0;
            T value;

            if (!stack2IsEmpty)
            {
                value = _stack2.Peek();
            }
            else if (!stack1IsEmpty)
            {
                MoveStack1ToStack2();
                value = _stack2.Peek();
            }
            else
            {
                throw new Exception("Cannot dequeue empty queue");
            }

            return value;
        }

        private void MoveStack1ToStack2()
        {
            while (_stack1.Count > 0)
            {
                T value = _stack1.Pop();
                _stack2.Push(value);
            }
        }
    }
}
