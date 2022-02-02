using System.Text;
using SysRnd = System.Random;

namespace Mahamudra.Cryptography.Random
{
    public class Rnd
    {
        private readonly SysRnd _random = new SysRnd();
        public Rnd(SysRnd random = null)
        {
            this._random = random ?? new SysRnd();
        }

        // Generates a random string with a given size.    
        public string RandomString(int size)
        {
            var stringBuilder = new StringBuilder(size);
            // The Basic Latin or C0 Controls and Basic Latin Unicode block is the first block of the Unicode standard, 
            // and the only block which is encoded in one byte in UTF-8

            // 65–90 decimal uppercase letters 
            // 97–122 decimal lowercase letters  

            // char is a single Unicode character  
            char offsetLowerCase = 'a';
            char offsetUpperCase = 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  
            char lowerLetter() => (char)_random.Next(offsetLowerCase, offsetLowerCase + lettersOffset);
            char upperLetter() => (char)_random.Next(offsetUpperCase, offsetUpperCase + lettersOffset);

            for (var i = 0; i < size; i++)
            {
                char @char;
                // we alternate lower and upper letters
                var index = _random.Next(0, 52);
                if (index <= 26)
                    @char = lowerLetter();
                else
                    @char = upperLetter();

                stringBuilder.Append(@char);
            }

            return stringBuilder.ToString();
        }
    }
}
