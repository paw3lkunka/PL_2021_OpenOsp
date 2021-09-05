using OpenOsp.Model.Models;

namespace OpenOsp.Model.Dtos.Mappers {

  public interface IUserDtoMapper {

    public User MapRegister(UserRegisterDto dto);

  }

}