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
        /// <param name="positionInTheInputArray">The index of the current character in the message.</param>
        /// <param name="message">The message string.</param>
        /// <param name="theCharacter">The character to compare with the next ones.</param>
        /// <param name="newMessage">The string where the deciphered message will be stored.</param>
        /// <returns>The deciphered message.</returns>
        public static string SpaceHandler(ref int counter, ref int positionInTheInputArray, string message, ref char theCharacter, string newMessage = "")
        {
            if (counter > 0) //If there were any consecutive identical characters
            {
                //Hash the corresponding character according to the number of consecutive identical characters
                newMessage += HashingNumberToChar.GetChar(theCharacter, counter - 1);
            }
            //Store the next character to compare it with the next ones
            theCharacter = message[positionInTheInputArray + 1];
            //Reset the counter
            counter = 1;
            //Skip the space in the string
            positionInTheInputArray++;
            return newMessage;
        }
        /// <summary>
        /// Handles the logic when an asterisk is encountered.
        /// </summary>
        /// <param name="counter">The counter for consecutive identical characters, passed by reference to modify the original variable.</param>
        /// <param name="positionInTheInputArray">The index of the current character in the message, passed by reference to modify the original variable.</param>
        /// <param name="message">The message string.</param>
        /// <param name="theCharacter">The character to compare with the next ones, passed by reference to modify the original variable.</param>
        /// <param name="newMessage">The string where the deciphered message will be stored, and the actual value of the deciphered message.</param>
        /// <returns>The deciphered message.</returns>
        /// <remarks>
        /// This method handles the logic when an asterisk is encountered. If there were more than one consecutive identical digit characters, it decreases the counter to remove one ocurrency of the last character,
        /// so we get the right character. It also counts how many consecutive asterisks are in the message after the first one we found, and subtracts that amount from the counter.
        /// Then, it adds the corresponding character to the new message string, but we reduce the ocurrency by one, so we don't get out of index. If the counter is negative, it means we have removed more than the available consecutive characters in the input string,
        /// so we get the absolute value of the counter to remove the same amount of characters from the original message. If the counter is zero or positive, it means we haven't removed more than the available consecutive characters in the input string,
        /// so we just add the corresponding character to the new message string.
        /// </remarks>
        public static string AsteriskHandler(ref int counter, ref int positionInTheInputArray, string message, ref char theCharacter, string newMessage = "")
        {
            //Removing asteriks at the begining of the string, because they won't do anything
            while (message[0] == '*')
            {
                message = message[1..];
            }
            int asteriskCounter = 0;
            if (counter > 1) //If there were more than one consecutive identical digit characters
            {
                //Decrease the counter to remove one ocurrency of the last character,
                //so we get the right character
                Console.WriteLine("Message in this position: " + message[positionInTheInputArray]);
                //We count how many consecutive asterisks are in the message after the first we found
                while (message[positionInTheInputArray + asteriskCounter] == '*')
                {
                    asteriskCounter++;
                }
                Console.WriteLine("Counter before asterisk diminishing it: " + counter);
                Console.WriteLine("Counter from asterisk before the operation: " + asteriskCounter);
                counter -= asteriskCounter;
                Console.WriteLine("Actual counter without asterisk: " + counter);

                Console.WriteLine("Position in the message: " + positionInTheInputArray);
                //Add the corresponding character but we reduce the ocurrency by one, so we don't get out of index
                if (counter > 0)
                    newMessage += HashingNumberToChar.GetChar(theCharacter, counter - 1);
                else if (counter < 0) //We check if we have removed more than the available consecutive characters in the input string
                {
                    //If we have removed more than the available consecutive characters in the input string,
                    //we get the absolute value of the counter to remove the same amount of characters from the original message
                    int amountOfCharactersToBeDeleted = Math.Abs(counter);
                    //Adding a condition to remove only the amount of extra aterisks, but if there's only an extra one, we 
                    //just remove one
                    newMessage = newMessage[..Math.Max(0, amountOfCharactersToBeDeleted > 1 ? newMessage.Length - amountOfCharactersToBeDeleted : 1)];
                }
            }
            if (positionInTheInputArray + 1 < message.Length) //If there is a character after the asterisk, it means we haven't reach the array boundary in the message
            {
                //Now we'll grab the character after all of the asterisks to compare with the next numeric characters in the message
                theCharacter = message[positionInTheInputArray + (asteriskCounter > 1 ? asteriskCounter : 1)];
                //Reset the counter
                counter = 1;
                //Skip all the consecutive asterisk ocurrencies
                positionInTheInputArray += asteriskCounter > 1 ? asteriskCounter : 1;
            }
            return newMessage;
        }
    }
}