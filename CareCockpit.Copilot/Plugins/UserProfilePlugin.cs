using Microsoft.SemanticKernel;
using System.ComponentModel;

public class UserProfilePlugin
{
    [KernelFunction]
    [Description("Contains a basic set of information about the user, such as names, address, and contact details.")]
    public void UserProfile()
    {
        // Add logic to send an email using the recipientEmails, subject, and body
        // For now, we'll just print out a success message to the console
        Console.WriteLine("User Profile Plugin");
    }
}
