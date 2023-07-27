using EmployeeManagement.Model;

namespace EmployeeManagement.RespoanceClasses
{
    public class EmployeeResp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public List<Skill>? Skills { get; set; }

    }
}
