using System;
using System.Collections.Generic;
using System.Linq;

namespace _355_Easy
{
    class Program
    {
        private static string keyWord;
        private static string sentence;
        private static IDictionary<char, IDictionary<char, char>> lookUpTable = new Dictionary<char, IDictionary<char, char>>();

    private static string resultMessage;

        static void Main(string[] args)
        {
           Console.WriteLine("Write e or d for encryption or decryption (default: e");
           string blaa = Console.ReadLine().ToLower();
           if (blaa != "e" && blaa != "d"){
               blaa = "e";
           }
           Console.WriteLine("Please enter your key word and your sentence!");
            string input = Console.ReadLine();
            ProcessInput(input);
            CreateLookupTable();
            if (blaa == "e"){
 CreateResultMessage();
 return;
            }
           CreateNormalMessage();
        }

        private static void CreateNormalMessage(){
            char[] sentenceArray = sentence.ToCharArray();
            char[] keyWordArray = keyWord.ToCharArray();
            resultMessage = "";
            for (int i = 0; i < sentenceArray.Length; i++){
                // Console.WriteLine("kw: " + keyWordArray[i]);
                // Console.WriteLine("s: " + sentenceArray[i]);
                resultMessage += lookUpTable[keyWordArray[i]].Single(kvp => kvp.Value.Equals(sentenceArray[i])).Key;

            }
            Console.WriteLine(resultMessage);
        }

        private static void CreateResultMessage()
        {
            char[] sentenceArray = sentence.ToCharArray();
            char[] keyWordArray = keyWord.ToCharArray();
            resultMessage = "";
            for (int i = 0; i < sentenceArray.Length; i++){
                // Console.WriteLine("kw: " + keyWordArray[i]);
                // Console.WriteLine("s: " + sentenceArray[i]);
                resultMessage += lookUpTable[keyWordArray[i]][sentenceArray[i]];
            }
            Console.WriteLine(resultMessage);
        }

        private static void CreateLookupTable(){
            for (char yletter = 'a'; yletter <= 'z'; yletter++){
                IDictionary<char, char> dict = new Dictionary<char, char>();
                char offsetLetter = yletter;
                 for (char xletter = 'a'; xletter <= 'z'; xletter++){
                     dict.Add(xletter, offsetLetter);
                     if (offsetLetter == 'z'){
                         offsetLetter = 'a';
                         continue;
                     }
                     offsetLetter++;
                 }
                lookUpTable.Add(yletter, dict);
            }
        }

        private static void ProcessInput(string input){
            string[] splitInput = input?.Split(" ");
            if (splitInput?.Length != 2){
                throw new ArgumentException("Your input was stupid and wrong");
            }
            keyWord = splitInput[0].Trim().ToLower();
            sentence = splitInput[1].Trim().ToLower();


            while (keyWord.Length < sentence.Length){
                keyWord += keyWord;
            }
            if (keyWord.Length > sentence.Length){
                keyWord.Substring(0, sentence.Length);
            }
        }
    }
}
