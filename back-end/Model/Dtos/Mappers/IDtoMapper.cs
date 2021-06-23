using OpenOsp.Model.Models;

namespace OpenOsp.Model.Dtos.Mappers {
  public interface IDtoMapper<T, TCreateDto, TReadDto, TUpdateDto> {
    TCreateDto MapCreate(T entity);
    T ReverseMapCreate(TCreateDto entity);
    TReadDto MapRead(T entity);
    T ReverseMapRead(TReadDto entity);
    TUpdateDto MapUpdate(T entity);
    T ReverseMapUpdate(TUpdateDto entity);
  }
}