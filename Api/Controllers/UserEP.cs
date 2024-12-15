using Api.Helper;
using Application.Interfaces.User;
using Domain.Dto.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    public class UserEP : IApiInterface
    {
        public void RegisterEndPoint(WebApplication app)
        {
            app.MapPost("/User/Register", Register);
            app.MapPost("/User/Login", Login);
            app.MapGet("/User/GetAll", GetAll);
            app.MapGet("/User/GetById", GetById);
            app.MapDelete("/User/Delete", Delete);
        }
        [AllowAnonymous]
        private async Task<IResult> Register(UserDto model, IUserService service) => Results.Ok(await service.Register(model));
        [AllowAnonymous]
        private async Task<IResult> Login(UserLoginDto model, IUserService service) => Results.Ok(await service.Login(model));
        [AllowAnonymous]
        private async Task<IResult> GetAll(IUserService service) => Results.Ok(await service.GetAll());
        [AllowAnonymous]
        private async Task<IResult> GetById([FromQuery] string id  ,IUserService service) => Results.Ok(await service.GetById(id));
        [AllowAnonymous]
        private async Task<IResult> Delete([FromQuery] string id, IUserService service) => Results.Ok(await service.Delete(id));
    }
}
