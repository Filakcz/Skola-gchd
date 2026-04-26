namespace VyrazovyStrom;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string expression = "65 3 5 * - 2 3 + /";
        string[] exp = expression.Split();
        Stack<Node> nodes = new Stack<Node>();
        for (int i = 0; i < exp.Length; i++)
        {
            if (double.TryParse(exp[i], out double value))
            {
                Node node = new Node(value);
                nodes.Push(node);
            }
            else
            {
                if (nodes.Count < 2)
                {
                    Console.WriteLine("Neplatný postfix (málo operandů)!");
                    return;
                }
                Node rightSon = nodes.Pop();
                Node leftSon = nodes.Pop();
                Node node = new Node(exp[i], leftSon, rightSon);
                nodes.Push(node);
            }
        }

        if (nodes.Count != 1)
        {
            Console.WriteLine("Neplatný postfix (až moc operandů)");
            return;
        }

        Node root = nodes.Pop();
        StringBuilder sb = new StringBuilder();

        PrintPrefix(root, sb);
        Console.WriteLine($"Prefix {sb.ToString().Trim()}");
        sb.Clear();

        PrintPostfix(root, sb);
        Console.WriteLine($"Postfix {sb.ToString().Trim()}");
        sb.Clear();

        PrintInfix(root, sb);
        Console.WriteLine($"Infix {sb.ToString().Trim()}");
        sb.Clear();


        Console.WriteLine($"Výsledek: {Eval(root)}");
    }


    static void PrintPrefix(Node node, StringBuilder sb)
    {
        sb.Append(node);
        sb.Append(" ");
        if (node.LeftSon != null)
        {
            PrintPrefix(node.LeftSon, sb);
            PrintPrefix(node.RightSon!, sb);
        }
    }

    static void PrintPostfix(Node node, StringBuilder sb)
    {
        if (node.LeftSon != null)
        {
            PrintPostfix(node.LeftSon, sb);
            PrintPostfix(node.RightSon!, sb);
        }
        sb.Append(node);
        sb.Append(" ");
    }

    static void PrintInfix(Node node, StringBuilder sb)
    {
        if (node.LeftSon == null)
        {
            sb.Append(node);
        }
        else
        {
            sb.Append("(");
            PrintInfix(node.LeftSon, sb);
            sb.Append(" ");
            sb.Append(node);
            sb.Append(" ");
            PrintInfix(node.RightSon!, sb);
            sb.Append(")");
        }
    }

    static double Eval(Node node)
    {
        if (node.LeftSon == null)
        {
            return node.Operand!.Value;
        }

        double left = Eval(node.LeftSon);
        double right = Eval(node.RightSon!);

        
        if (node.Operator == "+")
        {
            return (left + right);
        }
        else if (node.Operator == "-")
        {
            return (left - right);
        }
        else if (node.Operator == "*")
        {
            return (left * right);
        }
        else if (node.Operator == "/")
        {
            if (right == 0)
            {
                Console.WriteLine("Dělení nulou není definováno!");
            }
            return (left / right);
        }
        else
        {
            Console.WriteLine($"Neznámý operátor ({node.Operator})");
            return double.NaN;
        }
    }

    class Node
    {
        public Node? LeftSon { get; set; }
        public Node? RightSon { get; set; }
        public double? Operand { get; set; }
        public string? Operator { get; set; }

        public Node(double operand)
        {
            Operand = operand;
            LeftSon = null;
            RightSon = null;
        }

        public Node(string op, Node left, Node right)
        {
            Operator = op;
            LeftSon = left;
            RightSon = right;
        }

        public override string ToString()
        {
            if (LeftSon == null)
            {
                return Operand.ToString()!;
            }
            else
            {
                return Operator!;
            }
        }
    }

}
