using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiMvcApp.Data;
using MiMvcApp.Models;

namespace MiMvcApp.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ItemsController(ApplicationDbContext db) { _db = db; }

        public async Task<IActionResult> Index() => View(await _db.Items.ToListAsync());
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(Item item)
        {
            if (!ModelState.IsValid) return View(item);
            _db.Add(item);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
