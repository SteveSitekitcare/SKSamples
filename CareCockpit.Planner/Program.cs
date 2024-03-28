using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel.Planning.Handlebars;
using Microsoft.Extensions.Logging;
using Plugins;
using System.Linq;
using System.Xml.Linq;
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

// Create the kernel
var builder = Kernel.CreateBuilder();

builder.Services.AddLogging(c => c.SetMinimumLevel(LogLevel.Trace));
builder.Services.AddOpenAIChatCompletion(modelId, apiKey);
builder.Plugins.AddFromType<MathPlugin>();

Kernel kernel = builder.Build();

#pragma warning disable SKEXP0060 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
var planner = new HandlebarsPlanner(new HandlebarsPlannerOptions() { AllowLoops = true });
#pragma warning restore SKEXP0060 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

// Retrieve the chat completion service from the kernel
IChatCompletionService chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

// Start the conversation
while (true)
{
    // Get user input
    System.Console.Write("User > ");
    
    // Create a plan
#pragma warning disable SKEXP0060 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
    var plan = await planner.CreatePlanAsync(kernel, Console.ReadLine());
    Console.WriteLine("Plan: {0}", plan.ToString());

    // Execute the plan
    var result = (await plan.InvokeAsync(kernel)).Trim();
    Console.WriteLine("Results: {0}", result.ToString());
#pragma warning restore SKEXP0060 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.    

}

