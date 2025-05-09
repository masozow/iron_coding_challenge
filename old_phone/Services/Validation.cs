using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using old_phone.Data;

namespace old_phone.Services
{
    public static class Validation
    {
        public static bool ValidateMessage(string message)
        {
            return message.All(c => AllowedCharacters.AllowedCharactersArray.Contains(c));
        }
        public delegate bool ValidateMessageDelegate(string message);
    }
}