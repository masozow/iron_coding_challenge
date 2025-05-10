using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using old_phone.Services;

namespace old_phone.Utilities
{
    /// <summary>
    /// A static class containing handlers for special characters in a message.
    /// </summary>
    public static class Handlers
    {
        /// <summary>
        /// Handles the logic when a space is encountered.
        /// </summary>
        /// <param name="counter">The counter for consecutive identical characters.</param>
        /// <param name="i">The index of the current character in the message.</param>
        /// <param name="message">The message string.</param>
        /// <param name="theCharacter">The character to compare with the next ones.</param>
        /// <param name="newMessage">The string where the deciphered message will be stored.</param>
        /// <returns>The deciphered message.</returns>
        public static string SpaceHandler(ref int counter, ref int i, string message, ref char theCharacter, string newMessage = "")
        {
            if (counter > 0) //If there were any consecutive identical characters
            {
                //Hash the corresponding character according to the number of consecutive identical characters
                newMessage += HashingNumberToChar.GetChar(theCharacter, counter - 1);
            }
            //Store the next character to compare it with the next ones
            theCharacter = message[i + 1];
            //Reset the counter
            counter = 1;
            //Skip the space in the string
            i++;
            return newMessage;
        }
        /// <summary>
        /// Handles the logic when an asterisk is encountered.
        /// </summary>
        /// <param name="counter">The counter for consecutive identical characters.</param>
        /// <param name="i">The index of the current character in the message.</param>
        /// <param name="message">The message string.</param>
        /// <param name="theCharacter">The character to compare with the next ones.</param>
        /// <param name="newMessage">The string where the deciphered message will be stored.</param>
        /// <returns>The deciphered message.</returns>
        public static string AsteriskHandler(ref int counter, ref int i, string message, ref char theCharacter, string newMessage = "")
        {
            if (counter > 1) //If there were more than one consecutive identical numbers
            {
                //Decrease the counter to remove one ocurrency of the last character
                counter--;
                //Add the character but we reduce the ocurrency by one, so it's going to be another character according to the dictionary
                newMessage += HashingNumberToChar.GetChar(theCharacter, counter - 1);
            }
            if (i + 1 < message.Length) //If there is a character after the asterisk, it means we haven't reach the array boundary
            {
                //Now we'll be using the character after the asterisk to compare
                theCharacter = message[i + 1];
                //Reset the counter
                counter = 1;
                //Skip the asterisk
                i++;
            }
            return newMessage;
        }
    }
}