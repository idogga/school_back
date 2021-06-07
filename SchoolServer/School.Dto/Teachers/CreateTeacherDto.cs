using System.ComponentModel.DataAnnotations;

namespace School.Dto.Teachers
{
    public class CreateTeacherDto
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = null!;
    }
}
