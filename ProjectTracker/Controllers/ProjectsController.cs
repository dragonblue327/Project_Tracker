using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Business.Models;
using ProjectTracker.Models;

namespace ProjectTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        public enum SortDirection
        {
            Ascending,
            Descending
        }
        // to get all projects
        [HttpGet(Name = "Projects")]
        public IEnumerable<Project> Get()
        {
            using (var context = new TrakerContext())
            {
                return context.Project.ToList();
            }

        }
        //to get project by id
        [HttpPost]
        [Route("/GetProjectId")]
        public Project Getbyid(int Id)
        {
            using (var context = new TrakerContext())
            {
                var projects_ = context.Project.Find(Id);
                if (projects_ == null)
                    throw new ProjectNotFoundException(); 
                else
                    return projects_;
            }
        }
        //to add new project
        [HttpPost]
        [Route("/AddProject")]
        public string Create(Project project)
        {
            using (var context = new TrakerContext())
            {
                if (project.ProjectStartDate > project.ProjectCompletionDate)
                    return "Check out Date";
                else
                {
                    context.Project.Add(project);
                    context.SaveChanges();
                    return "Project Added";
                }
            }

        }
        //to edit projects 
        [HttpPost]
        [Route("/EditProjects")]
        public string Edit(Project project, int id)
        {
            using (var context = new TrakerContext())
            {
                var projects_ = context.Project.Find(id);
                if (projects_ == null)
                    return "Project not found";
                else if (project.ProjectStartDate > project.ProjectCompletionDate)
                        return "Check out Date";
                else
                {
                    projects_.ProjectName = project.ProjectName;
                    projects_.ProjectStartDate = project.ProjectStartDate;
                    projects_.ProjectCompletionDate = project.ProjectCompletionDate;
                    projects_.ProjectStatus = project.ProjectStatus;
                    projects_.ProjectPriority = project.ProjectPriority;
                    context.SaveChanges();
                    return "Project Updated";
                }

            }

        }
        //to delete projects
        [HttpPost]
        [Route("/DeleteProjects")]
        public string Delete(int id)
        {
            using (var context = new TrakerContext())
            {
                Project project = context.Project.Find(id);
                if (project == null)
                    return "Project not found";
                else
                {
                    context.Project.Remove(project);
                    context.SaveChanges();
                    return "Project was deleted";
                }
            }

        }

    }
}
