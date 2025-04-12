namespace Evaluator.Logic;

public class FunctionEvaluator
{
    public static double Evalute(string infix)
    {
        var postfixStr = ToPostfix(infix);
        var tokens = postfixStr.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        return Calculate(tokens);
    }

    private static double Calculate(List<string> postfix)
    {
        var stack = new Stack<double>();
        foreach (var item in postfix)
        {
            if (IsSingleOperator(item))
            {
                var operator2 = stack.Pop();
                var operator1 = stack.Pop();
                stack.Push(Result(operator1, item[0], operator2));
            }
            else
            {
                stack.Push(double.Parse(item));
            }
        }
        return stack.Pop();
    }

    private static double Result(double operator1, char item, double operator2)
    {
        return item switch
        {
            '+' => operator1 + operator2,
            '-' => operator1 - operator2,
            '*' => operator1 * operator2,
            '/' => operator1 / operator2,
            '^' => Math.Pow(operator1, operator2),
            _ => throw new Exception("Invalid expresion"),
        };
    }

    private static string ToPostfix(string infix)
    {
        var stack = new Stack<char>();
        var postfix = string.Empty;
        var number = string.Empty;

        foreach (var item in infix)
        {
            if (char.IsDigit(item) || item == '.')
            {
                number += item;
            }
            else if (IsOperator(item))
            {

                if (!string.IsNullOrEmpty(number))
                {
                    postfix += number + " ";
                    number = String.Empty;
                }

                if (stack.Count == 0)
                {
                    stack.Push(item);
                }
                else if (item == ')')
                {
                    do
                    {
                        postfix += stack.Pop() + " ";
                    } while (stack.Peek() != '(');
                    stack.Pop();
                }
                else
                {

                    if (PriorityExpression(item) > PriorityStack(stack.Peek()))
                    {
                        stack.Push(item);
                    }
                    else
                    {
                        postfix += stack.Pop() + " ";
                        stack.Push(item);
                    }
                }
            }
            else if (item == ' ')
            {

                continue;
            }
        }


        if (!string.IsNullOrEmpty(number))
        {
            postfix += number + " ";
        }


        while (stack.Count > 0)
        {
            postfix += stack.Pop() + " ";
        }

        return postfix.Trim();
    }

    private static int PriorityStack(char item)
    {
        return item switch
        {
            '^' => 3,
            '*' => 2,
            '/' => 2,
            '+' => 1,
            '-' => 1,
            '(' => 0,
            _ => throw new Exception("Invalid expression."),
        };
    }

    private static int PriorityExpression(char item)
    {
        return item switch
        {
            '^' => 4,
            '*' => 2,
            '/' => 2,
            '+' => 1,
            '-' => 1,
            '(' => 5,
            _ => throw new Exception("Invalid expression."),
        };
    }

    private static bool IsOperator(char item) => "()^*/+-".IndexOf(item) >= 0;
    private static bool IsSingleOperator(string s)
    {
        return s.Length == 1 && IsOperator(s[0]);
    }
}