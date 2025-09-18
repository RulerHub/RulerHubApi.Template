namespace RulerHub.Application.Interfaces.Mappers;

public interface IMapper<TEntity, TEntityDto, TCreateDto, TUpdateDto>
{
    TEntityDto ToDto(TEntity entity);
    TEntity FromCreateDto(TCreateDto dto);
    void UpdateEntity(TEntity entity, TUpdateDto dto);
}
