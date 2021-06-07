using System.ComponentModel.DataAnnotations;

namespace School.Dto.Cabinetes
{
    public class CreateCabineteDto
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = null!;

    }
}
