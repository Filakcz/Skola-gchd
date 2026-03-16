namespace BinarniVyhledavaciStrom;

class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree<Student> tree = new BinarySearchTree<Student>();
        using (StreamReader streamReader = new StreamReader("studenti_shuffled.csv"))
        {
            string? line = streamReader.ReadLine();
            while (line != null)
            {
                string[] studentData = line.Split(',');
                Student student = new Student(
                        Convert.ToInt32(studentData[0]),    // Id
                        studentData[1],                     // Jméno
                        studentData[2],                     // Příjmení
                        Convert.ToInt16(studentData[3]),    // Věk
                        studentData[4]);                    // Třída

                tree.Insert(student.Id, student);
                line = streamReader.ReadLine();
            }
        }


        Node<Student>? node20 = tree.Find(20);
        if (node20 == null)
        {
            Console.WriteLine("Nenalezen.");
        }
        else
        {
            Console.WriteLine(node20.Value);
        }

        Node<Student>? minNode = tree.FindMin();
        if (minNode == null)
        {
            Console.WriteLine("Strom je prazdny.");
        }
        else
        {
            Console.WriteLine(minNode.Value);
        }

        Student newStudent = new Student(101, "Filip", "Bláha",18, "7.M");
        tree.Insert(newStudent.Id, newStudent);
        Node<Student>? studentBlaha = tree.Find(101);
        if (studentBlaha == null)
        {
            Console.WriteLine("Blaha neni.");
        }
        else
        {
            Console.WriteLine(studentBlaha.Value);
        }

        List<int> allIds = tree.GetIds();
        foreach (int id in allIds)
        {
            if (id % 2 == 0)
            {
                tree.Delete(id);
            }
        }

        tree.ShowTree();

        //tree.PrintNiceTree();

    }

    class BinarySearchTree<T>
    {
        public Node<T>? Root;

        public void Insert(int newKey, T newValue)
        {

            void _insert(Node<T> node, int newKey, T newValue)
            {                
                if (newKey < node.Key) // jdeme doleva
                {
                    if (node.LeftSon == null)
                    {
                        node.LeftSon = new Node<T>(newKey, newValue);
                    }
                    else
                    {
                        _insert(node.LeftSon, newKey, newValue);
                    }
                }
                else if (newKey > node.Key) // jdeme doprava
                {
                    if (node.RightSon == null)
                    {
                        node.RightSon = new Node<T>(newKey, newValue);
                    }
                    else
                    {
                        _insert(node.RightSon, newKey, newValue);
                    }
                }
                else // našli jsme náš klíč, což bychom neměli, mají být unikátní.... :/
                {
                    Console.WriteLine("Nebyl unikatni klic!");
                    throw new Exception(); // vyhodíme chybu
                }
            }

            if (Root == null) // pokud ještě není definován kořen
            {
                Root = new Node<T>(newKey, newValue);
            }
            else
            {
                _insert(Root, newKey, newValue);
            }
        }

        public void ShowTree()
        {
            void _print(Node<T> node) {
                if (node.LeftSon != null)
                {
                    _print(node.LeftSon);

                }

                Console.WriteLine($"{node.Key}: {node.Value}");

                if (node.RightSon != null)
                {
                    _print(node.RightSon);
                }

            }

            if (Root == null)
            {
                Console.WriteLine("Prazdny strom");
            }
            else
            {
                _print(Root);
            }
        }

        public Node<T>? FindMin(Node<T>? node = null)
        {
            if (node == null)
            {
                if (Root == null)
                {
                    return null;
                }
                else
                {
                    node = Root;
                }
            }

            while (node.LeftSon != null)
            {
                node = node.LeftSon;
            }

            return node;
        }

        public Node<T>? Find(int wantedKey)
        {
            Node<T>? _find(Node<T>? node, int wantedKey)
            {
                if (node == null)
                {
                    return null;
                }

                else if (wantedKey == node.Key)
                {
                    return node;
                }
                else if (wantedKey < node.Key)
                {
                    return _find(node.LeftSon, wantedKey);
                }
                else
                {
                    return _find(node.RightSon, wantedKey);
                }
            }

            return _find(Root, wantedKey);
        }

        public void Delete(int deleteKey)
        {
            Node<T>? _delete(Node<T>? node, int deleteKey)
            {
                if (node == null)
                {
                    return null;
                }

                else if (deleteKey < node.Key)
                {
                    node.LeftSon = _delete(node.LeftSon, deleteKey);
                }
                else if (deleteKey > node.Key)
                {
                    node.RightSon = _delete(node.RightSon, deleteKey);
                }
                else
                {
                    if (node.LeftSon == null && node.RightSon == null)
                    {
                        return null;
                    }
                    else if (node.LeftSon == null)
                    {
                        return node.RightSon;
                    }
                    else if (node.RightSon == null)
                    {
                        return node.LeftSon;
                    }

                    Node<T>? minRight = FindMin(node.RightSon);
                    if (minRight == null)
                    {
                        throw new Exception();
                    }
                    node.Key = minRight.Key;
                    node.Value = minRight.Value;

                    node.RightSon = _delete(node.RightSon, minRight.Key);

                }

                return node;
            }

            Root = _delete(Root, deleteKey);
        }

        public List<int> GetIds()
        {
            List<int> ids = new List<int>();
            void _getIds(Node<T>? node)
            {
                if (node == null)
                {
                    return;
                }
                _getIds(node.LeftSon);

                ids.Add(node.Key);

                _getIds(node.RightSon);

            }

            if (Root != null)
            {
                _getIds(Root);
            }
            return ids;
        }

    }

    class Node<T> // T může být libovolný typ
    {
        public Node(int key, T value)
        {
            Key = key;
            Value = value;
        }

        public int Key;
        public T Value;

        public Node<T>? LeftSon;
        public Node<T>? RightSon;
    }


    class Student
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }

        public string ClassName { get; }

        public Student(int id, string firstName, string lastName, int age, string className)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            ClassName = className;
        }
        
        public override string ToString()
        {
            return string.Format("{0} {1} (ID: {2}) ze třídy {3}",FirstName,LastName,Id,ClassName);
        }
    }
}
