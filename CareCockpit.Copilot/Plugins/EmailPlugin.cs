using Microsoft.SemanticKernel;
using System.ComponentModel;
using System.Net.Mail;
using System.Net;


public class EmailPlugin
{
    [KernelFunction]
    [Description("Sends an email to a recipient.")]
    public async Task SendEmailAsync(
        Kernel kernel,
        [Description("Semicolon delimitated list of emails of the recipients")] string recipientEmails,
        string subject,
        string body
    )
    {
        var smtpClient = new SmtpClient("192.168.0.250")
        {
            Port = 25,
            EnableSsl = false,
        };

        smtpClient.Send("sarah@example.com", recipientEmails, subject, body);
        // Add logic to send an email using the recipientEmails, subject, and body
        // For now, we'll just print out a success message to the console
        Console.WriteLine("Email sent!");
    }
}




