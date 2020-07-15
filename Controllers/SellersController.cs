using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCSalesSolution.Services;

namespace MVCSalesSolution.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index() //Open an Index page, on View folder Sellers
        {
            var list = _sellerService.FindAll();
            return View(list);
        }
    }
}
