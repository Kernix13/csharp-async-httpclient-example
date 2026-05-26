namespace BasicAsync;

// https://jsonplaceholder.typicode.com/todos

public class ToDo
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool Completed { get; set; }

    // no constructor needed - just deserializing data from an API (DTO)
}

/*

{
    "userId": 1,
    "id": 1,
    "title": "delectus aut autem",
    "completed": false
},

*/