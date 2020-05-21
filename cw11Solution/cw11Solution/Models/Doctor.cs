using System.Collections.Generic;

namespace cw11Solution.Models
{
    public class Doctor
    {
        public Doctor()
        {
            Prescriptions = new HashSet<Prescription>();
        }

        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}