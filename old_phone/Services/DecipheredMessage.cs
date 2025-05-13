using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using old_phone.Utilities;
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
            //we also check that the input indeed contains a # symbol
            if (!validationMethod(message) || !message.Contains('#'))
            {
                return "Invalid input";
            }
            //The string where the deciphered message will be stored
            string newMessage = "";
            //Counter to keep track of consecutive identical characters
            int counter = 1;

            //Storing the first character to compare it with the next ones
            char theCharacter = message[0];
            //Going through the message string
            for (int i = 1; i < message.Length; i++)
            {
                //If the current character is the same as the stored one, we keep track of it's ocurrencies
                if (message[i] == theCharacter)
                {
                    counter++;
                }
                else if (message[i] == ' ') //If the current character is a space
                {
                    newMessage = Handlers.SpaceHandler(ref counter, ref i, message, ref theCharacter, newMessage);
                }
                else if (message[i] == '*') //If the current character is an asterisk, we create the logic to remove the number ocurrency
                {
                    newMessage = Handlers.AsteriskHandler(ref counter, ref i, message, ref theCharacter, newMessage);
                }
                else if (message[i] == '#') //If the current character is a hashtag, it's going to be the end of the message
                {
                    if (counter > 0) //If there were left any ocurrency of a number that hasn't been hashed and stored
                    {
                        newMessage += HashingNumberToChar.GetChar(theCharacter, counter - 1);
                    }
                    break;
                }
                else //If we haven't found any special character, there will be only numbers
                {
                    //Inside this else, we enter if the current character is different from the stored one
                    //so we'll store the corresponding character to the ocurrency of the number.
                    //If there was only numbers, this were the only hashing and storing logic we needed
                    if (counter > 0)
                    {
                        newMessage += HashingNumberToChar.GetChar(theCharacter, counter - 1);
                    }
                    //Store a new number or special character to compare it with the next ones
                    theCharacter = message[i];
                    //Reset the counter
                    counter = 1;
                }
            }
            return newMessage.ToUpper();
        }

    }
}