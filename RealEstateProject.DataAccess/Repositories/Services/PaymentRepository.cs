using RealEstateManager.DataAccess.Repositories.Contracts;
using RealEstateManager.Database.Context;
using RealEstateManager.Database.Models;

namespace RealEstateManager.DataAccess.Repositories.Services
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly RealEstateContext _context;

        public PaymentRepository(RealEstateContext context)
        {
            _context = context;
        }



        //public async Task<IEnumerable<Payment>> GetAll(int propertyId)
        //{
        //    return await _context.Payments.Where(x => x.Id == propertyId).ToListAsync();
        //}

        public IEnumerable<Payment> GetAll(int propertyId)
        {
            return _context.Payments.Where(x => x.Id == propertyId).ToList();
        }

        public IEnumerable<Payment> GetLastWithCount(int propertyId, int count)
        {
            return _context.Payments.Where(x => x.Id == propertyId).OrderByDescending(x => x.DateCreated).Take(count);
        }
    }
}
