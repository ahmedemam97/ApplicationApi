using Api.Helper;
using Application.Interfaces.Bookingss;
using Application.Interfaces.DailyExpensess;
using Domain.Dto;
using Domain.Entities.Bookings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Api.Controllers.BookingsS
{
    public class BookingsEP : IApiInterface
    {
        public void RegisterEndPoint(WebApplication app)
        {
            app.MapPost("/Bookings/Update", Update);
            app.MapPost("/Bookings/Create", Create);
            app.MapGet("/Bookings/GetAll", GetAll);
            app.MapDelete("/Bookings/Delete", Delete);
            app.MapGet("/Bookings/GetPageInfo", GetPageInfo);
        }
        //[Authorize]
        private async Task<IResult> Update(Bookings model, IBookingsService service) => Results.Ok(await service.Update(model));
        //[Authorize]
        private async Task<IResult> Create(Bookings model, IBookingsService service) => Results.Ok(await service.Create(model));
        //[Authorize]
        private async Task<IResult> GetAll(IBookingsService service) => Results.Ok(await service.GetAll());
        //[Authorize]
        private async Task<IResult> GetPageInfo(IBookingsService service) => Results.Ok(await service.GetPageInfo());
        //[Authorize]
        private async Task<IResult> Delete([FromQuery] int id, IBookingsService service) => Results.Ok(await service.Delete(id));

    }
}
