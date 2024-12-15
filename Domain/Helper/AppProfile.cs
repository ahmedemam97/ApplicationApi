using AutoMapper;
using Domain.Dto.User;
using Domain.Entities;
using Domain.Entities.Bookings;
using Domain.Entities.City;
using Domain.Entities.Clients;
using Domain.Entities.Company;
using Domain.Entities.CompanyAPP;
using Domain.Entities.CompleteBookings;
using Domain.Entities.DailyExpenses;
using Domain.Entities.DailyRevenue;
using Domain.Entities.Driver;
using Domain.Entities.DriverExpenses;
using Domain.Entities.Expenses;
using Domain.Entities.Maintenance;
using Domain.Entities.PrivateTours;

namespace Domain.Helper
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Maintenance, Maintenance>().ReverseMap(); 
            CreateMap<Clients, Clients>().ReverseMap();
            CreateMap<DriverExpenses, DriverExpenses>().ReverseMap();
            CreateMap<DailyExpenses, DailyExpenses>().ReverseMap();
            CreateMap<DailyRevenue, DailyRevenue>().ReverseMap(); 
            CreateMap<ApplicationUser, UserRes>().ReverseMap();
            CreateMap<ApplicationUser, UserDto>().ReverseMap(); 
            CreateMap<PrivateTours, PrivateTours>().ReverseMap();
            CreateMap<Driver, Driver>().ReverseMap();
            CreateMap<CompanyAPP, CompanyAPP>().ReverseMap(); 
            CreateMap<Bookings, Bookings>().ReverseMap();
            CreateMap<City, City>().ReverseMap();
            CreateMap<CompleteBookings, CompleteBookings>().ReverseMap();
            CreateMap<Company, Company>().ReverseMap(); 
            CreateMap<Expenses, Expenses>().ReverseMap();
            CreateMap<ExpensesDetails, ExpensesDetails>().ReverseMap();
        }

    }
}
