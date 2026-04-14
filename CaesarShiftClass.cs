using System.Linq;

namespace CaesarShift
{
    public class CaesarShiftClass
    {
        private readonly int _key;

        public CaesarShiftClass(int key)
        {
            _key = key % 26;
        }

        public string Encrypt(string input)
        {
            return Shift(input, _key);
        }

        public string Decrypt(string input)
        {
            return Shift(input, -_key);
        }

        private string Shift(string text, int shift)
        {
            return new string(text.Select(c =>
            {
                if (!char.IsLetter(c)) return c;

                char baseChar = char.IsUpper(c) ? 'A' : 'a';
                int offset = c - baseChar;

                return (char)(baseChar + (offset + shift + 26) % 26);
            }).ToArray());
        }
    }
}