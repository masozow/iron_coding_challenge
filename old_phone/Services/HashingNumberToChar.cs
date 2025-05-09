using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using old_phone.Data;

namespace old_phone.Services
{
    public class HashingNumberToChar
    {
        public static char GetChar(char key, int position)
        {
            return CharactersDictionary.TextCodesDictionary[key][position];
        }
    }
}