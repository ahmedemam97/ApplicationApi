using Application.Interfaces;
using Application.Interfaces.DailyRevenues;
using AutoMapper;
using Domain.Dto;
using Domain.Dto.RevenueDto;
using Domain.Entities.Company;
using Domain.Entities.CompanyAPP;
using Domain.Entities.DailyExpenses;
using Domain.Entities.DailyRevenue;
using Domain.Helper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implement.DailyRevenues
{
    public class DailyRevenueServices : Hub, IDailyRevenueServices
    {
        private readonly IHubContext<DailyRevenueServices> HubContext;
        private readonly IUnitOfWork UnitOFWork;
        private IMapper _mapper;
        private JwtHelper _jwtHelper;
        private string Id;
        private string Name;
        public DailyRevenueServices(
            IUnitOfWork unitOfWork,
            JwtHelper jwtHelper,
             IMapper mapper,
            IStringLocalizer<DailyRevenueServices> localizer, IHubContext<DailyRevenueServices> hubContext)
        {
            UnitOFWork = unitOfWork;
            HubContext = hubContext;
            _mapper = mapper;
            _jwtHelper = jwtHelper;
            Id = _jwtHelper.ReadTokenClaim(TokenClaimType.Id);
            Name = _jwtHelper.ReadTokenClaim(TokenClaimType.UserName);
        }
        public async Task<ResponseResult> GetPageInfo()
        {
            var AllCompany = await UnitOFWork.Repository<Company>().ToListAsync();

            if(AllCompany == null)
                return new ResponseResult { IsSuccess = false, Message = "الشراكات غير موجودة" };

            var AllCompanyAPP = await UnitOFWork.Repository<CompanyAPP>().ToListAsync();

            if (AllCompanyAPP == null)
                return new ResponseResult { IsSuccess = false, Message = "شركات التطبيق غير موجودة" };

            var DailyRevenuelist = await UnitOFWork.Repository<DailyRevenue>()
                .Where(e=>e.Flag != RevenueFlag.Travel)
               .Include(e => e.RevenueDetails)
               .ToListAsync();
            if (DailyRevenuelist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "none",
                Obj = new
                {
                    AllCompany,
                    AllCompanyAPP,
                    DailyRevenuelist
                }
            };
        }
        public async Task<ResponseResult> Create(DailyRevenueDto model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Send Null" };

            var DailyRevenue = new DailyRevenue();
            DailyRevenue.RevenueDetails = new List<RevenueDetails>();

            if (model.RevenueCompany.Count() > 0 && model.RevenueCompany != null) 
            {
                foreach (var item in model.RevenueCompany)
                {
                    if (item.RevenueId > 0 && item.Amount > 0)
                    {
                        var Company = await UnitOFWork.Repository<Company>()
                              .Where(e => e.Id == item.RevenueId).FirstOrDefaultAsync();
                        if (Company == null)
                            return new ResponseResult { IsSuccess = false, Message = "الشركة غير موجودة" };

                        var Revenue = new RevenueDetails()
                        {
                            Date = model.Date,
                            Amount = item.Amount,
                            CreatedById = Id,
                            CreatedByName = Name,
                            CreatedDate = DateTime.Now,
                            CompanyId = item.RevenueId,
                            RevenueId = item.RevenueId,
                            Flag = RevenueFlag.Company,
                            Name = Company.Name,
                        };
                        DailyRevenue.RevenueDetails.Add(Revenue);
                    }
                }
            }

            if (model.RevenueApp.Count() > 0 && model.RevenueApp != null)
            {
                foreach (var item in model.RevenueApp)
                {
                    if (item.RevenueId > 0 && item.Amount > 0)
                    {
                        var CompanyAPP = await UnitOFWork.Repository<CompanyAPP>()
                              .Where(e => e.Id == item.RevenueId).FirstOrDefaultAsync();
                        if (CompanyAPP == null)
                            return new ResponseResult { IsSuccess = false, Message = "الشركة غير موجودة" };

                        var Revenue = new RevenueDetails()
                        {
                            Date = model.Date,
                            Amount = item.Amount,
                            CreatedById = Id,
                            CreatedByName = Name,
                            CreatedDate = DateTime.Now,
                            AppId = item.RevenueId,
                            RevenueId = item.RevenueId,
                            Flag = RevenueFlag.App,
                            Name = CompanyAPP.Name,
                        };
                        DailyRevenue.RevenueDetails.Add(Revenue);
                    }
                }
            }

              DailyRevenue.Date = model.Date;
              DailyRevenue.NetTotal = DailyRevenue.RevenueDetails.Sum(e => e.Amount);
              DailyRevenue.CreatedById = Id;
              DailyRevenue.CreatedByName = Name;

            if (DailyRevenue.NetTotal == 0)
                return new ResponseResult { IsSuccess = false, Message = "ادخل ايراد واحد علي الاقل" };
            await UnitOFWork.Repository<DailyRevenue>().AddAsync(DailyRevenue);
            await UnitOFWork.CompleteAsync();

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Add Success",
                Obj = DailyRevenue
            };
        }
        public async Task<ResponseResult> Delete(int id)
        {
            if (id <= 0)
                return new ResponseResult { IsSuccess = false, Message = "Id Required" };

            var modelExist = await UnitOFWork.Repository<DailyRevenue>().
                Where(e=>e.Id == id)
                .Include(e=>e.RevenueDetails)
                .FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };

            var i2 = UnitOFWork.Repository<RevenueDetails>().DeleteRange(modelExist.RevenueDetails);
            var i = await UnitOFWork.Repository<DailyRevenue>().DeleteAsync(modelExist.Id);
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
            var All = await UnitOFWork.Repository<DailyRevenue>()
                .Include(e => e.RevenueDetails)
                .ToListAsync();
            if (All == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };

            return new ResponseResult { IsSuccess = true, Message = "none", Obj = All };
        }
        public async Task<ResponseResult> Update(DailyRevenueDto model)
        {
            if (model == null)
                return new ResponseResult { IsSuccess = false, Message = "Send Null" };

            if (model.Id <= 0)
                return new ResponseResult { IsSuccess = false, Message = "Id Required" };

            var modelExist = await UnitOFWork.Repository<DailyRevenue>().
                Where(e=>e.Id ==model.Id)
                .Include(e=>e.RevenueDetails)
                .FirstOrDefaultAsync();
            if (modelExist == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound" };

            var i1 = UnitOFWork.Repository<RevenueDetails>().DeleteRange(modelExist.RevenueDetails);


            if (model.RevenueCompany.Count() > 0 && model.RevenueCompany != null)
            {
                foreach (var item in model.RevenueCompany)
                {
                    if (item.RevenueId > 0 && item.Amount > 0)
                    {
                        var Company = await UnitOFWork.Repository<Company>()
                              .Where(e => e.Id == item.RevenueId).FirstOrDefaultAsync();
                        if (Company == null)
                            return new ResponseResult { IsSuccess = false, Message = "الشركة غير موجودة" };

                        var Revenue = new RevenueDetails()
                        {
                            Date = model.Date,
                            Amount = item.Amount,
                            CreatedById = Id,
                            CreatedByName = Name,
                            CreatedDate = DateTime.Now,
                            CompanyId = item.RevenueId,
                            Flag = RevenueFlag.Company,
                            Name = Company.Name,
                        };
                        modelExist.RevenueDetails.Add(Revenue);
                    }
                }
            }

            if (model.RevenueApp.Count() > 0 && model.RevenueApp != null)
            {
                foreach (var item in model.RevenueApp)
                {
                    if (item.RevenueId > 0 && item.Amount > 0)
                    {
                        var CompanyAPP = await UnitOFWork.Repository<CompanyAPP>()
                              .Where(e => e.Id == item.RevenueId).FirstOrDefaultAsync();
                        if (CompanyAPP == null)
                            return new ResponseResult { IsSuccess = false, Message = "الشركة غير موجودة" };

                        var Revenue = new RevenueDetails()
                        {
                            Date = model.Date,
                            Amount = item.Amount,
                            CreatedById = Id,
                            CreatedByName = Name,
                            CreatedDate = DateTime.Now,
                            AppId = item.RevenueId,
                            Flag = RevenueFlag.App,
                            Name = CompanyAPP.Name,
                        };
                        modelExist.RevenueDetails.Add(Revenue);
                    }
                }
            }


            if (modelExist.NetTotal == 0)
                return new ResponseResult { IsSuccess = false, Message = "ادخل ايراد واحد علي الاقل" };

            modelExist.LastModifiedDate = DateTime.Now;
            modelExist.ModifyById = Id;
            modelExist.ModifyByName = Name;
            modelExist.ModifyCount = modelExist.ModifyCount + 1;


            var AmountCompany = model.RevenueApp.Sum(e => e.Amount);
            var AmountApp = model.RevenueApp.Sum(e => e.Amount);

            modelExist.NetTotal = AmountCompany + AmountApp;



            await UnitOFWork.CompleteAsync();

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Update Success",
                Obj = modelExist
            };
        }
        public async Task<ResponseResult> RevenueSearch(SearchDto searchDto)
        {

            if (searchDto.CompanyId == 0 && searchDto.AppId == 0)
            {
                var list = await UnitOFWork.Repository<RevenueDetails>()
                     .Where(e => e.Date >= searchDto.FromDate && e.Date <= searchDto.ToDate
                     && e.Amount > 0)
                     .ToListAsync();

                return new ResponseResult { IsSuccess = true, Message = "none", Obj = list };
            }


            if (searchDto.CompanyId > 0)
            {
                var list = await UnitOFWork.Repository<RevenueDetails>()
                   .Where(
                    e => e.Date >= searchDto.FromDate
                    && e.Date <= searchDto.ToDate
                    && e.Amount > 0
                    && e.CompanyId == searchDto.CompanyId)
                   .ToListAsync();

                return new ResponseResult { IsSuccess = true, Message = "none", Obj = list };
            }

            if (searchDto.AppId > 0)
            {
                var list = await UnitOFWork.Repository<RevenueDetails>()
                   .Where(
                    e => e.Date >= searchDto.FromDate
                    && e.Date <= searchDto.ToDate
                    && e.Amount > 0
                    && e.AppId == searchDto.AppId)
                   .ToListAsync();

                return new ResponseResult { IsSuccess = true, Message = "none", Obj = list };
            }

            return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };

        }
        public async Task<ResponseResult> RevenueSearchInfo()
        {
            var AllCompany = await UnitOFWork.Repository<Company>().ToListAsync();
            if (AllCompany == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };

            var AllCompanyAPP = await UnitOFWork.Repository<CompanyAPP>().ToListAsync();
            if (AllCompanyAPP == null)
                return new ResponseResult { IsSuccess = false, Message = "NotFound", Obj = null };


            return new ResponseResult
            {
                IsSuccess = true,
                Message = "none",
                Obj = new
                {
                    AllCompany,
                    AllCompanyAPP

                }
            };






        }
    }
}
