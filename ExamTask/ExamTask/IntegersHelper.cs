namespace ExamTask
{
    namespace BinarySearchTreeHelpers
    {
        public static class IntegersHelper
        {
            public static int[] GenerateArrayWithRandomIntegersThatAreNotDivisibleBySumOfTheirDigits(int lowerBound, int upperBound, 
                                                                                        int integersCount)
            {
                try
                {
                    if (lowerBound >= upperBound)
                    {
                        throw new ArgumentException("Upper bound must be greater than lower bound!");
                    }

                    int[] array = new int[integersCount];

                    Random random = new Random();

                    for (int i = 0; i < array.Length; i++)
                    {
                        int possibleNextValue = random.Next(lowerBound, upperBound);

                        bool isDivisibleBySumOfDigits = true;
                        while (array.Contains(possibleNextValue) && isDivisibleBySumOfDigits)
                        {
                            possibleNextValue = random.Next(lowerBound, upperBound);
                            int digitsSum = CalculateSumOfIntegerDigits(possibleNextValue);
                            isDivisibleBySumOfDigits = possibleNextValue % digitsSum == 0;
                        }

                        array[i] = possibleNextValue;
                    }

                    return array;
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                return null;
            }

            private static int CalculateSumOfIntegerDigits(int integer)
            {
                int digitsSum = 0;

                while (integer != 0)
                {
                    digitsSum += (integer % 10);
                    integer /= 10;
                }

                return digitsSum;
            }
        }
    }

}
