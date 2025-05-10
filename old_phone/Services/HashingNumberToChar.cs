using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using old_phone.Data;

namespace old_phone.Services
{
    public class HashingNumberToChar
    {
        /// <summary>
        /// Retrieves the character corresponding to a given key and position on a traditional old phone keypad.
        /// </summary>
        /// <param name="key">The numeric key from the keypad.</param>
        /// <param name="position">The position of the desired character within the key's character set.</param>
        /// <returns>The character at the specified position for the given key.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when the specified key is not present in the dictionary.</exception>
        /// <exception cref="IndexOutOfRangeException">Thrown when the position is out of range for the character set of the specified key.</exception>
        public static char GetChar(char key, int position)
        {
            return CharactersDictionary.TextCodesDictionary[key][position];
        }
    }
}