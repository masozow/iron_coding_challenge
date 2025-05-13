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
        /// <remarks>
        /// The method handles cases where the position is greater than the length of the character set by wrapping around to the start of the character set.
        /// </remarks>
        public static char GetChar(char key, int position)
        {
            int charactersArrayLength = CharactersDictionary.TextCodesDictionary[key]?.Length ?? 0;
            int newPosition = position >= charactersArrayLength ? position % CharactersDictionary.TextCodesDictionary[key].Length : position;
            return CharactersDictionary.TextCodesDictionary[key][newPosition];
        }
    }
}