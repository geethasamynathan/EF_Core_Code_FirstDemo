using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EF_Core_Code_FirstDemo.DTO;
using EF_Core_Code_FirstDemo.Models;

namespace EF_Core_Code_FirstDemo.Controllers
{
    public class DepartmentDTOesController : Controller
    {
        private readonly MyDbContext _context;

        public DepartmentDTOesController(MyDbContext context)
        {
            _context = context;
        }

        // GET: DepartmentDTOes
        public async Task<IActionResult> Index()
        {
           
            return View(await _context.Departments.ToListAsync());
        }

        // GET: DepartmentDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentDTO = await _context.DepartmentDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentDTO == null)
            {
                return NotFound();
            }

            return View(departmentDTO);
        }

        // GET: DepartmentDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DepartmentDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DepartmentName,Location")] DepartmentDTO departmentDTO)
        {
            Department department = new Department()
            {
                Id = departmentDTO.Id,
                DepartmentName = departmentDTO.DepartmentName,
                Location = departmentDTO.Location
            };

            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departmentDTO);
        }

        // GET: DepartmentDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentDTO = await _context.Departments.FindAsync(id);
            if (departmentDTO == null)
            {
                return NotFound();
            }
            return View(departmentDTO);
        }

        // POST: DepartmentDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DepartmentName,Location")] DepartmentDTO departmentDTO)
        {
            Department department = new Department()
            {
                Id = departmentDTO.Id,
                DepartmentName = departmentDTO.DepartmentName,
                Location = departmentDTO.Location
            };

            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentDTOExists(department.Id))
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
            return View(department);
        }

        // GET: DepartmentDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
           

            if (id == null)
            {
                return NotFound();
            }

            var departmentDTO = await _context.Departments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentDTO == null)
            {
                return NotFound();
            }

            return View(departmentDTO);
        }

        // POST: DepartmentDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmentDTO = await _context.Departments.FindAsync(id);
            if (departmentDTO != null)
            {
                _context.Departments.Remove(departmentDTO);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentDTOExists(int id)
        {
            return _context.DepartmentDTO.Any(e => e.Id == id);
        }
    }
}
