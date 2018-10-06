using System;

namespace _356_Intermediate
{
    class Program
    {
        static void Main(string[] args)
        {
        //    if (!int.TryParse(Console.ReadLine(), out int input) || input < 5) {
        //        Console.WriteLine("Wrong!");
        //    }
           Find3PrimesSum(53);
            Console.WriteLine($"{pr1}, {pr2}, {pr3}");
        }

        private static int pr1;
        private static int pr2;
        private static int pr3;

        private static void Find3PrimesSum(int input)
        {
            for (int p1 = FindNextSmallestPrime(input); p1 > 1; p1 = FindNextSmallestPrime(p1)) {
                int missingSum = input - p1;

                for (int p2 = FindNextSmallestPrime(missingSum); p2 > 1; p2 = FindNextSmallestPrime(p2)) {
                    int p3 = missingSum - p2;
                    if (IsPrime(p3)) {
                        pr1 = p1;
                        pr2 = p2;
                        pr3 = p3;
                        return;
                    }
                }
            }
            throw new Exception("This is wrongggggg");
        }
        private static int FindNextSmallestPrime(int input)
        {
            for (int i = input - 1; i >= 1; i--) {
                if (IsPrime(i)) {
                    return i;
                }
            }
            return -1;
        }

        private static bool IsPrime(int numberToTest)
        {
            if (numberToTest == 1) {
                return false;
            }
            
            for (int i = 2; i <= Math.Sqrt(numberToTest); i++) {
                if (numberToTest % i == 0) {
                    return false;
                }
            }
            return true;
        }
    }
}
