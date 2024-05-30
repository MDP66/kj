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
        return Ok(_taskItemStore.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Response<TaskItem>> GetTask(int id)
    {
        var task = _taskItemStore.Get(id);
        if (task == null)
        {
            return NotFound("Please Enter Valid Id.");
        }
        return Ok(task);
    }

    [HttpPost]
    public ActionResult<TaskItem> PostTask(AddTaskItem task)
    {
        return Ok(_taskItemStore.Add(task));
    }

    [HttpPut]
    public IActionResult PutTask(TaskItem task)
    {
        if (task.Id == 0)
        {
            return BadRequest();
        }

        var existingTask = _taskItemStore.Get(task.Id);
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
        _taskItemStore.Delete(id);
        return Ok("Task Delete Successfully.");
    }
}
