   using Application.Implement.DailyRevenues;
using Application.Interfaces;
using Application.Interfaces.Expensess;
using AutoMapper;
using Domain.Dto;
using Domain.Entities.Company;
using Domain.Entities.CompanyAPP;
using Domain.Entities.DailyExpenses;
using Domain.Entities.DailyRevenue;
using Domain.Entities.Expenses;
using Domain.Helper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Domain.Entities.Expenses.Type;

namespace Application.Implement.Expensess
{
    public class ExpensesService: IExpensesService
    {
        private readonly IUnitOfWork UnitOFWork;
        private IMapper _mapper;
        private JwtHelper _jwtHelper;
        private string Id;
        private string Name;
        public ExpensesService(
                  IUnitOfWork unitOfWork,
                       JwtHelper jwtHelper,
                   IMapper mapper)
        {
            UnitOFWork = unitOfWork;
            _mapper = mapper;
            _jwtHelper = jwtHelper;
            Id = _jwtHelper.ReadTokenClaim(TokenClaimType.Id);
            Name = _jwtHelper.ReadTokenClaim(TokenClaimType.UserName);
        }

        public async Task<ResponseResult> Create(Expenses model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Null" };

            if (model.Amount <= 0)
                return new ResponseResult { IsSuccess = false, Message = "ادخل قيمة المصروف" };


            model.CreatedById = Id;
            model.CreatedByName = Name;

            await UnitOFWork.Repository<Expenses>().AddAsync(model);
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

            var modelExist = await UnitOFWork.Repository<Expenses>().
                Where(e => e.Id == id).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };

            var ExpensesDayExist = await UnitOFWork.Repository<ExpensesDetails>().
                    Where(e => e.ExpensesId == modelExist.Id).FirstOrDefaultAsync();
            if(ExpensesDayExist != null)
            return new ResponseResult { IsSuccess = false, Message = "عفوا لا يمكن حذف المصروف لوجودة في مصاريف يومية" };

            var i = await UnitOFWork.Repository<Expenses>().DeleteAsync(modelExist.Id);
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
            var All = await UnitOFWork.Repository<Expenses>().ToListAsync();
            if (All == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };
            return new ResponseResult { IsSuccess = true, Message = "none", Obj = All };
        }
        public async Task<ResponseResult> Update(Expenses model)            
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Send Null" };

            if (model.Id <= 0)
                return new ResponseResult { IsSuccess = false, Message = "Id Required" };

            var modelExist = await UnitOFWork.Repository<Expenses>().
                Where(e => e.Id == model.Id).FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };


            model.LastModifiedDate = DateTime.Now;
            model.ModifyById = Id;
            model.ModifyByName = Name;
            model.ModifyCount = modelExist.ModifyCount + 1;

            var MapModel = _mapper.Map(model, modelExist);
            var i = await UnitOFWork.Repository<Expenses>().UpdateAsync(MapModel);
            await UnitOFWork.CompleteAsync();

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Update Success",
                Obj = model
            };
        }
        public async Task<ResponseResult> ExpensesSearchInfo()
        {
            var AllExpenses = await UnitOFWork.Repository<Expenses>().ToListAsync();
            if (AllExpenses == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };

            var AllCompany = await UnitOFWork.Repository<Company>().ToListAsync();
            if (AllCompany == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };

            var AllCompanyAPP = await UnitOFWork.Repository<CompanyAPP>().ToListAsync();
            if (AllCompanyAPP == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };

            return new ResponseResult { IsSuccess = true, Message = "none", Obj = new {
                AllExpenses,
                AllCompany,
                AllCompanyAPP

            } };

        }
        public async Task<ResponseResult> ExpensesSearch(SearchDto searchDto)
        {

            if (searchDto.ExpenseId == 0 && searchDto.CompanyId == 0 && searchDto.AppId == 0)
            {

                var list = await UnitOFWork.Repository<ExpensesDetails>()
                     .Where(e => e.Date >= searchDto.FromDate && e.Date <= searchDto.ToDate)
                     .ToListAsync();

                return new ResponseResult { IsSuccess = true, Message = "none", Obj = list };
            }

            if (searchDto.ExpenseId > 0)
            {
                var list = await UnitOFWork.Repository<ExpensesDetails>()
                   .Where(
                    e => e.Date >= searchDto.FromDate 
                    && e.Date <= searchDto.ToDate
                    && e.ExpensesId == searchDto.ExpenseId)
                   .ToListAsync();

                return new ResponseResult { IsSuccess = true, Message = "none", Obj = list };
            }

            if (searchDto.CompanyId > 0)
            {
                var list = await UnitOFWork.Repository<ExpensesDetails>()
                   .Where(
                    e => e.Date >= searchDto.FromDate
                    && e.Date <= searchDto.ToDate
                    && e.CompanyId == searchDto.CompanyId)
                   .ToListAsync();

                return new ResponseResult { IsSuccess = true, Message = "none", Obj = list };
            }

            if (searchDto.AppId > 0)
            {
                var list = await UnitOFWork.Repository<ExpensesDetails>()
                   .Where(
                    e => e.Date >= searchDto.FromDate
                    && e.Date <= searchDto.ToDate
                    && e.AppId == searchDto.AppId)
                   .ToListAsync();

                return new ResponseResult { IsSuccess = true, Message = "none", Obj = list };
            }

            return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };
        }





    }
}
