using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Rövarspråket
//#212 [Easy] Rövarspråket
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Program.encode("This is a test! I'm speaking Robber's language!"));
            Console.ReadLine();
        }
        private static string encode(string input)
        {
            string current = input;
            char[] vowels = { 'A', 'E', 'I', 'O', 'U', 'Y', 'Å', 'Ä', 'Ö', 'a', 'e', 'i', 'o', 'u', 'y', 'å', 'ä', 'ö' };
            int i = 0;
            while (i < current.Length)
            {
                if (!vowels.Contains(current[i]) && Char.IsLetter(current[i]))
                {
                    current = current.Insert(i + 1, "o" + Char.ToLower(current[i]));
                    i += 2;
                }
                i += 1;
            }
            return current;
        }
        private static string decode(string input)
        {
            string current = input;
            char[] vowels = { 'A', 'E', 'I', 'O', 'U', 'Y', 'Å', 'Ä', 'Ö', 'a', 'e', 'i', 'o', 'u', 'y', 'å', 'ä', 'ö' };
            int i = 0;
            while (i < current.Length)
            {
                if (!vowels.Contains(current[i]) && Char.IsLetter(current[i]))
                {
                    current = current.Remove(i + 1, 2);
                }
                i += 1;
            }
            return current;
        }
    }
}