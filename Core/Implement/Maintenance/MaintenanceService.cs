using Application.Implement.DailyRevenues;
using Application.Interfaces;
using Application.Interfaces.Maintenances;
using AutoMapper;
using Domain.Dto;
using Domain.Entities.DailyRevenue;
using Domain.Entities.Maintenance;
using Domain.Helper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implement.Maintenances
{
    public class MaintenanceService:Hub, IMaintenanceService
    {
        private readonly IHubContext<MaintenanceService> HubContext;
        private readonly IUnitOfWork UnitOFWork;
        private IMapper _mapper;

        public MaintenanceService(
            IUnitOfWork unitOfWork,
            JwtHelper jwtHelper,
             IMapper mapper,
            IStringLocalizer<MaintenanceService> localizer, IHubContext<MaintenanceService> hubContext)
        {
            UnitOFWork = unitOfWork;
            HubContext = hubContext;
            _mapper = mapper;
        }

        public async Task<ResponseResult> Create(Maintenance model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Send Null" };


            await UnitOFWork.Repository<Maintenance>().AddAsync(model);
            await UnitOFWork.CompleteAsync();

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Add Success",
                Obj = model
            };
        }
        public async Task<ResponseResult> Delete(int id)
        {
            if (id <= 0)
                return new ResponseResult { IsSuccess = false, Message = "Id Required" };


            var modelExist = await UnitOFWork.Repository<Maintenance>().
               Where(e => e.Id == id).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };


            var i = await UnitOFWork.Repository<Maintenance>().DeleteAsync(modelExist.Id);
            await UnitOFWork.CompleteAsync();

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Delete Success",
                Obj = modelExist.Id
            };



        }
        public async Task<ResponseResult> GetAll()
        {
            var All = await UnitOFWork.Repository<Maintenance>().ToListAsync();
            if (All == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };
            return new ResponseResult { IsSuccess = true, Message = "none", Obj = All };
        }
        public async Task<ResponseResult> Update(Maintenance model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Send Null" };

            if (model.Id <= 0)
                return new ResponseResult { IsSuccess = false, Message = "Id Required" };

            var modelExist = await UnitOFWork.Repository<Maintenance>().
                Where(e => e.Id == model.Id).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };

            var MapModel = _mapper.Map(model, modelExist);
            var i = await UnitOFWork.Repository<Maintenance>().UpdateAsync(MapModel);
            await UnitOFWork.CompleteAsync();

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Update Success",
                Obj = model
            };
        }
    }
}
