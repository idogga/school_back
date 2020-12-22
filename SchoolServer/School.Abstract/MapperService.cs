namespace School.Abstract
{
    public abstract class MapperService<TDto, TModel>
    {
        public abstract TDto ConvertToDto(TModel model);

        public abstract TModel ConvertToModel(TDto dto);
    }
}