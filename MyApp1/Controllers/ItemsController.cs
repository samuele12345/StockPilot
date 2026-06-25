using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyApp1.Data;
using MyApp1.Models;

namespace MyApp1.Controllers
{
    public class ItemsController : Controller
    {
        private readonly MyApp1Context _context;

        public ItemsController(MyApp1Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Carica tutti gli item con caricamento anticipato di SerNumber e Category per evitare N+1 queries
            // Utilizzare Include corrisponde all'utilizzo del join
            var item = await _context.Item.Include(s => s.SerNumber).Include(c => c.Category).ToListAsync();
            return View(item);
        }

        public IActionResult Create()
        {
            // Crea una SelectList per il dropdown delle categorie (Id = valore, Name = testo visualizzato)
            ViewBag.Category = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        // Bind limita il model binding solo alle proprietà specificate, prevenendo over-posting
        public async Task<IActionResult> Create([Bind("Id", "Name", "Price", "CategoryId")] Items item)
        {
            bool itemExists = await _context.Item
            .AnyAsync(x => x.Name == item.Name && x.Price == item.Price);

            if (itemExists)
            {
                ModelState.AddModelError("", "An item with the same name and price already exists.");
                ViewBag.Category = new SelectList(_context.Categories, "Id", "Name", item.CategoryId);
                return View(item);
            }

            if (ModelState.IsValid)
            {
                item.Name = item.Name.Trim();
                var serNum = new SerialNumber();
                var random = new Random();
                int num = random.Next(10, 100);

                if(item.Name.Length < 3)
                {
                    if (item.Name.Length == 1)
                    {
                        string str = item.Name.Substring(0, 1) + "XX";

                        serNum.Name = str + num;
                    }
                    else if(item.Name.Length == 2)
                    {
                        string str = item.Name.Substring(0, 2) + "X";

                        serNum.Name = str + num;
                    }
                }
                else
                {
                    string str = item.Name.Substring(0, 3);

                    serNum.Name = str + num;
                }

                _context.SerialNumbers.Add(serNum);
                await _context.SaveChangesAsync();

                item.IdSerial = serNum.Id;
                _context.Item.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Category = new SelectList(_context.Categories, "Id", "Name", item.CategoryId);
            return View(item);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.Item.FirstOrDefaultAsync(x => x.Id == id);
            ViewBag.Category = new SelectList(_context.Categories, "Id", "Name", item?.CategoryId);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "Name", "Price", "CategoryId")] Items item)
        {
            if (ModelState.IsValid)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(_context.Categories, "Id", "Name", item.CategoryId);
            return View(item);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Item.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Item.FindAsync(id);
            if(item != null)
            {
                _context.Item.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public IActionResult AboutUs()
        {
            return View();
        }



        /*
        public IActionResult Overview() // IActionResult cntienen tutte le tipologie di possibili dati ritornabili
        {
            var item = new Items() { Name="Keyboard", isLogged=true};
            return View(item);
        }

        // Action parameters: actions utili a ricevere dati da diverse sorgenti: url, query e form
        // Il nome del parametro 'id' deve corrispondere al nome nella route {id?} o nella query string
        // Funziona con: /Items/Edit/3 (route param) oppure /Items/Edit?id=3 (query string)

        public IActionResult Edit(int id)
        {
            return Content("id: " + id);
        }

        [HttpPost]
        public IActionResult Submit(string name)
        {
            var item = new Items();
            if(name != null)
            {
                item.Name = name;
            }
            else
            {
                item.Name = "Inserire un valore";
            }
            
            item.isLogged = true;
            return View("Overview", item);
        }

        */
    }
}
