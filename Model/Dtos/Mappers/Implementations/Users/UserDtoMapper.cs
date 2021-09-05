using OpenOsp.Model.Models;

namespace OpenOsp.Model.Dtos.Mappers {

  public class UserDtoMapper : IUserDtoMapper {

    public User MapRegister(UserRegisterDto dto) {
      return new User {
        UserName = dto.UserName,
        Email = dto.Email,
      };
    }

  }

}