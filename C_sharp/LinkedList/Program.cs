namespace Spojak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList spojak = new LinkedList();
            spojak.AddMultiple(3,4,5,6,4);

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
            
            Console.WriteLine();

            Console.WriteLine("Is there 5 ; 7?");
            Console.WriteLine(spojak.IsThere(5));
            Console.WriteLine(spojak.IsThere(7));

            Console.WriteLine();
           
            Console.Write("List 1: ");
            spojak.Print();
            Console.Write("List 2: ");
            LinkedList spojak2 = new LinkedList();
            spojak2.AddMultiple(4,7,1,5,5);
            spojak2.Print();

            // clone protoze prunik je destruktivni a nechce se mi vytvaret novy spojak
            LinkedList intersect = LinkedList.Intersection(spojak.Clone(), spojak2.Clone());
            Console.Write("Intersection: ");
            intersect.Print();
                       
            spojak2.AddMultiple(4,7,1,5,5);

            LinkedList union = LinkedList.Union(spojak, spojak2);
            Console.Write("Union: ");
            union.Print();

            Console.WriteLine();

            LinkedList a = new LinkedList();
            LinkedList b = new LinkedList();
            a.AddMultiple(4,1,0,2,3,2);
            b.AddMultiple(0,2,1,8);

            Console.Write("a: ");
            a.Print();
            Console.Write("b: ");
            b.Print();
            
            LinkedList sum = LinkedList.AddNumbers(a, b);
            Console.Write("Sum: ");
            sum.Print();
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
        
        // O(n)
        // lepsi by bylo ulozit koncovy node, coz by bylo O(1)
        public void AddToEnd(int value)
        {
            if(Head == null)
            {
                Head = new Node(value);
            }
            else
            {
                Node currentNode = Head;
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }
                currentNode.Next = new Node(value);
            }            
        }
        
        // O(n*m), m = pocet pridanych prvku
        // opet by slo zlepsit zlepsenim AddToEnd na O(1)
        public void AddMultiple(params int[] values)
        {
            foreach (int value in values)
            {
                AddToEnd(value);
            }
        }
         
        // O(n)
        public void Print()
        {
            Node? node = Head;
            while (node != null)
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

        // O(n)
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

        // O(n)
        // dalo by se zrychlit pokud bychom meli ulozeno i zpet
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

        // O(n^2) - kazde AddToEnd je O(n)
        // zrychlelo by se zlepsenim AddToEnd na O(1)
        // nastesti nam nezalezi na rychlosti
        public LinkedList Clone()
        {
            LinkedList copy = new LinkedList();
            Node? current = Head;
            while (current != null)
            {
                copy.AddToEnd(current.Value);
                current = current.Next;
            }
            return copy;
        }

        // O(n)
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

        // O(n*m)
        // pro kazdy node se pouziva IsThere O(m)
        // ukladani konce resultu at se nemusi prochazet cely
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

        // O(n*m)
        // stejny jak prunik
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

            list2.Head = null;
            return list1;
        }
        
        // O(n)
        public void Reverse()
        {
            Node? previous = null;
            Node? current = Head;

            while (current != null)
            {
                Node? next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            Head = previous;
        }

        // O(n + m)
        public static LinkedList AddNumbers(LinkedList a, LinkedList b)
        {
            a.Reverse();
            b.Reverse();

            Node? nodeA = a.Head;
            Node? nodeB = b.Head;
            int carry = 0;

            LinkedList result = new LinkedList();
            Node? last = null;

            while (nodeA != null || nodeB != null || carry > 0)
            {
                int sum = carry;
                if (nodeA != null)
                {
                    sum += nodeA.Value;
                    nodeA = nodeA.Next;
                }

                if (nodeB != null)
                {
                    sum += nodeB.Value;
                    nodeB = nodeB.Next;
                }

                Node newNode = new Node(sum % 10);
                carry = sum / 10;
                if (result.Head == null)
                {
                    result.Head = newNode;
                    last = newNode;
                }
                else
                {
                    last!.Next = newNode;
                    last = newNode;
                }
            }

            result.Reverse();
            return result;
        }
    }
}
