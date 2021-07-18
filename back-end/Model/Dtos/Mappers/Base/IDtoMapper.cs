namespace OpenOsp.Model.Dtos.Mappers {
  public interface IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto>
    where T : class
    where TCreateDto : class
    where TReadDto : class
    where TUpdateDto : class {
    T MapCreate(TCreateDto dto);

    TReadDto MapRead(T entity);

    T MapUpdate(TUpdateDto dto, T entity);

    TUpdateDto MapPatch(T entity);
  }
}