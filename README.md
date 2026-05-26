# CSharp Async programming example using HttpClient

This is aa async program that reaches out to the [JSON Placeholder API](https://jsonplaceholder.typicode.com/) using `HttpClient` and the `GetAsync` method.

Currently, I am only using the `/posts` endpoint from JSON Placeholder, but I would like to have the user choose from posts, comments, and todos. After the user chooses, I would like to output the 1st object to the console to view the object structure.

<!--
    repo: csharp-async-httpclient-example
    project: BasicAsync
    About text: A C# project that uses the JSON Placeholder API using HttpClient and GetAsync.
 -->

<span aria-hidden="true"><br></span>

## Prerequisites

- [.NET SDK 10.0](https://dotnet.microsoft.com/en-us/download)
- [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

## Installation & Usage

1. Clone this repository and switch into project folder

   ```sh
   git clone https://github.com/Kernix13/csharp-async-httpclient-example.git BasicAsync
   cd BasicAsync
   ```

2. Run the application

   ```bash
   dotnet run
   ```

3. Build the application

   ```bash
   dotnet build
   ```

### <span aria-hidden="true">⚡</span> Quick Start

```sh
git clone https://github.com/Kernix13/csharp-async-httpclient-example.git BasicAsync
cd BasicAsync
dotnet run
```

<span aria-hidden="true"><br></span>

## New code to research

- `using System.ComponentModel;`
- `HttpResponseMessage`
- `EnsureSuccessStatusCode`
- `.Content.ReadAsStringAsync`
- `JsonNamingPolicy`

## Important notes and code for this module

- Web: Async Methods -> `HttpClient`
- Files: Async Methods -> `JsonSerializer`, `StreamReader`, `StreamWriter`

```cs
// StreamReader example
// the public keyword has an error: "The modifier 'public' is not valid for this item CS0106"?!?

string filePath = "example.txt";
string content = await ReadFileAsync(filePath);
Console.WriteLine(content);

public static async Task<string> ReadFileAsync(string filePath)
{
    using (StreamReader reader = new StreamReader(filePath))
    {
        string content = await reader.ReadToEndAsync();
        return content;
    }
}
```

<br>

- `JsonSerializer.SerializeAsync` method serializes an object to a JSON string asynchronously
- `JsonSerializer.DeserializeAsync` method deserializes a JSON string to an object asynchronously

```cs
// Example using Serialize, WriteAllTextAsync, ReadAllTextAsync, Deserialize
// This code is giving so many errors?!?
using System.Text.Json;

public class Account
{
    public string Name { get; set; }
    public decimal Balance { get; set; }
}

// Combine a directory and file name, then create the directory if it doesn't exist
string directoryPath = @"C:\TempDir";
if (!Directory.Exists(directoryPath))
{
    Directory.CreateDirectory(directoryPath);
}

string fileName = "account.json";
string filePath = Path.Combine(directoryPath, fileName);

Account account = new Account { Name = "Elize Harmsen", Balance = 1000.00m };

// Save account data to a file asynchronously
await SaveAccountDataAsync(filePath, account);

// Load account data from the file asynchronously
Account loadedAccount = await LoadAccountDataAsync(filePath);
Console.WriteLine($"Name: {loadedAccount.Name}, Balance: {loadedAccount.Balance}");

public static async Task SaveAccountDataAsync(string filePath, Account account)
{
    string jsonString = JsonSerializer.Serialize(account);
    await File.WriteAllTextAsync(filePath, jsonString);
}

public static async Task<Account> LoadAccountDataAsync(string filePath)
{
    string jsonString = await File.ReadAllTextAsync(filePath);
    return JsonSerializer.Deserialize<Account>(jsonString);
}
```

<br>

`HttpClient` for asynchronous API calls

- `GetAsync`: Sends a GET request to the specified URI and returns the response.
- `PostAsync`: Sends a POST request to the specified URI with the specified content and returns the response.
- `PutAsync`: Sends a PUT request to the specified URI with the specified content and returns the response.
- `DeleteAsync`: Sends a DELETE request to the specified URI and returns the response.
- `SendAsync`: Sends an HTTP request message and returns the response.

```cs
// Example using HttpClient, GetAsync, ReadAsStringAsync, Deserialize
using System.Text.Json;

using (HttpClient client = new HttpClient())
{
      try
      {
         // PetStore API endpoint
         string url = "https://petstore.swagger.io/v2/pet/findByStatus?status=available";
         HttpResponseMessage response = await client.GetAsync(url);
         response.EnsureSuccessStatusCode();
         string responseBody = await response.Content.ReadAsStringAsync();
         //Console.WriteLine($"Response: {responseBody}");

         // Deserialize the JSON response into a list of pets
         var pets = JsonSerializer.Deserialize<List<Pet>>(responseBody);

         // Iterate through the list of pets and display their details
         foreach (var pet in pets)
         {
            //Console.WriteLine($"Pet ID: {pet.id}, Name: {pet.name}");
            if (pet.id.ToString().Length > 4)
            {
                  Console.WriteLine($"Pet ID: {pet.id}, Name: {pet.name}");
            }
         }
      }
      catch (HttpRequestException e)
      {
         Console.WriteLine($"Request error: {e.Message}");
      }
}

public class Pet
{
    public long id { get; set; }
    public string name { get; set; }
    public Category category { get; set; }
    public List<string> photoUrls { get; set; }
    public List<Tag> tags { get; set; }
    public string status { get; set; }
}

public class Category
{
    public long id { get; set; }
    public string name { get; set; }
}

public class Tag
{
    public long id { get; set; }
    public string name { get; set; }
}
```

<br>

- `HttpClient` class is used to send an asynchronous GET request to the PetStore API
- The response is read as a string and deserialized into a list of `Pet` objects using the `JsonSerializer` class
- The code then iterates through the list of pets and displays their details
- The `using` statement ensures that the `HttpClient` instance is disposed of properly after use
