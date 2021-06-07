using System;
using System.Collections.Generic;

namespace School.Dto
{
    public class TeacherDto : BaseDto
    {
        public TeacherDto(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public IList<Guid> Subjects { get; set; } = new List<Guid>();
    }
}