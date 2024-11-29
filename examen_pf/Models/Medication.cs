
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace examen_pf.Models
{
    public class Medication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Dosage { get; set; }

        // Clé étrangère
        public int PrescriptionId { get; set; }

        // Relation
        [ForeignKey("PrescriptionId")]
        public virtual Prescription? Prescription { get; set; }
    }
}