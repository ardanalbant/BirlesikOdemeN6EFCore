using System.Threading.Tasks;
using BirlesikOdemeN6EFCore.Services;

namespace BirlesikOdemeN6EFCore.Configuration
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        Task CompleteAsync();

        void Dispose();
    }
}
