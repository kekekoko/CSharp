using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SadCycles
//#215 [Easy] Sad Cycles
{
    class Program
    {
        static void Main(string[] args)
        {
            int b;
            int n;
            Int32.TryParse(Console.ReadLine(), out b);
            Int32.TryParse(Console.ReadLine(), out n);

            List<BigInteger> bla = Program.calculateCycle(b, new BigInteger(n), new List<BigInteger>());

            bla.ForEach(x => Console.WriteLine(x));

            Console.ReadLine();
        }

        public static List<BigInteger> calculateCycle(int b, BigInteger n, List<BigInteger> lastNumbers)
        {
            String nString = n.ToString();
            int length = nString.Length;
            BigInteger sum = new BigInteger(0);
            int toAdd = 0;
            for (int i = 0; i < length; i++)
            {
                toAdd = 0;
                Int32.TryParse(nString.Substring(i, 1), out toAdd);
                sum += (BigInteger)Math.Pow(toAdd, b);
            }

            if (lastNumbers.Contains(sum)){
                lastNumbers.RemoveRange(0, lastNumbers.IndexOf(sum));
                return lastNumbers;
            } else
            {
                lastNumbers.Add(sum);
                lastNumbers = Program.calculateCycle(b, sum, lastNumbers);
            }
            return lastNumbers;
        }

    }
}
