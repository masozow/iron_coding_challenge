using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace old_phone.Data
{
    /// <summary>
    /// A read-only struct containing an array of allowed characters.
    /// </summary>
    public readonly struct AllowedCharacters
    {
        public static readonly char[] AllowedCharactersArray =
        {
            '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '*', '#', ' '
        };
    }
}