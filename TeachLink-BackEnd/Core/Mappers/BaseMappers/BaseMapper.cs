namespace TeachLink_BackEnd.Core.Mappers.BaseMappers
{
    public abstract class BaseMapper<TModel, TDto> : IBaseMapper<TModel, TDto>
    {
        public abstract TModel ToModel(TDto dto);
        public abstract TDto ToDto(TModel model);

        public virtual IEnumerable<TModel> ToModelList(IEnumerable<TDto> dtoList) =>
            dtoList.Select(ToModel);

        public virtual IEnumerable<TDto> ToDtoList(IEnumerable<TModel> modelList) =>
            modelList.Select(ToDto);
    }
}
