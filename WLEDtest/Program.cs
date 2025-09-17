using System;
using System.Net.Http;
using System.Threading.Tasks;


HttpClient client = new HttpClient();

Console.WriteLine("wled test program");

Console.WriteLine("red");
int red = int.Parse(Console.ReadLine());

Console.WriteLine("green");
int green = int.Parse(Console.ReadLine());

Console.WriteLine("blue");
int blue = int.Parse(Console.ReadLine());

Console.WriteLine("white");
int white = int.Parse(Console.ReadLine());

Console.WriteLine("brightness (0-255)");
int brightness = int.Parse(Console.ReadLine());

Console.WriteLine("wled ip");
string ip = Console.ReadLine();

string url = $"http://{ip}/win&A={brightness}&R={red}&G={green}&B={blue}&W={white}";

try
{
    // Send the GET request asynchronously
    HttpResponseMessage response = await client.GetAsync(url);

    // Ensure the request was successful (status code 200-299)
    response.EnsureSuccessStatusCode();

    // Read the response content as a string
    string responseBody = await response.Content.ReadAsStringAsync();

    // Print the response to the console
    Console.WriteLine($"Response from {url}:\n{responseBody}");
}
catch (HttpRequestException e)
{
    Console.WriteLine($"Error during HTTP request: {e.Message}");
}
catch (Exception e)
{
    Console.WriteLine($"An unexpected error occurred: {e.Message}");
}

    
