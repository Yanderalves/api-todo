namespace api_test.Models;

public class RequestTask
{
    public string Description { get; set; }
    
    public string Title { get; set; }
    public bool IsDone { get; set; }
    
    public RequestTask(string description, string title)
    {
        Description = description;
        Title = title;
        IsDone = false;
    }
}