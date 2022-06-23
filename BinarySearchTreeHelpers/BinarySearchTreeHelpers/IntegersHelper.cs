namespace BinarySearchTreeHelpers
{
    public static class IntegersHelper
    {
        public static int[] GenerateArrayWithRandomIntegers(int lowerBound, int upperBound, int integersCount, 
                                                            bool mustBeDifferent = false)
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

                    if (mustBeDifferent)
                    {
                        while (array.Contains(possibleNextValue))
                        {
                            possibleNextValue = random.Next(lowerBound, upperBound);
                        }
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

        public static int CalculateSumOfIntegerDigits(int integer)
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
