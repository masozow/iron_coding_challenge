using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace old_phone.Data
{
    /// <summary>
    /// A static class containing a read-only dictionary mapping numeric characters to arrays of possible corresponding text characters.
    /// </summary>
    public static class CharactersDictionary
    {
        /// <summary>
        /// A dictionary that maps numeric characters to arrays of corresponding text characters, 
        /// representing key presses on a traditional old phone keypad.
        /// </summary>
        private static readonly Dictionary<char, char[]> textCodesDictionary = new()
        {
            { '1', new char[] { '&', '\'', '(' } },
            { '2', new char[] { 'a', 'b', 'c' } },
            { '3', new char[] { 'd', 'e', 'f' } },
            { '4', new char[] { 'g', 'h', 'i' } },
            { '5', new char[] { 'j', 'k', 'l' } },
            { '6', new char[] { 'm', 'n', 'o' } },
            { '7', new char[] { 'p', 'q', 'r', 's' } },
            { '8', new char[] { 't', 'u', 'v' } },
            { '9', new char[] { 'w', 'x', 'y', 'z' } },
            { '0', new char[] { ' ' } },
            { '*', new char[] { '*' } },
            { '#', new char[] { '\n' } }
        };

        /// <summary>
        /// A read-only dictionary mapping numeric characters to arrays of possible corresponding text characters.
        /// </summary>
        public static Dictionary<char, char[]> TextCodesDictionary { get => textCodesDictionary; }
    }
}