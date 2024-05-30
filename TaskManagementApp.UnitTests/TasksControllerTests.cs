using TaskItemManagementApp;
using TaskManagementApp.Controllers;
using System;
using Xunit.Sdk;
using Moq;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components.Web;
using System.Collections;

namespace TaskManagementApp.UnitTests
{
    public class TasksControllerTests
    {
        private readonly TaskItemStore _taskItemStore;

        public TasksControllerTests()
        {
            _taskItemStore = new TaskItemStore();
        }

        [Fact]
        public void GetAll()
        {
            var taskController = new TasksController(_taskItemStore);

            taskController.PostTask(new AddTaskItem(){
                Title = "Abhishek",
                Description = "Check Is Added",
                IsCompleted = true,
                DueDate = DateTime.Now
            });

            var result = taskController.GetTasks();
            // Console.WriteLine((result.Result as OkObjectResult).Value);
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<ActionResult<IEnumerable<TaskItem>>>(result);
            var resultTask = (result.Result as OkObjectResult).Value as IEnumerable<TaskItem>;
            Assert.NotEqual(0, resultTask.Count());
        }

        [Theory]
        [ClassData(typeof(PostTestTaskItemData))]
        public void PostAllData(string title, string description, DateTime dueDate, bool isCompleted)
        {
            var taskController = new TasksController(_taskItemStore);

            var result = taskController.PostTask(new AddTaskItem(){
                Title = title,
                Description = description,
                IsCompleted = isCompleted,
                DueDate = dueDate
            });

            Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<ActionResult<TaskItem>>(result);
            var resultTask = (result.Result as OkObjectResult).Value as TaskItem;

            Assert.IsType<TaskItem>(resultTask);
            Assert.Equal(title, resultTask.Title);
            Assert.Equal(description, resultTask.Description);
            Assert.Equal(dueDate, resultTask.DueDate);
            Assert.Equal(isCompleted, resultTask.IsCompleted);
        }

        [Fact]
        public void DeleteData()
        {
            var taskController = new TasksController(_taskItemStore);

            taskController.PostTask(new AddTaskItem(){
                Title = "Abhishek",
                Description = "Check Is Added",
                IsCompleted = true,
                DueDate = DateTime.Now
            });

            var result = taskController.DeleteTask(1);
            Assert.IsType<OkObjectResult>(result);
        }

    }

    public class PostTestTaskItemData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "Hello", "DES 1", DateTime.Now, true };
            yield return new object[] { "Hello World", "DES 2", DateTime.Now, true };
            yield return new object[] { "New world", "DES 3", DateTime.Now, true };
            yield return new object[] { "Nao World", "DES 4", DateTime.Now, true };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}