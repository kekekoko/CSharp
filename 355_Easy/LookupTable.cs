using System;
using System.Collections.Generic;
using System.Linq;

namespace _355_Easy {
    class LookupTable : ILookupTable {
        public LookupTable() {
            CreateLookupTable();
        }

        private char firstCharacter = 'a';
        private char lastCharacter = 'z';
        private IDictionary<char, IDictionary<char, char>> lookUpTable;

        public char LookupCell(char row, char column) {
            return lookUpTable[row][column];
        }

        public char LookupColumn(char row, char value) {
            return lookUpTable[row].Single(keyValuePair => keyValuePair.Value.Equals(value)).Key;
        }

        public char LookupRow(char column, char value) {
            throw new System.NotImplementedException();
        }

        private  void CreateLookupTable() {
            lookUpTable = new Dictionary<char, IDictionary<char, char>>();
            for (char rowLetter = firstCharacter; rowLetter <= lastCharacter; rowLetter++) {
                IDictionary<char, char> row = CreateRow(rowLetter);
                lookUpTable.Add(rowLetter, row);
            }
        }

        private IDictionary<char, char> CreateRow(char rowLetter) {
            IDictionary<char, char> dict = new Dictionary<char, char>();
            char cellLetter = rowLetter;
            for (char columnLetter = firstCharacter; columnLetter <= lastCharacter; columnLetter++) {
                dict.Add(columnLetter, cellLetter);
                if (cellLetter == lastCharacter) {
                    cellLetter = firstCharacter;
                    continue;
                }
                cellLetter++;
            }
            return dict;
        }
    }

}