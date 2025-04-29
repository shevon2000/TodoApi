using System;

namespace Application.DTOs;

public class UpdateTodoDto
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public bool IsCompleted { get; set; }
}
