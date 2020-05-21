namespace cw11Solution.Models
{
    public class Prescription_Medicament
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public int? Dose { get; set; }
        public string Details { get; set; }

        public virtual Prescription Prescription { get; set;}
        public virtual Medicament Medicament { get; set; }
    }
}