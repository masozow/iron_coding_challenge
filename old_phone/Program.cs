using old_phone.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Write your message, always ending with a #:");
        string writtenMessage = Console.ReadLine() ?? "";
        string message = writtenMessage.Contains('#') ? DecipheredMessage.OldPhonePad(Validation.ValidateMessage, writtenMessage) : "Invalid input, you should write a # after the digits.";
        Console.WriteLine("Your message is: " + message);

        //Array of messages to test in a bulk, while seeing the outputs
        // string[] messages = ["33#", "227*#", "4433555 555666#", "8 88777444666*664#", "22222*****5555444********#", "****22222#"];
        // foreach (string message in messages)
        // {
        //     Console.WriteLine("Your message is: " + DecipheredMessage.OldPhonePad(Validation.ValidateMessage, message));
        //     Console.WriteLine("-----------------");
        // }

    }
}