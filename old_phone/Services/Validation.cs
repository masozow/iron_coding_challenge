using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using old_phone.Data;

namespace old_phone.Services
{
    public static class Validation
    {
        /// <summary>
        /// Validates that a given message contains only valid characters.
        /// </summary>
        /// <param name="message">The message to be validated.</param>
        /// <returns>true if the message contains only valid characters, false otherwise.</returns>
        public static bool ValidateMessage(string message)
        {
            return message.All(c => AllowedCharacters.AllowedCharactersArray.Contains(c));
        }
        /// <summary>
        /// A delegate method for validating a message.
        /// </summary>
        /// <param name="message">The message to be validated.</param>
        /// <returns>true if the message is valid, false otherwise.</returns>
        public delegate bool ValidateMessageDelegate(string message);
    }
}