using Api.Helper;
using Application.Interfaces.DriverExpensesS;
using Application.Interfaces.Drivers;
using Domain.Dto;
using Domain.Entities.Driver;
using Domain.Entities.DriverExpenses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Api.Controllers.DriverExpensesS
{
    public class DriverExpensesEP : IApiInterface
    {
        public void RegisterEndPoint(WebApplication app)
        {
            app.MapPost("/DriverExpenses/Update", Update);
            app.MapPost("/DriverExpenses/Create", Create);
            app.MapGet("/DriverExpenses/GetAll", GetAll);
            app.MapDelete("/DriverExpenses/Delete", Delete);
            app.MapPost("/DriverExpenses/DriverExpensesSearch", DriverExpensesSearch);
            app.MapGet("/DriverExpenses/GetPageInfo", GetPageInfo);
        }
        //[Authorize]
        private async Task<IResult> Update(DriverExpenses model, IDriverExpensesService service) => Results.Ok(await service.Update(model));
        //[Authorize]
        private async Task<IResult> Create(DriverExpenses model, IDriverExpensesService service) => Results.Ok(await service.Create(model));
        //[Authorize]
        private async Task<IResult> DriverExpensesSearch(DriverSearchDto model, IDriverExpensesService service) => Results.Ok(await service.DriverExpensesSearch(model));
        //[Authorize]
        private async Task<IResult> GetPageInfo(IDriverExpensesService service) => Results.Ok(await service.GetPageInfo());
        //[Authorize]
        private async Task<IResult> GetAll(IDriverExpensesService service) => Results.Ok(await service.GetAll());
        //[Authorize]
        private async Task<IResult> Delete([FromQuery] int id, IDriverExpensesService service) => Results.Ok(await service.Delete(id));
    }
}
