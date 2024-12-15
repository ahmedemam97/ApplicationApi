using Domain.Dto;
using Domain.Dto.User;

namespace Application.Interfaces.User
{
    public interface IUserService
    {
        Task<ResponseResult> GetAll();
        Task<ResponseResult> GetById(string id);
        Task<ResponseResult> Register(UserDto model);
        Task<ResponseResult> Login(UserLoginDto model);
        Task<ResponseResult> Delete(string id);
        Task<ResponseResult> Update(UserDto model);
    }
}
