﻿namespace School.BL.Pupil
{
    using System;

    using School.Abstract;
    using School.Database;
    using School.Dto;

    public class ClassMapper : MapperService<ClassDto, Class>
    {
        public override ClassDto ConvertToDto(Class model)
        {
            throw new NotImplementedException();
        }

        public override Class ConvertToModel(ClassDto dto)
        {
            throw new NotImplementedException();
        }
    }
}