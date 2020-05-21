using System.Collections.Generic;

namespace cw11Solution.Models
{
    public class Medicament
    {
        public Medicament()
        {
            PrescriptionMedicament = new HashSet<Prescription_Medicament>();
        }
        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Prescription_Medicament> PrescriptionMedicament { get; set; }
    }
}