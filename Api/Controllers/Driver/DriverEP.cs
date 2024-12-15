using Api.Helper;
using Application.Interfaces.Companys;
using Application.Interfaces.Drivers;
using Domain.Entities.Company;
using Domain.Entities.Driver;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Api.Controllers.DriverS
{
    public class DriverEP : IApiInterface
    {
        public void RegisterEndPoint(WebApplication app)
        {
            app.MapPost("/Driver/Update", Update);
            app.MapPost("/Driver/Create", Create);
            app.MapGet("/Driver/GetAll", GetAll);
            app.MapDelete("/Driver/Delete", Delete);
        }
        //[Authorize]
        private async Task<IResult> Update(Driver model, IDriverService service) => Results.Ok(await service.Update(model));
        //[Authorize]
        private async Task<IResult> Create(Driver model, IDriverService service) => Results.Ok(await service.Create(model));
        //[Authorize]
        private async Task<IResult> GetAll(IDriverService service) => Results.Ok(await service.GetAll());
        //[Authorize]
        private async Task<IResult> Delete([FromQuery] int id, IDriverService service) => Results.Ok(await service.Delete(id));
    }
}
