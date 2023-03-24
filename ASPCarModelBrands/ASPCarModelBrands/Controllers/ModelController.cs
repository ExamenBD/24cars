using ASPCarModelBrands.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCarModelBrands.Controllers
{
    public class ModelController : Controller
    {
        private readonly ApplicationContext _context;
        public ModelController(ApplicationContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult modellistSave(int brandid, string namemodel, bool active, Brand brand)
        {
            if (brandid != null && namemodel != null && active != null)
            {
                _context.models.Add(new Model
                {
                    id = _context.models.Count() + 1,
                    brandid = brandid,
                    name = namemodel,
                    active = active,

                });
            }
            try
            {
                _context.SaveChanges();
                return RedirectToAction(nameof(modellist));
            }
            catch (DbUpdateException)
            {

            }
            return RedirectToAction(nameof(modellist));
        }
        
        public IActionResult modellist()
        {
            ViewBag.brand = _context.brands.ToList();
            ViewBag.model = _context.models.ToList();
            return View();
        }

        public IActionResult editmodellist(int modelid,int brandid,string namemodel,bool active)
        {
            if (modelid != null && brandid != null && namemodel !=null && active != null)
            {
                Model model = _context.models.FirstOrDefault(x => x.id == modelid);
                _context.models.Remove(model);
                _context.models.Add(new Model
                {
                    id = modelid,
                    brandid = brandid,
                    name = namemodel,
                    active = active,
                });
                try
                {
                    _context.SaveChanges();
                    return RedirectToAction(nameof(modellist));
                }
                catch (DbUpdateException)
                {

                }
            }
            return RedirectToAction(nameof(modellist));
        }
    }
}
