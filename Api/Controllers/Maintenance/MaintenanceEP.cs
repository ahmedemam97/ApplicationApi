using Api.Helper;
using Application.Interfaces.DailyExpensess;
using Application.Interfaces.Maintenances;
using Domain.Entities.DailyExpenses;
using Domain.Entities.Maintenance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Api.Controllers.MaintenanceS
{
    public class MaintenanceEP : IApiInterface
    {
        public void RegisterEndPoint(WebApplication app)
        {
            app.MapPost("/Maintenance/Update", Update);
            app.MapPost("/Maintenance/Create", Create);
            app.MapGet("/Maintenance/GetAll", GetAll);
            app.MapDelete("/Maintenance/Delete", Delete);
        }
        //[Authorize]
        private async Task<IResult> Update(Maintenance model, IMaintenanceService service) => Results.Ok(await service.Update(model));
        //[Authorize]
        private async Task<IResult> Create(Maintenance model, IMaintenanceService service) => Results.Ok(await service.Create(model));
        //[Authorize]
        private async Task<IResult> GetAll(IMaintenanceService service) => Results.Ok(await service.GetAll());
        //[Authorize]
        private async Task<IResult> Delete([FromQuery] int id, IMaintenanceService service) => Results.Ok(await service.Delete(id));
    }
}
