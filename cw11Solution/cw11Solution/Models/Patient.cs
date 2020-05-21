using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11Solution.Models
{
    public class Patient
    {

        public Patient()
        {
            Prescription = new HashSet<Prescription>();
        }
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }


        public virtual ICollection<Prescription> Prescription { get; set; }
    }
}
