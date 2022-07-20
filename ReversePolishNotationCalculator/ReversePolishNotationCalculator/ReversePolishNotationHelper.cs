namespace ReversePolishNotationCalculator
{
    internal class ReversePolishNotationHelper
    {
        private static readonly char[] TOKENS_SEPERATORS = " \t,".ToCharArray();

        public static void InterpreteReversePolishNotation()
        {
            while (true)
            {
                Console.Write("Enter an expression in RPN: ");
                string input = Console.ReadLine();

                if (input is null) break;

                Stack<string> tokens = new Stack<string>(input.Split(TOKENS_SEPERATORS, StringSplitOptions.RemoveEmptyEntries));

                if (tokens.Count == 0) continue;

                string output = null;
                double? result = null;

                try
                {
                    result = EvaluateReversePolishNotation(tokens);

                    if (tokens.Count != 0) throw new ArgumentException("Obsolete operands!");

                    output = $"Answer: {result.Value.ToString()}";
                }
                catch (ArgumentException ae) 
                { 
                    output = ae.Message;
                }

                Console.WriteLine(output + Environment.NewLine);
            }
        }

        private static double? EvaluateReversePolishNotation(Stack<string> tokensStack)
        {
            try
            {
                bool isEmpty = !tokensStack.TryPop(out string currentToken);
                if (isEmpty)
                {
                    throw new ArgumentException("Stack is empty!");
                }
                double secondOperand, firstOperand;
                if (!double.TryParse(currentToken, out secondOperand))
                {
                    firstOperand = EvaluateReversePolishNotation(tokensStack).Value;
                    secondOperand = EvaluateReversePolishNotation(tokensStack).Value;

                    switch (currentToken)
                    {
                        case "+":
                            secondOperand += firstOperand;
                            break;

                        case "-":
                            secondOperand += firstOperand;
                            break;

                        case "*":
                            secondOperand *= firstOperand;
                            break;

                        case "/":
                            secondOperand /= firstOperand;
                            break;

                        default:
                            throw new ArgumentException("Invalid operator!");
                    }
                }

                return secondOperand;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Environment.Exit(1);
                return null;
            }
        }
    }
}
