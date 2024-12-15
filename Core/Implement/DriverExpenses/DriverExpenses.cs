using Application.Interfaces;
using Application.Interfaces.DriverExpensesS;
using AutoMapper;
using Domain.Dto;
using Domain.Entities.DailyExpenses;
using Domain.Entities.DailyRevenue;
using Domain.Entities.Driver;
using Domain.Entities.DriverExpenses;
using Domain.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implement.DriverExpensess
{
    public class DriverExpensesService : IDriverExpensesService
    {
        private readonly IUnitOfWork UnitOFWork;
        private IMapper _mapper;
        private JwtHelper _jwtHelper;
        private string Id;
        private string Name;
        public DriverExpensesService(
            IUnitOfWork unitOfWork,
            JwtHelper jwtHelper,
             IMapper mapper
            )
        {
            UnitOFWork = unitOfWork;
            _mapper = mapper;
            _jwtHelper = jwtHelper;
            Id = _jwtHelper.ReadTokenClaim(TokenClaimType.Id);
            Name = _jwtHelper.ReadTokenClaim(TokenClaimType.UserName);
        }
        public async Task<ResponseResult> GetPageInfo()
        {

            var DriverExpensesList = await UnitOFWork.Repository<DriverExpenses>().ToListAsync();
            if (DriverExpensesList == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };

            var DriverList = await UnitOFWork.Repository<Driver>().ToListAsync();
            if (DriverList == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };

            return new ResponseResult { IsSuccess = true, Message = "none", Obj = new {
                DriverExpensesList,
                DriverList
            } };

        }
        public async Task<ResponseResult> DriverExpensesSearch(DriverSearchDto searchDto)
        {
            var ExpensesList =  await UnitOFWork.Repository<ExpensesDetails>()
                .Where(e=>e.Date == searchDto.Date)
                .ToListAsync();

            var RevenueList = await UnitOFWork.Repository<RevenueDetails>()
               .Where(e => e.Date == searchDto.Date)
               .ToListAsync();

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "none",
                Obj = new
                {
                    ExpensesList,
                    RevenueList
                }
            };


        }
        public async Task<ResponseResult> Create(DriverExpenses model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Send Null" };

            if (model.DriverId <= 0)
                return new ResponseResult { IsSuccess = false, Message = "ادخل  السائق" };

            var Driver = await UnitOFWork.Repository<Driver>()
                  .Where(e => e.Id == model.DriverId).FirstOrDefaultAsync();
           if (Driver == null)
                return new ResponseResult { IsSuccess = false, Message = "السائق غير موجود " };

            if (model.Amount <= 0)
                return new ResponseResult { IsSuccess = false, Message = "ادخل حساب السائق" };

            model.CreatedById = Id;
            model.CreatedByName = Name;
            model.DriverName = Driver.Name;

            var DailyExpenses = new DailyExpenses();
            DailyExpenses.ExpensesDetails = new List<ExpensesDetails>();


            var ExpensesDriver = new ExpensesDetails()
            {
                Date = model.Date,
                Amount = model.Amount,
                CreatedById = Id,
                CreatedByName = Name,
                CreatedDate = DateTime.Now,
                DriverId = model.DriverId,
                Flag = ExpensesFlag.Driver,
                Name = Driver.Name + "حساب السائق ",
            };
            DailyExpenses.ExpensesDetails.Add(ExpensesDriver);
            DailyExpenses.NetTotal = model.Amount;
            DailyExpenses.Flag = ExpensesFlag.Driver;

            await UnitOFWork.Repository<DailyExpenses>().AddAsync(DailyExpenses);
            await UnitOFWork.CompleteAsync();
            model.DailyExpensesId = DailyExpenses.Id;
            await UnitOFWork.Repository<DriverExpenses>().AddAsync(model);
            await UnitOFWork.CompleteAsync();

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Add Success",
                Obj = model
            };
        }
        public async Task<ResponseResult> GetAll()
        {
            var All = await UnitOFWork.Repository<DriverExpenses>().ToListAsync();
            if (All == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };
            return new ResponseResult { IsSuccess = true, Message = "none", Obj = All };
        }
        public async Task<ResponseResult> Update(DriverExpenses model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Send Null" };

            if (model.DriverId <= 0)
                return new ResponseResult { IsSuccess = false, Message = "ادخل  السائق" };

            var Driver = await UnitOFWork.Repository<Driver>()
                  .Where(e => e.Id == model.DriverId).FirstOrDefaultAsync();
            if (Driver == null)
                return new ResponseResult { IsSuccess = false, Message = "السائق غير موجود " };

            if (model.Amount <= 0)
                return new ResponseResult { IsSuccess = false, Message = "ادخل حساب السائق" };

            var modelExist = await UnitOFWork.Repository<DriverExpenses>().
                Where(e => e.Id == model.Id).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };


            var DailyExpensess  = await UnitOFWork.Repository<DailyExpenses>()
                .Include(e=>e.ExpensesDetails)
               .Where(e => e.Id == modelExist.DailyExpensesId).FirstOrDefaultAsync();

            UnitOFWork.Repository<ExpensesDetails>().DeleteRange(DailyExpensess.ExpensesDetails);
            DailyExpensess.NetTotal = 0;

            DailyExpensess.Flag = ExpensesFlag.Driver;

            var ExpensesDriver = new ExpensesDetails()
            {
                Date = model.Date,
                Amount = model.Amount,
                CreatedById = Id,
                CreatedByName = Name,
                CreatedDate = DateTime.Now,
                DriverId = model.DriverId,
                Flag = ExpensesFlag.Driver,
                Name = Driver.Name + "حساب السائق ",
            };
            DailyExpensess.ExpensesDetails.Add(ExpensesDriver);
            //
            model.LastModifiedDate = DateTime.Now;
            model.ModifyById = Id;
            model.ModifyByName = Name;
            model.ModifyCount = modelExist.ModifyCount + 1;
            DailyExpensess.NetTotal = model.Amount;
            modelExist.DailyExpensesId = DailyExpensess.Id;
            model.DailyExpensesId = DailyExpensess.Id;
            model.DriverName = Driver.Name;


            var MapModel = _mapper.Map(model, modelExist);
            var i = await UnitOFWork.Repository<DriverExpenses>().UpdateAsync(MapModel);
            await UnitOFWork.CompleteAsync();

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Update Success",
                Obj = model
            };
        }
        public async Task<ResponseResult> Delete(int id)
        {
            if (id <= 0)
                return new ResponseResult { IsSuccess = false, Message = "Id Required" };

            var modelExist = await UnitOFWork.Repository<DriverExpenses>().
                           Where(e => e.Id == id).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };

           var DailyExpenses = await UnitOFWork.Repository<DailyExpenses>()
                .Where(e => e.Id == modelExist.DailyExpensesId)
                .Include(e => e.ExpensesDetails).FirstOrDefaultAsync();

            var x= UnitOFWork.Repository<ExpensesDetails>().DeleteRange(DailyExpenses.ExpensesDetails);
            var i1 = await UnitOFWork.Repository<DailyExpenses>().DeleteAsync(DailyExpenses.Id);
            var i2 = await UnitOFWork.Repository<DriverExpenses>().DeleteAsync(modelExist.Id);

            await UnitOFWork.CompleteAsync();

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Delete Success",
                Obj = modelExist.Id
            };
        }
    }
}
