using malshetwi_Project3_SDA.LMS.Data;
using malshetwi_Project3_SDA.LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace malshetwi_Project3_SDA.LMS.Controllers
{
    public class OrdersController : Controller
    {
        private readonly AppDbContext _context;

        public OrdersController (AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            // var data = _context.Orders.ToList();
            return View(await _context.Items.ToListAsync());
        }
        //~

        // GET: Orders/Order  (SameEdit)
        public async Task<IActionResult> Order(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Item = await _context.Items.FindAsync(id);
            if (Item == null)
            {
                return NotFound();
            }
            return View(Item);
        }
        // POST: Orders/Order
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order(int id, [Bind("ItemID,ItemPicURL,ItemName,ItemBio,Price")] Item Item)
        {
            if (id != Item.ItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(Item.ItemID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Item);
        }
        //~

        public IActionResult OrderSuccess()
        {
            

            return View();
        }



        //[
        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemID == id);
        }
    }//]
}
