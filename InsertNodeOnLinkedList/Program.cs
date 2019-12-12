using System;

namespace InsertNodeOnLinkedList
{
    internal static class Program
    {
        internal class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;

            public SinglyLinkedListNode(int nodeData)
            {
                data = nodeData;
                next = null;
            }
        }

        private class SinglyLinkedList
        {
            public SinglyLinkedListNode head;
            public SinglyLinkedListNode tail;

            public SinglyLinkedList()
            {
                head = null;
                tail = null;
            }
        }

        internal static void Main()
        {
            SinglyLinkedList singlyLinkedList = new SinglyLinkedList();
            SinglyLinkedListNode head = singlyLinkedList.head;
            SinglyLinkedListNode tail;

            //head = InsertNodeAtHead(head, 383);
            //SinglyLinkedListNode tail = head;
            //head = InsertNodeAtHead(head, 484);
            //head = InsertNodeAtHead(head, 392);
            //head = InsertNodeAtHead(head, 975);
            //head = InsertNodeAtHead(head, 321);

            head = InsertNodeAtTailStartingFromHead(head, 141);
            tail = InsertNodeAtTailStartingFromHead(head, 302);
            tail = InsertNodeAtTailStartingFromHead(head, 164);
            tail = InsertNodeAtTailStartingFromHead(head, 530);
            tail = InsertNodeAtTailStartingFromHead(head, 474);

            //tail = InsertNodeAtTail(tail, 141);
            //tail = InsertNodeAtTail(tail, 302);
            //tail = InsertNodeAtTail(tail, 164);
            //tail = InsertNodeAtTail(tail, 530);
            //tail = InsertNodeAtTail(tail, 474);

            PrintSinglyLinkedList(head);
        }

        private static SinglyLinkedListNode InsertNodeAtHead(SinglyLinkedListNode headNode, int data)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);

            if (headNode != null)
            {
                newNode.next = headNode;
            }

            return newNode;
        }

        private static SinglyLinkedListNode InsertNodeAtTail(SinglyLinkedListNode tailNode, int data)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);

            if (tailNode != null)
            {
                tailNode.next = newNode;
            }

            return newNode;
        }

        private static SinglyLinkedListNode InsertNodeAtTailStartingFromHead(SinglyLinkedListNode headNode, int data)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(data);

            if (headNode != null)
            {
                SinglyLinkedListNode currentNode = headNode;

                while (currentNode.next != null)
                {
                    currentNode = currentNode.next;
                }

                currentNode.next = newNode;
            }

            return newNode;
        }

        private static void PrintSinglyLinkedList(SinglyLinkedListNode node)
        {
            while (node != null)
            {
                Console.Write(node.data);

                node = node.next;

                if (node != null)
                {
                    Console.Write(", ");
                }
            }
        }
    }
}