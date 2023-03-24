using ASPCarModelBrands.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCarModelBrands.Controllers
{
    public class ModelBrandController : Controller
    {
        private readonly ApplicationContext _context;
        private static int idselected = 1;
        public ModelBrandController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult modelbrandlist()
        {
            ViewBag.brands = _context.brands.ToList();
            ViewBag.models = _context.models.Where(x => x.brandid == idselected).ToList();
            return View();
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadBrandModel(int brandidselected)
        {
            idselected = brandidselected;
            try
            {
                return RedirectToAction(nameof(modelbrandlist));
            }
            catch (DbUpdateException)
            {

            }
            return RedirectToAction(nameof(modelbrandlist));
        }
    }
}
