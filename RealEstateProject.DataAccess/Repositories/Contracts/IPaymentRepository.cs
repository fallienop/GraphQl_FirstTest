using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateManager.Database.Models;

namespace RealEstateManager.DataAccess.Repositories.Contracts
{
    public interface IPaymentRepository
    {
        //Task<IEnumerable<Payment>> GetAll(int propertyId);
        IEnumerable<Payment> GetAll(int propertyId);
        IEnumerable<Payment> GetLastWithCount(int propertyId, int count);
    }
}
