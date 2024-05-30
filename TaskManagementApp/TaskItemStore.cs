
using TaskManagementApp.Models;

namespace TaskItemManagementApp;
public class TaskItemStore
{
    private readonly List<TaskItem> _TaskItems = new();
    private int _nextId = 1;
    public TaskItemStore()
    {
        _TaskItems.Add(new TaskItem
        {
            Id = ++_nextId,
            Title = "Sample",
            Description = "Description",
            IsCompleted = false,
            DueDate = DateTime.Now.AddMinutes(2),
        });
    }
    public List<TaskItem> GetAll() => _TaskItems;

    public TaskItem Get(int id) => _TaskItems.FirstOrDefault(t => t.Id == id);

    public TaskItem Add(TaskItem TaskItem)
    {
        TaskItem.Id = _nextId++;
        _TaskItems.Add(TaskItem);
        return TaskItem;
    }

    public void Update(TaskItem updatedTaskItem)
    {
        var existingTaskItem = _TaskItems.FirstOrDefault(t => t.Id == updatedTaskItem.Id);
        if (existingTaskItem != null)
        {
            existingTaskItem.Title = updatedTaskItem.Title;
            existingTaskItem.Description = updatedTaskItem.Description;
            existingTaskItem.DueDate = updatedTaskItem.DueDate;
            existingTaskItem.IsCompleted = updatedTaskItem.IsCompleted;
        }
    }

    public void Delete(int id) => _TaskItems.RemoveAll(t => t.Id == id);
}
