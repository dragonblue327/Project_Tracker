namespace ProjectTracker.Models
{
    public class TaskNotFoundException : Exception
    {
        public TaskNotFoundException() :base("Task was not found")
        {
                
        }
    }
}
