using MVCSalesSolution.Data;
using MVCSalesSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSalesSolution.Services
{
    public class SellerService
    {

        private readonly MVCSalesSolutionContext _context;

        public SellerService(MVCSalesSolutionContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
