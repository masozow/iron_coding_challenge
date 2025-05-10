using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static old_phone.Services.Validation;

namespace old_phone.Services
{
    public static class DecipheredMessage
    {
        /// <summary>
        /// Deciphers a string message using a traditional old phone keypad mapping.
        /// </summary>
        /// <param name="validationMethod">A delegate method to validate the input message.</param>
        /// <param name="message">The string message to be decoded.</param>
        /// <returns>The deciphered message in uppercase. Returns "Invalid input" if the message fails validation.</returns>
        /// <remarks>
        /// The method interprets sequences of numeric and special characters to produce corresponding text:
        /// - Consecutive identical numeric characters are interpreted as repeated key presses.
        /// - A space character indicates the end of a sequence for a single character.
        /// - An asterisk (*) allows for backspacing once in the current sequence.
        /// - A hash (#) signifies the end of the message.
        /// The method uses a character hashing utility to map sequences to characters.
        /// </remarks>
        public static string OldPhonePad(ValidateMessageDelegate validationMethod, string message)
        {
            //Validating the input to only receive numeric characters, space, asterisk and hashtag
            if (!validationMethod(message))
            {
                return "Invalid input";
            }
            //The string where the deciphered message will be stored
            string newMessage = "";
            //Counter to keep track of consecutive identical characters
            int counter = 1;

            //Removing asteriks at the begining of the string, because they won't do anything
            while (message[0] == '*')
            {
                message = message[1..];
            }

            //Storing the first character to compare it with the next ones
            char theCharacter = message[0];
            for (int i = 1; i < message.Length; i++)
            {
                if (message[i] == theCharacter)
                {
                    counter++;
                    Console.WriteLine("Counter: " + counter);
                }
                else if (message[i] == ' ')
                {
                    if (counter > 0)
                    {
                        newMessage += HashingNumberToChar.GetChar(theCharacter, counter - 1);
                    }
                    theCharacter = message[i + 1];
                    counter = 1;
                    i++;
                }
                else if (message[i] == '*')
                {
                    if (counter > 1)
                    {
                        counter--;
                        newMessage += HashingNumberToChar.GetChar(theCharacter, counter - 1);
                    }
                    if (i + 1 < message.Length)
                    {
                        theCharacter = message[i + 1];
                        counter = 1;
                        i++;
                    }
                }
                else if (message[i] == '#')
                {
                    if (counter > 0)
                    {
                        newMessage += HashingNumberToChar.GetChar(theCharacter, counter - 1);
                    }
                    break;
                }
                else
                {
                    if (counter > 0)
                    {
                        newMessage += HashingNumberToChar.GetChar(theCharacter, counter - 1);
                    }
                    theCharacter = message[i];
                    counter = 1;
                }
            }
            return newMessage.ToUpper();
        }
    }
}