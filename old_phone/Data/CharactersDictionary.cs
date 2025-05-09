using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace old_phone.Data
{
    public static class CharactersDictionary
    {
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
            { '0', new char[] { ' '} },
            { '*', new char[] { '*'} },
            { '#', new char[] { '\n'} }
        };

        public static Dictionary<char, char[]> TextCodesDictionary { get => textCodesDictionary; }
    }
}