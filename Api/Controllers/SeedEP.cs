using Api.Helper;
using Application;
using Application.Interfaces;
using Domain.Dto;

namespace Api.Controllers
{
    public class SeedEP : IApiInterface
    {
        public void RegisterEndPoint(WebApplication app)
        {
            app.MapGet("/Seed/Get", Get);
        }
        private async Task<IResult> Get(IUnitOfWork UnitOfWork,IConfiguration configuration)
        {
            //var ret = await new DefaultData(configuration.GetSection("ConnectionStrings").Value).Seed();

            return  Results.Ok(new ResponseResult { IsSuccess = true, Message = "Seed Success" });
        }


    }
}
