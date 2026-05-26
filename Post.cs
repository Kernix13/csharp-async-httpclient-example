namespace BasicAsync;

// https://jsonplaceholder.typicode.com/posts

public class Post
{
  public int UserId { get; set; }
  public int Id { get; set; }
  public string? Title { get; set; }
  public string? Body { get; set; }

  // no constructor needed - just deserializing data from an API (DTO)
}