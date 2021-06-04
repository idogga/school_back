namespace School.BL.Studying
{

    using School.Abstract;
    using School.Database;
    using School.Dto;

    /// <summary>
    /// Маппер для <see cref="Subject"/>.
    /// </summary>
    public class SubjectMapper : MapperService<SubjectDto, Subject>
    {
        /// <inheritdoc/>
        public override SubjectDto ConvertToDto(Subject model)
        {
            return new SubjectDto
            {
                Id = model.Id,
                Name = model.Name,
                MaxPerWeek = model.MaxPerWeek
            };
        }

        /// <inheritdoc/>
        public override Subject ConvertToModel(SubjectDto dto)
        {
            return new Subject(dto.Name)
            {
                Id = dto.Id,
                MaxPerWeek = dto.MaxPerWeek
            };
        }
    }
}