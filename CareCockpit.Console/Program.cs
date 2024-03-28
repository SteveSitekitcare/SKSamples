using CareCockpit.Console.Plugins;
using Microsoft.Extensions.Configuration;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using System.Reflection;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
    .AddCommandLine(args)
    .Build();

var modelId = config["modelId"];
var apiKey = config["apiKey"];

var builder = Kernel.CreateBuilder()
                    .AddOpenAIChatCompletion(modelId, apiKey);

builder.Plugins.AddFromType<ConversationSummaryPlugin>();
Kernel kernel = builder.Build();

// Load prompts
var prompts = kernel.CreatePluginFromPromptDirectory("../../../Plugins/Prompts");

// Create chat history
ChatHistory history = new();

// Start the chat loop
Console.Write("User > ");
string? userInput;
while ((userInput = Console.ReadLine()) != null)
{

    // Get chat response
    var chatResult = kernel.InvokeStreamingAsync<StreamingChatMessageContent>(
        prompts["chat"],
        new()
        {
            { "request", userInput },
            { "history", string.Join("\n", history.Select(x => x.Role + ": " + x.Content)) }
        }
    );

    // Stream the response
    string message = "";
    await foreach (var chunk in chatResult)
    {
        if (chunk.Role.HasValue)
        {
            Console.Write(chunk.Role + " > ");
        }
        message += chunk;
        Console.Write(chunk);
    }
    Console.WriteLine();

    // Append to history
    history.AddUserMessage(userInput);
    history.AddAssistantMessage(message);

    // Get user input again
    Console.Write("User > ");
}