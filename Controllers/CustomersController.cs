using malshetwi_Project3_SDA.LMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace malshetwi_Project3_SDA.LMS.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppDbContext _context;
        public CustomersController (AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            // var data = _context.Customers.ToList();
            return View(await _context.Customers.ToListAsync());
        }
    }
}
