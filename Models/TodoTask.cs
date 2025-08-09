using System.ComponentModel.DataAnnotations;

namespace api_test.Models;

public class TodoTask
{
    public Guid Id { get; init; }
    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 100 characters")]

    public string Title { get; set; }

    public bool IsDone { get; set; } = false;

    public void setIsDone(bool isDone)
    {
        IsDone = isDone;
    }
}