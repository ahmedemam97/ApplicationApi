using Application.Implement;
using Application.Implement.BookingsS;
using Application.Implement.Citys;
using Application.Implement.Clientss;
using Application.Implement.CompanyAPPS;
using Application.Implement.Companys;
using Application.Implement.CompleteBookingss;
using Application.Implement.DailyExpensess;
using Application.Implement.DailyRevenues;
using Application.Implement.DriverExpensess;
using Application.Implement.DriverS;
using Application.Implement.Expeneds;
using Application.Implement.Expensess;
using Application.Implement.Maintenances;
using Application.Implement.PrivateTourss;
using Application.Implement.User;
using Application.Interfaces;
using Application.Interfaces.Bookingss;
using Application.Interfaces.Citys;
using Application.Interfaces.Clientss;
using Application.Interfaces.CompanyAPPS;
using Application.Interfaces.Companys;
using Application.Interfaces.CompleteBookingss;
using Application.Interfaces.DailyExpensess;
using Application.Interfaces.DailyRevenues;
using Application.Interfaces.DriverExpensesS;
using Application.Interfaces.Drivers;
using Application.Interfaces.Expeneds;
using Application.Interfaces.Expensess;
using Application.Interfaces.Maintenances;
using Application.Interfaces.PrivateTourss;
using Application.Interfaces.User;
using Domain.Entities.Expenses;
using Domain.Helper;


namespace Api.Extentions
{
    public static class ServicesLifeTimeService
    {
        public static IServiceCollection AddServicesLifeTime(this IServiceCollection service)
        {
            service.AddScoped<ICityServices, CityServices>();
            service.AddScoped<IClientsServices, ClientsServices>();
            service.AddScoped<ICompanyService, CompanyService>();
            service.AddScoped<ICompanyAppService, CompanyAppService>();
            service.AddScoped<ICompleteBookingsService, CompleteBookingsService>();
            service.AddScoped<IDailyExpensesService, DailyExpensesService>(); 
            service.AddScoped<IDailyRevenueServices, DailyRevenueServices>(); 
            service.AddScoped<IDriverExpensesService, DriverExpensesService>();
            service.AddScoped<IDriverService, DriverService>();
            service.AddScoped<IExpenedService, ExpenedService>();
            service.AddScoped<IExpensesService, ExpensesService>();
            service.AddScoped<IMaintenanceService, MaintenanceService>();
            service.AddScoped<IBookingsService, BookingsService>();
            service.AddScoped<IPrivateToursService, PrivateToursService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddScoped<JwtHelper>();
            return service;
        }
    }
}
