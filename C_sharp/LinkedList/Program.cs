namespace Spojak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList spojak = new LinkedList();
            spojak.AddToEnd(3);
            spojak.AddToEnd(4);
            spojak.AddToEnd(5);
            spojak.AddToEnd(6);
            spojak.AddToEnd(4);

            Console.Write("Linked list: ");
            spojak.Print();

            Console.Write("Max: ");
            int? max = spojak.Max();
            if (max == null)
            {
                Console.WriteLine("Linked list is empty");
            }
            else
            {
                Console.WriteLine(max);
            }

            Console.Write("Removing last, new linked list: ");
            spojak.RemoveLast();
            spojak.Print();


            Console.WriteLine("Is there 5 ; 7?");
            Console.WriteLine(spojak.IsThere(5));
            Console.WriteLine(spojak.IsThere(7));

            Console.Write("List 2: ");
            LinkedList spojak2 = new LinkedList();
            spojak2.AddToEnd(4);
            spojak2.AddToEnd(7);
            spojak2.AddToEnd(1);
            spojak2.AddToEnd(5);
            spojak2.AddToEnd(5);
            spojak2.Print();

            LinkedList intersect = LinkedList.Intersection(spojak, spojak2);
            Console.Write("Intersection: ");
            intersect.Print();
            
            LinkedList union = LinkedList.Union(spojak, spojak2);
            Console.Write("Union: ");
            union.Print();
        }
    }

    class Node
    {
        // konstruktor
        public Node(int value) 
        { 
            Value = value;
            Next = null; 
        }
        public int Value { get; set; }
        public Node? Next { get; set; }
    }

    class LinkedList
    {
        public Node? Head { get; set; }
        public void AddToEnd(int value)
        {
            if(Head == null)
            {
                Head = new Node(value);
            }
            else
            {
                Node currentNode = Head;
                while(currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = new Node(value);
            }
        }

        public void Print()
        {
            Node? node = Head;
            while ( node!=null)
            {
                Console.Write(node.Value);
                if (node.Next != null)
                {
                    Console.Write(" ");
                }
                node = node.Next;
            }
            Console.WriteLine();

        }

        public int? Max()
        {
            if (Head == null)
            {
                return null;                
            }
            Node? node = Head;
            int max = node.Value;
            while (node != null)
            {
                if (node.Value > max)
                {
                    max = node.Value;
                }
                node = node.Next;
            }

            return max;
        }

        public void RemoveLast()
        {
            if (Head == null)
            {
                return;
            }
            
            if (Head.Next == null)
            {
                Head = null;
                return;
            }
            Node node = Head;
            while (node.Next!.Next != null)
            {
                node = node.Next;
            }
            node.Next = null;
        }

        public bool IsThere(int value)
        {
            Node? node = Head;
            while (node != null)
            {
                if (node.Value == value)
                {
                    return true;
                }
                node = node.Next;
            }

            return false;
        } 

        public static LinkedList Intersection(LinkedList list1, LinkedList list2)
        {
            if (list1.Head == null || list2.Head == null)
            {
                return new LinkedList();
            }

            LinkedList result = new LinkedList();
            Node? resultEnd = null;

            Node? node1 = list1.Head;
            while (node1 != null)
            {
                if (list2.IsThere(node1.Value))
                {
                    if (!result.IsThere(node1.Value))
                    {
                        Node? next = node1.Next;
                        node1.Next = null;

                        if (result.Head == null)
                        {
                            result.Head = node1;
                            resultEnd = node1;
                        }
                        else
                        {
                            resultEnd!.Next = node1;
                            resultEnd = node1;
                        }

                        node1 = next;
                        continue;
                    }
                }

                node1 = node1.Next;
            }

            return result;
        }

        public static LinkedList Union(LinkedList list1, LinkedList list2)
        {
            if (list1.Head == null)
            {
                return list2;
            }
            if (list2.Head == null)
            {
                return list1;
            }

            Node? end = list1.Head;
            while (end.Next != null)
            {
                end = end.Next;
            }

            Node? node2 = list2.Head;
            while (node2 != null)
            {
                Node? next = node2.Next;
                node2.Next = null;

                if (!list1.IsThere(node2.Value))
                {
                    end.Next = node2;
                    end = node2;
                }

                node2 = next;
            }

            return list1;
        }
 
    }
}
