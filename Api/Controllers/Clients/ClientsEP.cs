using Api.Helper;
using Application.Interfaces.Clientss;
using Domain.Entities.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignalRSwaggerGen.Attributes;

namespace Api.Controllers.ClientsS
{
    [SignalRHub]
    public class ClientsEP : IApiInterface
    {
        public void RegisterEndPoint(WebApplication app)
        {
            app.MapPost("/Clients/Update", Update);
            app.MapPost("/Clients/Create", Create);
            app.MapGet("/Clients/GetAll", GetAll);
            app.MapDelete("/Clients/Delete", Delete);
        }
        //[Authorize]
        private async Task<IResult> Update(Clients model, IClientsServices service) => Results.Ok(await service.Update(model));
        //[Authorize]
        private async Task<IResult> Create(Clients model, IClientsServices service) => Results.Ok(await service.Create(model));
        //[Authorize]
        private async Task<IResult> GetAll(IClientsServices service) => Results.Ok(await service.GetAll());
        //[Authorize]
        private async Task<IResult> Delete([FromQuery] int id, IClientsServices service) => Results.Ok(await service.Delete(id));
    }
}
