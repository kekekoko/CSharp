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
            string possibleSymbol = "";
            for (int i = 0; i < nameLength; i++)
            {
                for (int j = i+1; j < nameLength; j++)
                {
                    possibleSymbol = newName[i].ToString() + newName[j].ToString();
                    if (!this.symbols.Contains(possibleSymbol))
                    {
                        symbols.Add(possibleSymbol);
                        return possibleSymbol;
                    }
                }
            }
            return "last possible symbol already taken: " + possibleSymbol;
        }

        Dictionary<string, string> assignSymbols()
        {
            this.elementTable = new Dictionary<string, string>();
            //foreach (string element in this.elements)

            for (int i = 0; i < this.elements.Count(); i++)
            {
                string element = this.elements[i];
                string newSymbol = this.findBestSymbol(element);
                if (!newSymbol.StartsWith("last possible symbol already taken: "))
                {
                    elementTable.Add(newSymbol, element);
                }
                else
                {
                    newSymbol = newSymbol.Substring(newSymbol.LastIndexOf(' ') + 1);
                    string removedElement;
                    elementTable.TryGetValue(newSymbol, out removedElement);
                    elementTable.Remove(newSymbol);
                    elementTable.Add(newSymbol, element);
                    this.elements.Remove(removedElement);
                    this.elements.Add(removedElement);
                    //elementTable.Add(element, "no possible symbol");
                    i--;
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
