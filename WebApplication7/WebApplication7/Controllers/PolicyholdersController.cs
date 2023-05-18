using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Data;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    //kontroler vytvořený pomocí Entity Frameworku
    public class PolicyholdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        //vytvoření tří vlastností pro načtení dat
        //data se načítají do vlastností v akci Detail

        public string ActualPolicyholderFirstName { get; set; } = "";
        public string ActualPolicyhoderLastName { get; set; } = "";

        public int ActualPolicyholderId { get; set; }

        public PolicyholdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Policyholders
        public async Task<IActionResult> Index()
        {
              return _context.Policyholder != null ? 
                          View(await _context.Policyholder.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Policyholder'  is null.");
        }

        // GET: Policyholders/Details/5
        public async Task<IActionResult> Details(int? id, string ActualPolicyhoderLastName,string ActualPolicyholderFirstName, int ActualPolicyholderId)
        {
            if (id == null || _context.Policyholder == null)
            {
                return NotFound();
            }

            var policyholder = await _context.Policyholder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policyholder == null)
            {
                return NotFound();
            }
            //data jsou skutečně uložena ve vlastnostech
            //vytvořená kolekce ViewBag pro zkoušku, zda-li je hodnota ve vlastnosti
            ActualPolicyhoderLastName = policyholder.LastName;
            ActualPolicyholderFirstName = policyholder.FirstName;
            ActualPolicyholderId = policyholder.Id;
            ViewBag.Jmeno = ActualPolicyholderFirstName;
            return View(policyholder);
        }

        // GET: Policyholders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Policyholders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,TelephoneNumber,Street,City,PostCode")] Policyholder policyholder)
        {

            if (ModelState.IsValid)
            {
                _context.Add(policyholder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(policyholder);
        }

        // GET: Policyholders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Policyholder == null)
            {
                return NotFound();
            }

            var policyholder = await _context.Policyholder.FindAsync(id);
            if (policyholder == null)
            {
                return NotFound();
            }
            return View(policyholder);
        }

        // POST: Policyholders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,TelephoneNumber,Street,City,PostCode")] Policyholder policyholder)
        {
            if (id != policyholder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policyholder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolicyholderExists(policyholder.Id))
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
            return View(policyholder);
        }

        // GET: Policyholders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Policyholder == null)
            {
                return NotFound();
            }

            var policyholder = await _context.Policyholder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policyholder == null)
            {
                return NotFound();
            }

            return View(policyholder);
        }

        // POST: Policyholders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Policyholder == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Policyholder'  is null.");
            }
            var policyholder = await _context.Policyholder.FindAsync(id);
            if (policyholder != null)
            {
                _context.Policyholder.Remove(policyholder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PolicyholderExists(int id)
        {
          return (_context.Policyholder?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
