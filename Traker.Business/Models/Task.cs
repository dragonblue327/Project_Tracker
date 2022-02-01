using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models
{
    [Table("Tasks", Schema= "dbo")]
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name= "Task ID")]
        public int TaskId { get; set; }


        [Required]
        [Column(TypeName ="varchar(MAX)")]
        [Display(Name = "Task Name")]
        public string TaskName { get; set; }

        [Required]
        [Column(TypeName = "Varchar(MAX)")]
        [Display(Name = "Task Description")]
        public string TaskDescription { get; set; }


        [Required]
        [Display(Name = "Task Status ")]
        public Business.Models.TaskStatus TaskStatus { get; set; }
        

        [Required]
        [Display(Name = "Task Priority")]
        public int TaskPriority { get; set; }

        [ForeignKey("Project ID")]
        [Required]
        public int ProjectId { get; set; }
        [Display(Name = "Project Name")]
        [NotMapped]
        public string ProjectName { get; set; }
    }
}
