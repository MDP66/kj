using Microsoft.AspNetCore.Mvc;
using TaskItemManagementApp;
using TaskManagementApp.Models;

namespace TaskManagementApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly TaskItemStore _taskItemStore;

    public TasksController(TaskItemStore taskStore)
    {
        _taskItemStore = taskStore;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TaskItem>> GetTasks()
    {
        return _taskItemStore.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<TaskItem> GetTask(int id)
    {
        var task = _taskItemStore.Get(id);
        if (task == null)
        {
            return NotFound();
        }
        return task;
    }

    [HttpPost]
    public ActionResult<Task> PostTask(TaskItem task)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id}")]
    public IActionResult PutTask(int id, TaskItem task)
    {
        if (id != task.Id)
        {
            return BadRequest();
        }

        var existingTask = _taskItemStore.Get(id);
        if (existingTask == null)
        {
            return NotFound();
        }

        _taskItemStore.Update(task);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
      throw new NotImplementedException();
    }
}
