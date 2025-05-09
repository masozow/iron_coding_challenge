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
            char theCharacter = message[0];
            int counter = 0;
            if (message.Length > 1)
            {
                for (int i = 1; i < message.Length; i++)
                {
                    if (message[i] == theCharacter)
                    {
                        counter++;
                        Console.WriteLine("Counter: " + counter);
                    }
                    else
                    {
                        // Console.WriteLine("Actual character: " + message[i]);
                        // Console.WriteLine("Entering the string assembly: " + counter);
                        if (message[i] == ' ')
                        {
                            counter = 0;
                            theCharacter = message[i+1];
                            i++;
                            continue; 
                        }else{
                            if(theCharacter!='*'&&counter>=1){
                                newMessage += HashingNumberToChar.GetChar(theCharacter, message[i] == '*' ? counter - 1 : counter);    
                            }
                            // Console.WriteLine("newMessage: " + newMessage);
                            counter = 0;
                            theCharacter = message[i];
                        }
                    }
                    if (message[i] == '#') break;
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