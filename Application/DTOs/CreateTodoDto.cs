using System;

namespace Application.DTOs;

public class CreateTodoDto
{
    public required string Title { get; set; }
    public required string Description { get; set; }
}
