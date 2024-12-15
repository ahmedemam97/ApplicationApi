
//using Application.Reports;
//using DataAccess;
//using Domain.Dto.Report;
//using Domain.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace Application
//{
//    public class DefaultData
//    {
//        readonly ApplicationDBContext _context;
//        public DefaultData(string connectionString)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>()
//                .UseSqlServer(connectionString);
//            _context = new ApplicationDBContext(optionsBuilder.Options);
//        }

//        public async Task<bool> Seed()
//        {        
//            if (!await Reports())
//            {
//                return false;
//            }
//            await _context.SaveChangesAsync();
//            await _context.Database.CommitTransactionAsync();
//            await _context.DisposeAsync();
//            return true;
//        }
//        async Task<bool> Reports()
//        {
//            foreach (var item in Enum.GetValues(typeof(DocType)))
//            {
//                var _item = (DocType)item;
//                await _context.Reports.AddAsync( new ReportItem
//                {
//                    NameAr = Enum.GetName(_item),
//                    NameEn = Enum.GetName(_item),
//                    IsActive = true,
//                    CreatedDate = DateTime.Now,
//                    CancelBy= "Seed",
//                    DisplayName = "Default Report",
//                    ReportType = ReportType.SaleInvoice_A4,
//                    DocType = _item,
//                    //LayoutData = new SaleInvoice_A4().GetReportBytes()
//                });           
//            }
//            await _context.SaveChangesAsync();
//            return true;
//        }
//    }
//}
