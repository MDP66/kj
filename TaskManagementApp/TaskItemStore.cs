
using TaskManagementApp.Models;

namespace TaskItemManagementApp;
public class TaskItemStore
{
    private readonly List<TaskItem> _taskItems;
    private static int _nextId = 0;
    // private static TaskItemStore _instance = null;
    // private static object _mutex = new object();

    // public static TaskItemStore GetInstances()
    // {
    //     if(_instance == null)
    //     {
    //         lock(_mutex){
    //             if(_instance == null){
    //                 _instance = new TaskItemStore();
    //             }
    //         }
    //     }
    //     return _instance;
    // }


    public TaskItemStore()
    {
        _taskItems = new List<TaskItem>();
    }

    public static int GetAutoIncremental()
    {
        ++_nextId;
        return _nextId;
    }


    public List<TaskItem> GetAll() => _taskItems;

    public TaskItem? Get(int id) => _taskItems.SingleOrDefault(t => t.Id == id);

    public TaskItem Add(AddTaskItem pTaskItem)
    {
        var taskItem = pTaskItem.GetTaskItem();
        _taskItems.Add(taskItem);
        return taskItem;
    }

    public void Update(TaskItem updatedTaskItem)
    {
        var existingTaskItem = _taskItems.SingleOrDefault(t => t.Id == updatedTaskItem.Id);
        if (existingTaskItem != null)
        {
            existingTaskItem.Title = updatedTaskItem.Title;
            existingTaskItem.Description = updatedTaskItem.Description;
            existingTaskItem.DueDate = updatedTaskItem.DueDate;
            existingTaskItem.IsCompleted = updatedTaskItem.IsCompleted;
        }
    }

    public void Delete(int id)
    {
        var taskItem = _taskItems.SingleOrDefault(t => t.Id == id);
        if (taskItem != null){
            _taskItems.Remove(taskItem);
        }
    }
}
