using old_phone.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Write your message:");
        string message = Console.ReadLine() ?? "";
        // string[] messages=["33#","227*#","4433555 555666#","8 88777444666*664#"];
        // foreach(string message in messages){
        //     Console.WriteLine("Your message is: " + DecipheredMessage.OldPhonePad(Validation.ValidateMessage, message));
        //     Console.WriteLine("-----------------");
        // }
        Console.WriteLine("Your message is: " + DecipheredMessage.OldPhonePad(Validation.ValidateMessage, message));
    }
}