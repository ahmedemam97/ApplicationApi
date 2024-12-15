using Domain.Dto;

using Api.Helper;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities.Expened;
using Application.Interfaces.Expeneds;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Api.Controllers.Expeneds
{
    public class ExpenedEP : IApiInterface
    {
        public void RegisterEndPoint(WebApplication app)
        {

            app.MapGet("/Expened/GetAll", GetAll);
            app.MapPost("/Expened/Create", Create);
            app.MapPost("/Expened/Update", Update);

        }
        private async Task<IResult> GetAll(IExpenedService service) => Results.Ok(await service.GetAll());
        private async Task<IResult> Create(Expened model, IExpenedService service) => Results.Ok(await service.Create(model));
        private async Task<IResult> Update(Expened model, IExpenedService service) => Results.Ok(await service.Update(model));

    }
}
