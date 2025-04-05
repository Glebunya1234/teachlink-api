namespace TeachLink_BackEnd.Core.Mappers.BaseMappers
{
    public interface IBaseMapper<TModel, TDto>
    {
        TModel ToModel(TDto dto);
        TDto ToDto(TModel model);

        IEnumerable<TModel> ToModelList(IEnumerable<TDto> dtoList);
        IEnumerable<TDto> ToDtoList(IEnumerable<TModel> modelList);
    }
}
