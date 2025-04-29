using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RealEstateManager.Database.Models
{
    public class Payment
    {
        public int Id { get; set; }
        [Precision(18, 2)]
        public decimal Value { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateOverdue { get; set; }
        public bool Paid {  get; set; } 
        public int PropertyId {  get; set; }
        public Property Property { get; set; }
    }
}
