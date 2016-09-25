using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplurthianChemistry
//#275 [Easy + Intermediate] Splurthian Chemistry 101 + 102
{
    class SplurthianChemistry
    {
        List<string> symbols = new List<string>();
        List<string> elements = new List<string>();
        Dictionary<string, string> elementTable;

        static void Main(string[] args)
        {
            //bool test = SplurthianChemistry.isValid("Stantzon", "Zt");
            SplurthianChemistry test = new SplurthianChemistry("C:\\Temp\\Elements.txt");
            Console.ReadLine();
        }

        SplurthianChemistry(string filepath)
        {
            this.readElements(filepath);
            this.elementTable = this.assignSymbols();
        }

        static bool isValid(string name, string symbol)
        {
            string restName = name.ToLower();
            symbol = symbol.ToLower();
            int symbolLength = symbol.Length;
            if (symbolLength != 2)
            {
                return false;
            }
            
            for (int i = 0; i < symbolLength; i++)
            {
                if (restName.Contains(symbol[i]))
                {
                    restName = restName.Substring(restName.IndexOf(symbol[i]) + 1);
                }
                else return false;
            }
            return true;
        }

        string findBestSymbol(string name)
        {
            string newName = name.ToLower();
            int nameLength = newName.Length;
            for (int i = 0; i < nameLength; i++)
            {
                for (int j = i+1; j < nameLength; j++)
                {
                    string possibleSymbol = newName[i].ToString() + newName[j].ToString();
                    if (!this.symbols.Contains(possibleSymbol))
                    {
                        symbols.Add(possibleSymbol);
                        return possibleSymbol;
                    }
                }
            }
            return "no possible symbol";
        }

        Dictionary<string, string> assignSymbols()
        {
            this.elementTable = new Dictionary<string, string>();
            foreach (string element in this.elements)
            {
                string newSymbol = this.findBestSymbol(element);
                if (newSymbol != "no possible symbol")
                {
                    elementTable.Add(element, newSymbol);
                }
                else
                {
                    //elementTable.Add(element, "no possible symbol");
                }
                    
            }
            return elementTable;
        }

        void readElements(string filepath)
        {
            this.elements = File.ReadLines(filepath).ToList();
        }

    }
}
