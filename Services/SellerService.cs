using MVCSalesSolution.Data;
using MVCSalesSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCSalesSolution.Services.Exceptions;

namespace MVCSalesSolution.Services
{
    public class SellerService
    {

        private readonly MVCSalesSolutionContext _context;

        public SellerService(MVCSalesSolutionContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync() //find all sellers in DB
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj) //insert the new seller to DB
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindbyIdAsync(int id) //find the department
        {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id) //remove selected seller
        {
            try //try to catch a integrity exception - foreign key (seller->salesRecord)
            {
                var obj = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }catch(DbUpdateException)
            {
                throw new IntegrityException("Can't delete this seller because he/she has sales.");
            }
        }

        public async Task UpdateAsync(Seller seller) //Update the edited seller
        {
            if (!await _context.Seller.AnyAsync(x => x.Id == seller.Id))
            {
                throw new NotFoundException("Seller not found");
            }
            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
