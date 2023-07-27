using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Model
{
    public class Skill
    {

        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Skill Name.")]
        public string SkillName { get; set; }

        [Required(ErrorMessage = "Please Select Skill Experience.")]
        public int SkillExperience { get; set; }

        // Foreign key for the one-to-many relationship
        public int EmployeeId { get; set; } 
    }
}
