namespace taskify.Models;

public class TodoModel
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }

    public required string Description { get; set; }

    public required bool IsDone { get; set; }

}