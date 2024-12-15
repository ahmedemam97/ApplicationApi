using Api.Helper;
using Application.Interfaces.Citys;
using Application.Interfaces.Companys;
using Domain.Entities.City;
using Domain.Entities.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.CityS
{
    public class CityEP : IApiInterface
    {
        public void RegisterEndPoint(WebApplication app)
        {
            app.MapPost("/City/Update", Update);
            app.MapPost("/City/Create", Create);
            app.MapGet("/City/GetAll", GetAll);
            app.MapDelete("/City/Delete", Delete);
        }
        //[Authorize]
        private async Task<IResult> Update(City model, ICityServices service) => Results.Ok(await service.Update(model));
        //[Authorize]
        private async Task<IResult> Create(City model, ICityServices service) => Results.Ok(await service.Create(model));
        //[Authorize]
        private async Task<IResult> GetAll(ICityServices service) => Results.Ok(await service.GetAll());
        //[Authorize]
        private async Task<IResult> Delete([FromQuery] int id, ICityServices service) => Results.Ok(await service.Delete(id));
    }
}
