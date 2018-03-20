using System;

namespace DoublyLinkedListJZ

/*
 * I was getting so angry at pointers and heads and tails...
 * was a challenge. It was fun, but challenging.      
 * 
 * JZ
 */
{
    class DoublyLinkedList
    {
        //Basic build linked list with additional double link function.
        public class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }

            public Node()
            {
                Data = 0;
                Next = null;
                Prev = null;
            }

            public Node(int data)
            {
                Data = data;
                Next = null;
                Prev = null;
            }

            public Node(int data, Node next)
            {
                Data = data;
                Next = null;
                Prev = null;
            }
        }

        private Node head;

        private Node tail;
        protected Node Head
        {
            get
            {
                return head;
            }
        }

        protected Node Tail
        {
            get
            {
                return tail;
            }
        }

        public DoublyLinkedList()
        {
            head = null;
            tail = head;
        }

        //Overrided Insert Method to place insert nodes in ascending order
        public bool Insert(int Data)
        {
            try
            {
                Node prev = null;
                Node curr = Head;

                //if list is NOT empty
                if (curr != null)
                {
                    //traverse
                    while (curr.Next != null && Data > curr.Data)
                    {
                        prev = curr;
                        curr = curr.Next;
                    }
                    //calls insert after head 
                    if (Data > curr.Data)
                    {
                        InsertAfterHead(Data, curr);
                    }
                    else if (Data < curr.Data && prev != null)
                    {
                        InsertAfterHead(Data, prev);
                    }
                    else if (Data == curr.Data)
                    {
                        InsertAfterHead(Data, curr);
                    }
                    //unless the data inserting belongs numerically at the head of the list
                    else
                    {
                        InsertAtHead(Data);
                    }
                }
                else
                {
                    InsertAtHead(Data);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("We are taking on water in : Insert...");
                Console.WriteLine(e.Message);
                return false;
            }
        }
        //method for inserting at head and adjusting prev's and next's accordingly
        public bool InsertAtHead(int data)
        {
            try
            {
                Node insert = new Node(data);
                if (head == null && tail == null)
                {
                    tail = insert;
                }
                insert.Next = head;
                insert.Prev = null;
                if (head != null)
                {
                    head.Prev = insert;
                }
                head = insert;
                insert = null;

            }
            catch (Exception e)
            {
                Console.WriteLine("We are taking on water in : InsertAtHead");
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
        //Same as above but for anywhere else in the list, paying attention to the tail pointer if need be.
        private bool InsertAfterHead(int data, Node prev)
        {
            try
            {
                Node insert = new Node(data, prev.Next);

                if (prev.Next == null)
                {
                    tail = insert;
                }
                insert.Next = prev.Next;
                prev.Next = insert;
                insert.Prev = prev;
                if (insert.Next != null)
                {
                    insert.Next.Prev = insert;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("We are taking on water in : InsertAfterHead...");
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
        //same vanilla find as singly linked list
        public Node Find(int data)
        {
            Node curr = head;
            Node prev = null;

            try
            {
                if (head.Data == data)
                {
                    return head;
                }
                else
                {
                    while (curr.Data != data && curr.Next != null)
                    {
                        prev = curr;
                        curr = curr.Next;
                    }

                    if (curr.Data == data)
                    {
                        return prev;
                    }
                    else
                    {
                        return tail;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("We are taking on water in : Find()...");
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                prev = null;
                curr = null;
            }
        }
        //removes at head while managing prev and next pointers.
        private bool RemoveAtHead()
        {
            try
            {
                if (head == null)
                {
                    return true;
                }
                else
                {
                    Node deleteItem = head;
                    head = deleteItem.Next;
                    (deleteItem.Next).Prev = head;
                    //if list is empty
                    if (head == null && tail != null)
                    {
                        tail = head;
                    }
                    deleteItem = null;
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("We are taking on water in : RemoveAtHead()...");
                Console.WriteLine(e.Message);
                return false;
            }
        }
        //removes elsewhere in list while managing prev, next, head and tail.
        private bool RemoveAfterHead(Node prev)
        {
            try
            {
                //if list is empty, bail.
                if (prev == null || prev == tail)
                {
                    return true;
                }
                else
                {
                    Node deleteItem = prev.Next;
                    //if delete item is at the end of the list
                    if (deleteItem.Next == null)
                    {
                        prev.Next = null;
                        tail = prev;
                    }
                    else
                    {
                        //sets next and prev's
                        (deleteItem.Next).Prev = prev;
                        prev.Next = deleteItem.Next;
                    }
                    
                    deleteItem = null;
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("We are taking on water in : RemoveAfterHead...");
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //Determines which move function to call
        public virtual bool Remove(int item)
        {
            try
            {
                Node prev = Find(item);

                if (prev == head)
                {
                    if (head.Data == item)
                    {
                        return RemoveAtHead();
                    }
                    else
                    {
                        if (prev != tail)
                        {
                            return RemoveAfterHead(prev);
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                else if (prev != null)
                {
                    return RemoveAfterHead(prev);
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("We are taking on water in : Remove()...");
                Console.WriteLine(e.Message);
                return false;
            }
        }
        //override toString()
        public override string ToString()
        {
            Node curr = head;
            string list = "";

            try
            {
                if (head == null)
                {
                    return "";
                }
                else
                {
                    while (curr.Next != null)
                    {
                        list = list + curr.Data.ToString() + "->";
                        curr = curr.Next;
                    }

                    return list + curr.Data.ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("We are taking on water in : ToString...");
                Console.WriteLine(e.Message);
                return "";
            }
        }
        //Traverse backwards and prints ToString()
        public string ToStringReverse()
        {
            Node curr = tail;
            string list = "";

            try
            {
                if (tail == null)
                {
                    return "";
                }
                else
                {
                    while (curr.Prev != null)
                    {
                        list = list + curr.Data.ToString() + "->";
                        curr = curr.Prev;
                    }

                    return list + curr.Data.ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("We are taking on water in : ToStringReverse...");
                Console.WriteLine(e.Message);
                return "";
            }
        }
    }
}
