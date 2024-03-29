using Microsoft.SemanticKernel;
using System.ComponentModel;

public class PotatoesInAmericaPlugin
{
    [KernelFunction]
    [Description("Tells the user how many potatoes are in america")]
    public void AnswerQuestion()
    {
        // Add logic to send an email using the recipientEmails, subject, and body
        // For now, we'll just print out a success message to the console
        Console.WriteLine("There are 56 potatoes in america");
    }
}
