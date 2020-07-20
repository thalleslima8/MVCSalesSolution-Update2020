using MVCSalesSolution.Data;
using MVCSalesSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSalesSolution.Services
{
    public class DepartmentService
    {

        private readonly MVCSalesSolutionContext _context;

        public DepartmentService(MVCSalesSolutionContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }

    }


}
