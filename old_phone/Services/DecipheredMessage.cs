using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static old_phone.Services.Validation;

namespace old_phone.Services
{
    public static class DecipheredMessage
    {
        public static string OldPhonePad(ValidateMessageDelegate validationMethod, string message)
        {
            if (!validationMethod(message))
            {
                return "Invalid input";
            }
            string newMessage = "";
            int counter = 0;
            if (message.Length > 1)
            {
                for (int i = 0; i < message.Length - 1; i++)
                {
                    if (message[i] == message[i + 1] || message[i] != '#')
                    {
                        counter++;
                        Console.WriteLine($"Counter: {counter}");
                    }
                    else
                    {
                        newMessage += HashingNumberToChar.GetChar(message[i], counter);
                        counter = i;
                    }
                }
            }
            else
            {
                newMessage += HashingNumberToChar.GetChar(message[0], 0);
            }
            return newMessage;
        }
    }
}