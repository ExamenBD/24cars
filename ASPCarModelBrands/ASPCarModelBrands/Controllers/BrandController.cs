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
    public class BrandController : Controller
    {
        private readonly ApplicationContext _context;
        public BrandController(ApplicationContext context)
        {
            _context = context;
            
        }
        public IActionResult brandlist()
        {
            ViewBag.brand = _context.brands.ToList();
            return View();
        }

        public IActionResult edittest(Brand brand)
        {
            _context.Remove(brand);
            _context.SaveChanges();
            return brandlist();
        }

        public async Task editbrandlisttest(int id)
        {
            Brand brand = _context.brands.FirstOrDefault(x => x.id == id);
            string form = $@"<form method='post' asp-controller='Brand' asp-action='testform'>
                <p><input name='idbrand' value='{brand.id}'/></p>
                <p><input name='namesbrand' value='{brand.name}'/></p>
                <p><input name='brandactive' value='{brand.active}'/></p>
                <input type='submit' value='Send' />
            </form>";
            Response.ContentType = "text/html;charset=utf-8";
            await Response.WriteAsync(form);
        }
        /*[HttpPost]
        public string Index(string[] names)
        {
            string result = "";
            foreach (string name in names)
            {
                result = $"{result} {name}";
            }
            return result;
        }*/

        [HttpPost]
        public IActionResult testform(int idbrand, string namesbrand, bool brandactive)
        {
            if (idbrand != null && namesbrand != null && brandactive != null)
            {
                Brand brand = _context.brands.FirstOrDefault(x => x.id == idbrand);
                _context.brands.Remove(brand);
                _context.brands.Add(new Brand
                {
                    id = idbrand,
                    name = namesbrand,
                    active = brandactive,

                });
                try
                {
                    _context.SaveChanges();
                    return RedirectToAction(nameof(brandlist));
                }
                catch (DbUpdateException)
                {

                }
            }
            return RedirectToAction(nameof(brandlist));
        }




        [HttpPost]
        public IActionResult brandlistadd(string namebrand, bool active)
        {
            if (namebrand != null && active != null)
            { 
                _context.brands.Add(new Brand
                {
                    id = _context.brands.Count() + 1,
                    name = namebrand,
                    active = active,

                });
            }
            try
            {
                _context.SaveChanges();
                return RedirectToAction(nameof(brandlist));
            }
            catch (DbUpdateException)
            {

            }
            return RedirectToAction(nameof(brandlist));
        }

        public IActionResult editbrandlist(int brandid, string namebrand, bool active)
        {
            if (brandid != null && namebrand != null && active != null)
            {
                Brand brand = _context.brands.FirstOrDefault(x => x.id == brandid);
                _context.brands.Remove(brand);
                _context.brands.Add(new Brand
                {
                    id = brandid,
                    name = namebrand,
                    active = active,

                });
                try
                {
                    _context.SaveChanges();
                    return RedirectToAction(nameof(brandlist));
                }
                catch (DbUpdateException)
                {

                }
            }
            return RedirectToAction(nameof(brandlist));
        }




        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
