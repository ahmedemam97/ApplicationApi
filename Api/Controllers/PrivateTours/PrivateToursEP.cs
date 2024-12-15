using Api.Helper;
using Application.Interfaces.Citys;
using Application.Interfaces.PrivateTourss;
using Domain.Entities.City;
using Domain.Entities.PrivateTours;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Api.Controllers.PrivateToursS
{
    public class PrivateToursEP : IApiInterface
    {
        public void RegisterEndPoint(WebApplication app)
        {
            app.MapPost("/PrivateTours/Update", Update);
            app.MapPost("/PrivateTours/Create", Create);
            app.MapGet("/PrivateTours/GetAll", GetAll);
            app.MapDelete("/PrivateTours/Delete", Delete);
        }
        //[Authorize]
        private async Task<IResult> Update(PrivateTours model, IPrivateToursService service) => Results.Ok(await service.Update(model));
        //[Authorize]
        private async Task<IResult> Create(PrivateTours model, IPrivateToursService service) => Results.Ok(await service.Create(model));
        //[Authorize]
        private async Task<IResult> GetAll(IPrivateToursService service) => Results.Ok(await service.GetAll());
        //[Authorize]
        private async Task<IResult> Delete([FromQuery] int id, IPrivateToursService service) => Results.Ok(await service.Delete(id));
    }
}
