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

                PreFix(expression);
            }
            else if (action == "o")
            {
                Console.Write("Výraz: ");
                string[] expression = Console.ReadLine()!.Split();

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
        Stack<string> infixStack = new Stack<string>();
        bool error = false;

        foreach (string cur in expression)
        {
            if (double.TryParse(cur, out double operand))
            {
                stack.Push(operand);
                infixStack.Push(cur);
            }
            else if (stack.Count > 1)
            {
                double right = stack.Pop();
                double left = stack.Pop();
                
                double ans = DoOperation(cur, left, right);
                if (double.IsPositiveInfinity(ans))
                {
                    error = true;
                    ans = 0;
                }
                else if (double.IsNaN(ans))
                {
                    return;
                }

                stack.Push(ans);

                string rightInfix = infixStack.Pop();
                string leftInfix = infixStack.Pop();
                infixStack.Push($"({leftInfix} {cur} {rightInfix})");
            }
            else
            {
                Console.WriteLine("Neplatný výraz: chybí operand/y");
                return;
            }

        }

        if (stack.Count == 1)
        {
            Console.WriteLine($"Infix: {infixStack.Pop()}");
            if (!error)
            {
                Console.WriteLine($"Výsledek: {stack.Pop()}");
            }
        }
        else
        {
            Console.WriteLine("Neplatný výraz: chybí operátor/y");
        }
    }

    static void PreFix(string[] expression)
    {
        Stack<string> stack = new Stack<string>();
        Stack<string> infixStack = new Stack<string>();
        bool error = false;
        int operandCount = 0;
        int operatorCount = 0;


        foreach (string cur in expression)
        {
            if (double.TryParse(cur, out double num))
            {
                operandCount++;
                double current = num;
                string currentInfix = cur;

                while (stack.Count() > 1 && double.TryParse(stack.Peek(), out double stackNum))
                {
                    stack.Pop();
                    string op = stack.Pop();
                    string stackInfix = infixStack.Pop();
    
                    double ans = DoOperation(op, stackNum, current);

                    if (double.IsPositiveInfinity(ans))
                    {
                        error = true;
                        ans = 0;
                    }
                    else if (double.IsNaN(ans))
                    {
                        return;
                    }
                   
                    current = ans;
                    currentInfix = $"({stackInfix} {op} {currentInfix})";
                }

                stack.Push(Convert.ToString(current));
                infixStack.Push(currentInfix);
            }
            else
            {
                operatorCount++;
                stack.Push(cur);
            }
        }

        if (stack.Count == 1)
        {
            Console.WriteLine($"Infix: {infixStack.Pop()}");
            if (!error)
            {
                Console.WriteLine($"Výsledek: {stack.Pop()}");
            }

        }
        else if (operandCount > operatorCount + 1)
        {
            Console.WriteLine("Neplatný výraz: chybí operátor/y");
        }
        else
        {
            Console.WriteLine("Neplatný výraz: chybí operand/y");
        }

    }

    static double DoOperation(string op, double left, double right)
    {
        // switch case by byl lepsi
        if (op == "+")
        {
            return (left + right);
        }
        else if (op == "-")
        {
            return (left - right);
        }
        else if (op == "*")
        {
            return (left * right);
        }
        else if (op == "/")
        {
            if (right == 0)
            {
                Console.WriteLine("Dělení nulou není definováno!");
                return double.PositiveInfinity;
            }
            return (left / right);
        }
        else
        {
            Console.WriteLine("Neznámý operátor");
            return double.NaN;
        }
    }
}
