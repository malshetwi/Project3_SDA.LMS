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
    public class ItemsController : Controller
    {
        private readonly AppDbContext _context;

        public ItemsController(AppDbContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
           // var data = _context.Items.ToList();
            return View(await _context.Items.ToListAsync());
        }
        //~

        // login
        public IActionResult Login()
        {
            
            return View();
        }
        //~

        // GET: Items/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Items/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemPicURL,ItemName,ItemBio,Price")] Item Item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Item);
        }
        //~

        // GET: Items/Edit
        public async Task<IActionResult> Edit(int? id)
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

        // POST: Items/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemID,ItemPicURL,ItemName,ItemBio,Price")] Item Item)
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

        // GET: Items/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Item = await _context.Items
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (Item == null)
            {
                return NotFound();
            }

            return View(Item);
        }

        // POST: Items/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Item = await _context.Items.FindAsync(id);
            _context.Items.Remove(Item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //~



        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemID == id);
        }
    }
}

    