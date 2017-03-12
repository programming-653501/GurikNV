using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog5
{
    class Doubly_Linked_List
    {
        private Node First;
        private Node Current;
        private Node Last;
        private uint size;

        public Doubly_Linked_List()
        {
            size = 0;
            First = Current = Last = null;
        }

        public bool isEmpty 
        {
            get
            {
                return size == 0;
            }
        }

        public void Insert_Index(object newElement, uint index) 
        {
            if (index < 1 || index > size) 
            {
                throw new InvalidOperationException();
            }
            else if (index == 1) 
            {
                Push_Front(newElement);
            }
            else if (index == size) 
            {
                Push_Back(newElement);
            }
            else 
            {
                uint count = 1;
                Current = First;
                while (Current != null && count != index)
                {
                    Current = Current.Next;
                    count++;
                }
                Node newNode = new Node(newElement); 
                Current.Prev.Next = newNode;
                newNode.Prev = Current.Prev;
                Current.Prev = newNode;
                newNode.Next = Current;
            }
        }

        public void Push_Front(object newElement)
        {
            Node newNode = new Node(newElement);

            if (First == null)
            {
                First = Last = newNode;
            }
            else
            {
                newNode.Next = First;
                First = newNode; 
                newNode.Next.Prev = First;
            }
            Count++;
        }

        public Node Pop_Front()
        {
            if (First == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                Node temp = First;
                if (First.Next != null)
                {
                    First.Next.Prev = null;
                }
                First = First.Next;
                Count--;
                return temp;
            }
        }

        public void Push_Back(object newElement)
        {
            Node newNode = new Node(newElement);

            if (First == null)
            {
                First = Last = newNode;
            }
            else
            {
                Last.Next = newNode;
                newNode.Prev = Last;
                Last = newNode;
            }
            Count++;
        }

        public Node Pop_Back()
        {
            if (Last == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                Node temp = Last;
                if (Last.Prev != null)
                {
                    Last.Prev.Next = null;
                }
                Last = Last.Prev;
                Count--;
                return temp;
            }
        }

        public void ClearList() 
        {
            while (!isEmpty)
            {
                Pop_Front();
            }
        }

        public uint Count 
        {
            get { return size; }
            set { size = value; }
        }

        public void Display() 
        {
            if (First == null)
            {
                Console.WriteLine("Двусвязный список пуст");
                return;
            }
            Current = First;
            uint count = 1;
            while (Current != null)
            {
                Console.WriteLine("Элемент " + count.ToString() + " : " + Current.Value.ToString());
                count++;
                Current = Current.Next;
            }
        }

        public void ReverseDisplay() 
        {
            if (Last == null)
            {
                Console.WriteLine("Двусвязный список пуст");
                return;
            }
            Current = Last;
            uint count = 1;
            while (Current != null)
            {
                Console.WriteLine("Элемент " + count.ToString() + " : " + Current.Value.ToString());
                count++;
                Current = Current.Prev;
            }
        }

        public void DeleteElement(uint index)
        { 
            if (index < 1 || index > size)
            {
                throw new InvalidOperationException();
            }
            else if (index == 1)
            {
                Pop_Front();
            }
            else if (index == size)
            {
                Pop_Back();
            }
            else
            {
                uint count = 1;
                Current = First;
                while (Current != null && count != index)
                {
                    Current = Current.Next;
                    count++;
                }
                Current.Prev.Next = Current.Next;
                Current.Next.Prev = Current.Prev;
            }
        }

        public Node FindNode(object Data) 
        {
            Current = First;
            while (Current != null)
            {
                Current = Current.Next;
            }
            return Current;
        }

        public uint GetIndex(object Data) 
        {
            Current = First;
            uint index = 1;
            while (Current != null)
            {
                Current = Current.Next;
                index++;
            }
            return index;

        }

    }
}
