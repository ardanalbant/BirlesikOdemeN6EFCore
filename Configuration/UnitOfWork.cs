using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using BirlesikOdemeN6EFCore.Data;
using BirlesikOdemeN6EFCore.Services;

namespace BirlesikOdemeN6EFCore.Configuration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DBContext _context;
        private readonly ILogger _logger;

        public ICustomerRepository Customer { get; private set; }

        public UnitOfWork(DBContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Customer = new CustomerRepository(context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
