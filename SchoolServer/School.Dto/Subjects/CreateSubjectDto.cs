using System.ComponentModel.DataAnnotations;

namespace School.Dto.Subjects
{
    public class CreateSubjectDto
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = null!;

        public int MaxPerWeek { get; set; }
    }
}
