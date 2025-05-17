// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

var builder = Kernel.CreateBuilder();
builder.AddOllamaChatCompletion("deepseek-r1:latest", new Uri("http://localhost:11434"));
builder.Services.AddScoped<HttpClient>();

var kernel = builder.Build();

while (true)
{
    Console.WriteLine("> ");
    var line = Console.ReadLine();
    var response = await kernel.InvokePromptAsync(line);    
    Console.WriteLine(response);
}