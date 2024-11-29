using System.ComponentModel.DataAnnotations;

namespace examen_pf.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Password { get; set; }

        // Clé étrangère
        public int PharmacistId { get; set; }

        // Relation
        public virtual Pharmacist? Pharmacist { get; set; }
    }
}
