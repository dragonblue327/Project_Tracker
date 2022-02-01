using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Business.Models
{
    [Table("Projects", Schema = "dbo")]
    public class Project
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Project ID")]
        public int ProjectId { get; set; }

        [Required]
        [Column(TypeName = "Varchar(MAX)")]
        [MaxLength(150)]
        [Display(Name = "Project Name")]
        public string ProjectName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "project start date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yy}")]
        public DateTime ProjectStartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "project completion date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yy}")]
        public DateTime ProjectCompletionDate { get; set; }


        [Required]
        [Display(Name = "Project Status ")]
        public ProjectStatus ProjectStatus { get; set; }



        [Required]
        [Display(Name = "Project Priority")]
        public int ProjectPriority { get; set; }

    }
}
