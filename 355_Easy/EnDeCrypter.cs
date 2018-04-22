using System.Text;

namespace _355_Easy {
    public class EnDeCrypter {

        private ILookupTable lookupTable;
        public EnDeCrypter(ILookupTable lookupTable) {
            this.lookupTable = lookupTable;
        }

        public string Encrypt(string keyword, string sentence) {
            StringBuilder result = new StringBuilder();
            char[] sentenceArray = sentence.ToCharArray();
            char[] keyWordArray = keyword.ToCharArray();
            for (int i = 0; i < sentenceArray.Length; i++) {
                char encryptedCharacter = lookupTable.LookupCell(keyWordArray[i], sentenceArray[i]);
                result.Append(encryptedCharacter);
            }
            return result.ToString();
        }

        public string Decrypt(string keyword, string sentence) {
            StringBuilder result = new StringBuilder();
            char[] sentenceArray = sentence.ToCharArray();
            char[] keyWordArray = keyword.ToCharArray();
            for (int i = 0; i < sentenceArray.Length; i++) {
                result.Append( lookupTable.LookupColumn(keyWordArray[i], sentenceArray[i]));
            }
            return result.ToString();
        }
    }
}