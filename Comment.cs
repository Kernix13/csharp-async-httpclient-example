namespace BasicAsync;

// https://jsonplaceholder.typicode.com/comments

public class Comment
{
    public int PostId { get; set; }
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Body { get; set; }

    // no constructor needed - just deserializing data from an API (DTO)
}

/*

{
    "postId": 1,
    "id": 1,
    "name": "id labore ex et quam laborum",
    "email": "Eliseo@gardner.biz",
    "body": "laudantium enim quasi est quidem magnam voluptate ipsam eos\ntempora quo necessitatibus\ndolor quam autem quasi\nreiciendis et nam sapiente accusantium"
},

*/