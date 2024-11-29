using System.ComponentModel.DataAnnotations;

namespace examen_pf.Models
{
    public class Pharmacist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        

        // Relation avec Account
        public virtual Account? Account { get; set; }
    }
}
