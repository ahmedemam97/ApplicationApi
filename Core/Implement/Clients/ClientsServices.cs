
using Application.Interfaces;
using Application.Interfaces.Clientss;
using AutoMapper;
using Domain.Dto;
using Domain.Entities.Bookings;
using Domain.Entities.Clients;
using Domain.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SignalRSwaggerGen.Attributes;

namespace Application.Implement.Clientss
{
    [SignalRHub]
    public class ClientsServices : Hub, IClientsServices
    {
        private readonly IHubContext<ClientsServices> HubContext;
        private readonly IUnitOfWork UnitOFWork;
        private IMapper _mapper;
        private JwtHelper _jwtHelper;
        private string Id;
        private string Name;
        public ClientsServices(
            IUnitOfWork unitOfWork,
            JwtHelper jwtHelper,
             IMapper mapper,
            IStringLocalizer<ClientsServices> localizer, IHubContext<ClientsServices> hubContext)
        {
            UnitOFWork = unitOfWork;
            HubContext = hubContext;
            _mapper = mapper;
            _jwtHelper = jwtHelper;
            Id = _jwtHelper.ReadTokenClaim(TokenClaimType.Id);
            Name = _jwtHelper.ReadTokenClaim(TokenClaimType.UserName);
        }
        [Authorize]
        [HubMethodName("AddClient")]
        public async Task<ResponseResult> Create(Clients model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Send Null" };

            if (model.Name == null || model.Name == "")
                return new ResponseResult { IsSuccess = false, Message = "ادخل اسم العميل" };


            model.CreatedById = Id;
            model.CreatedByName = Name;

            await UnitOFWork.Repository<Clients>().AddAsync(model);
            await UnitOFWork.CompleteAsync();
            await HubContext.Clients.All.SendAsync("AddClient", new { Name  = "Ahmed" });

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Add Success",
                Obj = model
            };
        }
        [HubMethodName("DeleteClient")]
        public async Task<ResponseResult> Delete(int id)
        {
            if (id <= 0)
                return new ResponseResult { IsSuccess = false, Message = "Id Required" };

            var modelExist = await UnitOFWork.Repository<Clients>().
                           Where(e => e.Id == id).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };


            var Bookings = await UnitOFWork.Repository<Bookings>().
                          Where(e => e.ClientId == modelExist.Id).FirstOrDefaultAsync();
            if (Bookings == null)
                return new ResponseResult { IsSuccess = false, Message = "لا يمكن حذف العميل هناك رحله" };


            var i = await UnitOFWork.Repository<Clients>().DeleteAsync(modelExist.Id);
            await UnitOFWork.CompleteAsync();
            await HubContext.Clients.All.SendAsync("DeleteClient", new { Name = "Ahmed" });

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Delete Success",
                Obj = modelExist.Id
            };
        }
        [Authorize]
        public async Task<ResponseResult> GetAll()
        {
            var All = await UnitOFWork.Repository<Clients>().ToListAsync();
            if (All == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };
            return new ResponseResult { IsSuccess = true, Message = "none", Obj = All };
        }
        [HubMethodName("UpdateClient")]
        public async Task<ResponseResult> Update(Clients model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Send Null" };

            if (model.Id <= 0)
                return new ResponseResult { IsSuccess = false, Message = "Id Required" };

            if (model.Name == null || model.Name == "")
                return new ResponseResult { IsSuccess = false, Message = "ادخل اسم العميل" };

            var modelExist = await UnitOFWork.Repository<Clients>().
                Where(e => e.Id == model.Id).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };

            model.LastModifiedDate = DateTime.Now;
            model.ModifyById = Id;
            model.ModifyByName = Name;
            model.ModifyCount = modelExist.ModifyCount + 1;

            var MapModel = _mapper.Map(model, modelExist);
            var i = await UnitOFWork.Repository<Clients>().UpdateAsync(MapModel);
            await UnitOFWork.CompleteAsync();
            await HubContext.Clients.All.SendAsync("UpdateClient", new { Name = "Ahmed" });

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Update Success",
                Obj = model
            };
        }
    }
}
