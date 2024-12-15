using Api.Helper;
using Application.Interfaces.DailyExpensess;
using Domain.Dto;
using Domain.Entities.DailyExpenses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.DailyExpensess
{
    public class DailyExpensesEP : IApiInterface
    {
        public void RegisterEndPoint(WebApplication app)
        {
            app.MapGet("/DailyExpenses/GetPageInfo", GetPageInfo);
            app.MapPost("/DailyExpenses/Update", Update);
            app.MapPost("/DailyExpenses/Create", Create);
            app.MapGet("/DailyExpenses/GetAll", GetAll);
            app.MapDelete("/DailyExpenses/Delete", Delete);
        }
        //[Authorize]
        private async Task<IResult> Update(DailyExpensesDto model, IDailyExpensesService service) => Results.Ok(await service.Update(model));
        //[Authorize]
        private async Task<IResult> Create(DailyExpensesDto model, IDailyExpensesService service) => Results.Ok(await service.Create(model));
        //[Authorize]
        private async Task<IResult> GetAll(IDailyExpensesService service) => Results.Ok(await service.GetAll());
        //[Authorize]
        private async Task<IResult> GetPageInfo(IDailyExpensesService service) => Results.Ok(await service.GetPageInfo());
        //[Authorize]
        private async Task<IResult> Delete([FromQuery] int id, IDailyExpensesService service) => Results.Ok(await service.Delete(id));
    }
}
