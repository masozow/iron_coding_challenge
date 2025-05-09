using old_phone.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Write your message:");
        string message = Console.ReadLine() ?? "";
        Console.WriteLine("Your message is: " + DecipheredMessage.OldPhonePad(Validation.ValidateMessage, message));
    }
}