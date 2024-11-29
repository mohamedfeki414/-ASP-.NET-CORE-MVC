using System.ComponentModel.DataAnnotations;

namespace examen_pf.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom du patient est requis.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "L'adresse du patient est requise.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Le numéro de téléphone du patient est requis.")]
        public required string Phone { get; set; }

       

        // Relation avec Prescription
        public virtual ICollection<Prescription>? Prescriptions { get; set; }
    }
}
