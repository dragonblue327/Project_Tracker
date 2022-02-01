using Microsoft.AspNetCore.Mvc;
using ProjectTracker.Models;
using Business.Models;

namespace ProjectTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        //to get all tasks 
        [HttpGet(Name = "Tasks")]
        public IEnumerable<Business.Models.Task> Get()
        {
                return GetTasks();
        }
        //this function to get tasks and select the name of projects from data base using join 
        private List<Business.Models.Task> GetTasks()
        {
            using (var context = new TrakerContext())
            {
                var tasks = (from Task in context.Task
                             join Project in context.Project on Task.ProjectId equals Project.ProjectId
                             select new Business.Models.Task
                             {
                                 TaskName = Task.TaskName,
                                 TaskDescription = Task.TaskDescription,
                                 TaskStatus = Task.TaskStatus,
                                 TaskPriority = Task.TaskPriority,
                                 ProjectName = Project.ProjectName,

                             }).ToList();
                return tasks;
            }
        }
        //get task by id 
        [HttpPost]
        [Route("/GetTaskById")]
        public Business.Models.Task Getbyid(int Id)
        {
            using (var context = new TrakerContext())
            {
                var Tasks_ = context.Task.Find(Id);
                if (Tasks_ == null)
                    throw new TaskNotFoundException() ;
                else
                    return Tasks_;
            }
        }
        //add new task
        [HttpPost]
        [Route("/AddTask")]
        public string Create(Business.Models.Task Tasks)
        {
            using (var context = new TrakerContext())
            {
                context.Task.Add(Tasks);
                context.SaveChanges();
                return "Task Added";
            }

        }
        //edit tasks 
        [HttpPost]
        [Route("/EditTasks")]
        public string Edit(Business.Models.Task Tasks, int id)
        {
            using (var context = new TrakerContext())
            {
                var Task_ = context.Task.Find(id);
                if (Task_ == null)
                    return "Task not found";
                else
                {
                    Task_.TaskName = Tasks.TaskName;
                    Task_.TaskDescription = Tasks.TaskDescription;
                    Task_.TaskStatus = Tasks.TaskStatus;
                    Task_.TaskPriority = Tasks.TaskPriority;
                    Task_.ProjectId = Tasks.ProjectId;
                    context.SaveChanges();
                    return "Task Updated";
                }

            }

        }
        //delete task
        [HttpPost]
        [Route("/DeleteTask")]
        public string Delete(int id)
        {
            using (var context = new TrakerContext())
            {
                var Task_ = context.Task.Find(id);
                if (Task_ == null)
                    return "Project not found";
                else
                {
                    context.Task.Remove(Task_);
                    context.SaveChanges();
                    return "Project was deleted";
                }
            }

        }

    }
}