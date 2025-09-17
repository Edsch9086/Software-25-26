using System.Net;
using System.Text;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Create and start the HTTP listener
var listener = new HttpListener();
listener.Prefixes.Add("http://127.0.0.1:1025/");
listener.Start();
Console.WriteLine("Listening on http://127.0.0.1:1025/");

while (true)
{
    var context = await listener.GetContextAsync();
    var request = context.Request;

    // Print the raw request URL
    Console.WriteLine($"Request URL: {request.Url}");

    // Decode and print WLED-style query parameters
    var rgbw = "";
    var brightness = "";
    var debugInfo = new StringBuilder();
    if (!string.IsNullOrEmpty(request.Url.Query))
    {
        Console.WriteLine("Decoded WLED API parameters:");
        var query = request.Url.Query.TrimStart('?');
        var parameters = query.Split('&');
        foreach (var param in parameters)
        {
            var kv = param.Split('=');
            if (kv.Length == 2)
            {
                Console.WriteLine($"{kv[0]} = {kv[1]}");
                debugInfo.AppendLine($"{kv[0]} = {kv[1]}");
                if (kv[0].Equals("R", StringComparison.OrdinalIgnoreCase) ||
                    kv[0].Equals("G", StringComparison.OrdinalIgnoreCase) ||
                    kv[0].Equals("B", StringComparison.OrdinalIgnoreCase) ||
                    kv[0].Equals("W", StringComparison.OrdinalIgnoreCase))
                {
                    rgbw += $"{kv[0]}={kv[1]} ";
                }
                if (kv[0].Equals("A", StringComparison.OrdinalIgnoreCase) ||
                    kv[0].Equals("brightness", StringComparison.OrdinalIgnoreCase))
                {
                    brightness = kv[1];
                }
            }
            else
            {
                Console.WriteLine($"{kv[0]} (flag)");
                debugInfo.AppendLine($"{kv[0]} (flag)");
            }
        }
    }

    var response = context.Response;
    var responseString = new StringBuilder("<html><body><ul>");
    if (!string.IsNullOrEmpty(rgbw))
        responseString.Append($"<li>RGBW: {rgbw.Trim()}</li>");
    if (!string.IsNullOrEmpty(brightness))
        responseString.Append($"<li>Brightness: {brightness}</li>");
    responseString.Append("</ul>");

    // Add debug information
    responseString.Append("<hr><h3>Debug Information</h3><pre>");
    responseString.Append($"Method: {request.HttpMethod}\n");
    responseString.Append($"Raw URL: {request.RawUrl}\n");
    responseString.Append($"User Host Address: {request.UserHostAddress}\n");
    responseString.Append($"Headers:\n");
    foreach (string key in request.Headers.AllKeys)
    {
        responseString.Append($"{key}: {request.Headers[key]}\n");
    }
    responseString.Append("Decoded Query Parameters:\n");
    responseString.Append(debugInfo.ToString());
    responseString.Append("</pre>");

    // Add WLED information
    responseString.Append("<hr><h3>WLED Information</h3><pre>");
    if (!string.IsNullOrEmpty(rgbw))
        responseString.Append($"RGBW: {rgbw.Trim()}\n");
    if (!string.IsNullOrEmpty(brightness))
        responseString.Append($"Brightness: {brightness}\n");
    responseString.Append("</pre></body></html>");

    var buffer = Encoding.UTF8.GetBytes(responseString.ToString());

    // Print debug information and WLED info to the console
    Console.WriteLine("---- Debug Information ----");
    Console.WriteLine($"Method: {request.HttpMethod}");
    Console.WriteLine($"Raw URL: {request.RawUrl}");
    Console.WriteLine($"User Host Address: {request.UserHostAddress}");
    Console.WriteLine("Headers:");
    foreach (string key in request.Headers.AllKeys)
    {
        Console.WriteLine($"{key}: {request.Headers[key]}");
    }
    Console.WriteLine("Decoded Query Parameters:");
    Console.WriteLine(debugInfo.ToString());
    Console.WriteLine("--------------------------");

    Console.WriteLine("---- WLED Information ----");
    if (!string.IsNullOrEmpty(rgbw))
        Console.WriteLine($"RGBW: {rgbw.Trim()}");
    if (!string.IsNullOrEmpty(brightness))
        Console.WriteLine($"Brightness: {brightness}");
    Console.WriteLine("--------------------------");

    response.ContentLength64 = buffer.Length;
    await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
    response.OutputStream.Close();
}
