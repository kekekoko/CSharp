using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DankUserNames
{
    class DankUserNames
    {
        static void Main(string[] args)
        {
            List<String> words = DankUserNames.readFile("C://temp//EnglishWordList.txt");
            //bool test = isSparseSubstr("donaldknuth", "onut");
            findLongestUserName("Kerstin Kohout", words).ForEach(word => Console.WriteLine(word));
            Console.WriteLine("=============");
            Console.ReadLine();
        }

        static List<String> readFile(String path)
        {
            
            List<String> words = new List<String>(File.ReadLines(path));
            return words;
        }

        static List<String> findLongestUserName(String name, List<String> words)
        {
            List<String> lowerWords = new List<String>();
            words.ForEach(word => lowerWords.Add(word.ToLower()));
            List<String> userNames = new List<String>();
            String trimmedName = name.Replace(" ", "").ToLower();
            int longest = 0;
            foreach ( String word in lowerWords)
            {
                if (word.Length >= longest)
                {
                    bool isUserName = isSparseSubstr(trimmedName, word);
                    if (isSparseSubstr(trimmedName, word))
                    {
                        userNames.Add(word);
                        longest = word.Length;
                    }
                }
            }
            return (from userName in userNames where userName.Length == longest select userName).ToList();
        }

        static bool isSparseSubstr(String name, String word)
        {
            int nameLength = name.Length;
            int wordLength = word.Length;
            if (wordLength > nameLength)
            {
                return false;
            }
            if (name.Contains(word))
            {
                return true;
            } else
            {
                int currentIndex = wordLength-1;
                while (currentIndex > 0)
                {
                    String currentSubStr = word.Substring(0, currentIndex);
                    if (name.Contains(currentSubStr))
                    {
                        int removeIndex = name.IndexOf(currentSubStr) + currentSubStr.Length;
                        if (removeIndex < nameLength)
                        {
                            return DankUserNames.isSparseSubstr(name.Remove(removeIndex, 1), word);
                        }
                        else return false;
                    }
                    else currentIndex--;
                }
            }
            return false;
        }
    }
}
