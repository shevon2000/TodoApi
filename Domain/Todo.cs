using System;

namespace Domain;

public class Todo
{
    public Guid Id { get; set; }    
    public required string Title { get; set; }   
    public required string Description { get; set; }
    public bool IsCompleted { get; set; }    
    public DateTime CreatedDate { get; set; }
}
