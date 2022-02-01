namespace ProjectTracker.Models
{
    public class ProjectNotFoundException : Exception
    {
        public ProjectNotFoundException() :base("Project was not found")
        {
                
        }
    }
}
