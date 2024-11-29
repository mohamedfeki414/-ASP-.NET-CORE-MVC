using System.ComponentModel.DataAnnotations;

namespace examen_pf.Models
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        // Clés étrangères
        public int  PharmacistId { get; set; }
        public int PatientId { get; set; }

        // Relations
        public virtual  Pharmacist? Pharmacist { get; set; }
        public virtual  Patient? Patient { get; set; }
        public virtual ICollection<Medication>? Medications { get; set; }
    }
}
