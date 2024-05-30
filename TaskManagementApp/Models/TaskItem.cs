using TaskItemManagementApp;

namespace TaskManagementApp.Models;
public class TaskItem : AddTaskItem
{
    public TaskItem()
    {
        Id = TaskItemStore.GetAutoIncremental();
    }
    public int Id { get; private set;  }
}

public class AddTaskItem 
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsCompleted { get; set; }
    public TaskItem GetTaskItem()
    {
        return new TaskItem() { Title = this.Title
            , Description = this.Description
            , DueDate = this.DueDate
            , IsCompleted = this.IsCompleted };
    }
}
