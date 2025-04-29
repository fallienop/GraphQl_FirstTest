    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RealEstateManager.Database.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        [Precision(18, 2)]
        public decimal Value {  get; set; }
        public string Family { get; set; }  
        public ICollection<Payment> Payments { get; set; }
    }
}
