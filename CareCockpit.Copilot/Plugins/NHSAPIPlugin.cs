using Microsoft.SemanticKernel;
using System.ComponentModel;

public class NHSAPIPlugin
{
    [KernelFunction]
    [Description("Contains NHS-provided in-depth information about a wide range of medical conditions (e.g. dementia, diabetes, etc), and includes information on the symptoms, causes, complications etc.")]
    public void NHSAPI()
    {
        // Add logic to send an email using the recipientEmails, subject, and body
        // For now, we'll just print out a success message to the console
        Console.WriteLine("NHS API Plugin");
    }
}
