using Microsoft.SemanticKernel;
using System.ComponentModel;

public class vectorDatabasePlugin
{
    [KernelFunction]
    [Description("Contains information regarding the purpose and usage of the Lifebook app, such as what features there are and how they work.")]
    public void LifebookTopic()
    {
        // Add logic to send an email using the recipientEmails, subject, and body
        // For now, we'll just print out a success message to the console
        Console.WriteLine("Lifebook is great!");
    }

    [KernelFunction]
    [Description("Contains localised information about resources that may be relevant to the user's context, such as information sources (websites), charities and facilities such as community centres, hairdressers, etc.")]
    public void LocalResourcesTopic()
    {
        // Add logic to send an email using the recipientEmails, subject, and body
        // For now, we'll just print out a success message to the console
        Console.WriteLine("Local Resources Topics");
    }

    [KernelFunction]
    [Description("Contains information about the Care System in the UK, and local information relevant to the user, about topics such as how to get a care assessment, the types of care you can get, and what might be right for you.")]
    public void CareSystemTopic()
    {
        // Add logic to send an email using the recipientEmails, subject, and body
        // For now, we'll just print out a success message to the console
        Console.WriteLine("Care System Topic");
    }
}
