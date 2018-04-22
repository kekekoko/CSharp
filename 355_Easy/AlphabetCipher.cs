using System;
using System.Collections.Generic;
using System.Linq;

namespace _355_Easy {
    class AlphabetCipher {
        private static string keyWord;
        private static string sentence;
        private static ILookupTable lookupTable = new LookupTable();
        private static IIOTool ioTool = new ConsoleIOTool();
        private static Option option;

        enum Option {
            Decrypt,
            Encrypt
        }

        static void Main(string[] args) {
            Execute();
        }

        public static void Execute(){
            string input;
            do {
                SetOption();
                input = GetInput();
                ProcessInput(input);
                string result = GetModifiedString();
                WriteOutput(result);
            } while (!string.IsNullOrEmpty(input));
        }

        private static void WriteOutput(string output) {
            ioTool.Write(output);
        }

        private static string GetModifiedString(){
            EnDeCrypter crypter = new EnDeCrypter(lookupTable);
            string r = option == Option.Encrypt ? crypter.Encrypt(keyWord, sentence) : crypter.Decrypt(keyWord, sentence);
            return r;
        }

        private static string GetInput() {
            ioTool.Write("Please enter your key word and your sentence!");
            string input = ioTool.Read();
            return input;
        }

        private static void SetOption() {
            Console.WriteLine("Write e or d for encryption or decryption (default: e");
            string blaa = Console.ReadLine().ToLower();
            switch (blaa) {
                case "d":
                    option = Option.Decrypt;
                    break;
                case "e":
                default:
                    option = Option.Encrypt;
                    break;
            }
        }

        private static void ProcessInput(string input) {
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
