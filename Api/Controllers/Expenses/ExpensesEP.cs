using Api.Helper;
using Application.Interfaces.DailyRevenues;
using Application.Interfaces.Expensess;
using Domain.Dto;
using Domain.Entities.DailyRevenue;
using Domain.Entities.Expenses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ExpensesS
{
    public class ExpensesEP : IApiInterface
    {
        public void RegisterEndPoint(WebApplication app)
        {
            app.MapPost("/Expenses/Update", Update);
            app.MapPost("/Expenses/Create", Create);
            app.MapGet("/Expenses/GetAll", GetAll);
            app.MapDelete("/Expenses/Delete", Delete);
            app.MapGet("/Expenses/ExpensesSearchInfo", ExpensesSearchInfo);
            app.MapPost("/Expenses/ExpensesSearch", ExpensesSearch);

        }
        //[Authorize]
        private async Task<IResult> Update(Expenses model, IExpensesService service) => Results.Ok(await service.Update(model));
        //[Authorize]
        private async Task<IResult> Create(Expenses model, IExpensesService service) => Results.Ok(await service.Create(model));
        //[Authorize]
        private async Task<IResult> ExpensesSearch(SearchDto model, IExpensesService service) => Results.Ok(await service.ExpensesSearch(model));
        //[Authorize]
        private async Task<IResult> GetAll(IExpensesService service) => Results.Ok(await service.GetAll());
        //[Authorize]
        private async Task<IResult> ExpensesSearchInfo(IExpensesService service) => Results.Ok(await service.ExpensesSearchInfo());
        //[Authorize]
        private async Task<IResult> Delete([FromQuery] int id, IExpensesService service) => Results.Ok(await service.Delete(id));
    }
}
