using RealEstateManager.DataAccess.Repositories.Contracts;
using RealEstateManager.Database.Context;
using RealEstateManager.Database.Models;

namespace RealEstateManager.DataAccess.Repositories.Services
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly RealEstateContext _context;

        public PropertyRepository(RealEstateContext context)
        {
            _context = context;
        }

        public Property AddProperty(Property property)
        {
            _context.Properties.Add(property);
            _context.SaveChanges();
            return property;
        }

        public IEnumerable<Property> GetAll()
        {
            return _context.Properties;
        }

        public Property GetById(int id)
        {
            return _context.Properties.FirstOrDefault(x => x.Id == id);
        }

    }
}
