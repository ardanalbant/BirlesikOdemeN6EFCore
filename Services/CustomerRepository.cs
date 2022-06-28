using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirlesikOdemeN6EFCore.Data;
using BirlesikOdemeN6EFCore.Models;

namespace BirlesikOdemeN6EFCore.Services
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DBContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Customer>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(CustomerRepository));
                return new List<Customer>();
            }
        }
        public override async Task<bool> Upsert(Customer entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

                if (existingUser == null)
                    return await Add(entity);

                existingUser.NAME = entity.NAME;
                existingUser.SURNAME = entity.SURNAME;
                existingUser.MAIL = entity.MAIL;
                existingUser.IDENTITYNOVERIFIED = entity.IDENTITYNOVERIFIED;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(CustomerRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(CustomerRepository));
                return false;
            }
        }
    }
}
