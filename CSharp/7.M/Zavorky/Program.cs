namespace Zavorky;

class Program
{
    static void Main(string[] args)
    {
        char[] openingBrackets = {'{', '[', '('};
        char[] closingBrackets = {'}', ']', ')'};

        while (true)
        {
            Console.Write("Input: ");
            string? userInput = Console.ReadLine();
            
            Stack<char> stack = new Stack<char>();
            bool correct = true;
            
            if (userInput != null)
            {
                foreach (char i in userInput)
                {
                    if (openingBrackets.Contains(i))
                    {
                        stack.Push(i);
                    }
                    else if (closingBrackets.Contains(i))
                    {
                        if (stack.Count() == 0)
                        {
                            correct = false;
                            break;
                        }
                        if (Array.IndexOf(closingBrackets, i) == Array.IndexOf(openingBrackets, stack.Peek()))
                        {
                            stack.Pop();
                        }
                        else
                        {
                            correct = false;
                            break;
                        }
                    }
                }
            }

            if (stack.Count() == 0 && correct)
            {
                Console.WriteLine("Spravne");
            }
            if (correct == false || stack.Count() > 0)
            {
                Console.WriteLine("Spatne");
            }
        }
        
    }
}
