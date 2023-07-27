using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EmployeeManagement.Model
{
    public class Employee
    {
        public int Id { get; set; }

        [StringLength(30, ErrorMessage = "Name should be maximum 30 length.")]
        [Required(ErrorMessage = "Please Enter Employee Name.")]
        [RegularExpression(pattern: "[a-zA-Z ]*$", ErrorMessage = "Please enter only alphabets.")]
        public string Name { get; set; }

        public string Gender { get; set; }

        [StringLength(10, ErrorMessage = "ContactNumber should be maximum 10 length.")]
        public string ContactNumber { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        // Navigation property for the one-to-many relationship
        public virtual List<Skill>? Skills { get; set; }
    }
}
