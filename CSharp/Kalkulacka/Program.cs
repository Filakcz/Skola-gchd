namespace Kalkulacka;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Prefix (r) nebo postfix (o): ");
            string? action = Console.ReadLine();

            if (action == "r")
            {
                Console.Write("Výraz: ");
                string[] expression = Console.ReadLine()!.Split();
                Console.Write("> ");

                PreFix(expression);
            }
            else if (action == "o")
            {
                Console.Write("Výraz: ");
                string[] expression = Console.ReadLine()!.Split();
                Console.Write("> ");

                PostFix(expression);
            }
            else
            {
                Console.WriteLine("Neplatná akce!");
            }
        }
    }

    static void PostFix(string[] expression)
    {
        Stack<double> stack = new Stack<double>();
        foreach (string cur in expression)
        {
            if (double.TryParse(cur, out double operand))
            {
                stack.Push(operand);
            }
            else if (stack.Count > 1)
            {
                double right = stack.Pop();
                double left = stack.Pop();

                if (cur == "+")
                {
                    stack.Push(left + right);
                }
                else if (cur == "-")
                {
                    stack.Push(left - right);
                }
                else if (cur == "*")
                {
                    stack.Push(left * right);
                }
                else if (cur == "/")
                {
                    if (right == 0)
                    {
                        Console.WriteLine("Dělení nulou není definováno!");
                        return;
                    }
                    stack.Push(left / right);
                }
                else
                {
                    Console.WriteLine("Neplatný výraz: neplatný operátor/y");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Neplatný výraz: chybí operand/y");
                return;
            }

        }

        if (stack.Count == 1)
        {
            Console.WriteLine(stack.Pop());
        }
        else
        {
            Console.WriteLine("Neplatný výraz: chybí operátor/y");
        }
    }

    static void PreFix(string[] expression)
    {
        Stack<string> stack = new Stack<string>();

    }
}
