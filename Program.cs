using System.Text.Json;
using BasicAsync;

using HttpClient client = new HttpClient();

// I am only hitting /posts right now
try
{
    string url = "https://jsonplaceholder.typicode.com/posts";

    // catch GET request in a variable
    // look into HttpResponseMessage
    HttpResponseMessage response = await client.GetAsync(url);

    // throw error is response code is not within 200-299
    // look into EnsureSuccessStatusCode
    response.EnsureSuccessStatusCode();

    // ReadAsStringAsync: Serialize the HTTP content to a string
    string responseBody = await response.Content.ReadAsStringAsync();

    // Console.WriteLine($"Response: {responseBody}");

    // Configure options to handle camelCase JSON
    var options = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    // Use the null-coalescing operator (??) to fall back to an empty list
    var posts = JsonSerializer.Deserialize<List<Post>>(responseBody, options) ?? new List<Post>();

    // Consider allowing the user to also choose comments & todos
    foreach (var post in posts)
    {
        if (post.UserId == 1)
        {
            Console.WriteLine($"Post ID: {post.Id}, Title: {post.Title}");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}


