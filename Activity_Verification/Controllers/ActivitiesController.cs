using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Activity_Verification.Models;

namespace Activity_Verification.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly ActivityContext _context;

        public ActivitiesController(ActivityContext context)
        {
            _context = context;
        }

        // GET: Activities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Activities.ToListAsync());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Id,Handle,Category,Description,Timestamp,Verified,Notes")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Update(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

                return View(await _context.Activities.ToListAsync());
        }



        // GET: Activities/Create
        public IActionResult AddOrEdit(int id = 0) 
        {
            if(id == 0)
            {
                return View(new Activity());
            }
            else
            {
                return View(_context.Activities.Find(id));
            }
                
            
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Handle,Category,Description,Timestamp,Verified,Notes")] Activity activity) 
        {
            if (ModelState.IsValid)
            {
                if(activity.Id == 0)
                {
                    _context.Add(activity);
                }
                else
                {
                    _context.Update(activity);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index)); 
                }

                _context.Add(activity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activity);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            var activity = await _context.Activities.FindAsync(id);
            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }


    }
}
