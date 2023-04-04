using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZavrsniLuksic.DAL;
using ZavrsniLuksic.Model;
using ZavrsniLuksic.Web.Models;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZavrsniLuksic.Models;

namespace ZavrsniLuksic.Web.Controllers
{
    public class PaprichicaController : Microsoft.AspNetCore.Mvc.Controller
    {
        private PaprichicaManagerDbContext _dbContext;

        public PaprichicaController(PaprichicaManagerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public ActionResult Index(PaprichicaFilterModel filter)
        {
            filter ??= new PaprichicaFilterModel();

            var paprichicaQuery = this._dbContext.Dishes.Include(p => p.Restaurant).Include(p => p.Spiciness).OrderBy(p => p.ID).AsQueryable();


            //Primjer iterativnog građenja upita - dodaje se "where clause" samo u slučaju da je parametar doista proslijeđen.
            //To rezultira optimalnijim stablom izraza koje se kvalitetnije potencijalno prevodi u SQL
            if (!string.IsNullOrWhiteSpace(filter.Name))
                paprichicaQuery = paprichicaQuery.Where(p => p.Name.ToLower().Contains(filter.Name.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Spiciness))
                paprichicaQuery = paprichicaQuery.Where(p => p.SpicinessID != null && p.Spiciness.Level.ToLower().Contains(filter.Spiciness.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Restaurant))
                paprichicaQuery = paprichicaQuery.Where(p => p.RestaurantID != null && p.Restaurant.Name.ToLower().Contains(filter.Restaurant.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Price))
                paprichicaQuery = paprichicaQuery.Where(p => p.Price.Contains(filter.Price));

            var model = paprichicaQuery.ToList();
            return View("Index", model);
        }

        public IActionResult Details(int? id = null)
        {
            var paprichica = this._dbContext.Dishes
                .Include(p => p.Restaurant)
                .Where(p => p.ID == id)
                .Include(p => p.Spiciness)
                .Where(p => p.ID == id)
                .FirstOrDefault();

            return View(paprichica);
        }

        public IActionResult Create()
        {
            FillDropDownValues();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Dish model)
        {
            FillDropDownValues();
            if (ModelState.IsValid)
            {
                this._dbContext.Dishes.Add(model);
                this._dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            FillDropDownValues();
            var paprichica = this._dbContext.Dishes.Include(p => p.Restaurant).Include(p => p.Spiciness).FirstOrDefault(p => p.ID == id);



            if (paprichica == null)
            {
                return NotFound();
            }

            return View(paprichica);
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> EditPost(int id)
        {
            FillDropDownValues();
            var paprichica = this._dbContext.Dishes.Include(p => p.Restaurant).Include(p => p.Spiciness).First(p => p.ID == id);

            paprichica.SpicinessID = 1;


            var ok = await this.TryUpdateModelAsync(paprichica);

            if (ok)
            {
                this._dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }



            return View();
        }

        public void FillDropDownValues()
        {
            var selectItems = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();

            var listItem = new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem();
            listItem.Text = "Odaberite ---";
            listItem.Value = "";
            listItem.Disabled = true;
            listItem.Selected = true;
            selectItems.Add(listItem);

            foreach (var paprichica in _dbContext.Restaurants)
            {
                listItem = new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem();
                listItem.Text = paprichica.Name;
                listItem.Value = paprichica.ID.ToString();
                selectItems.Add(listItem);
            }

            ViewBag.Restaurants = selectItems;

            var select1Items = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();

            var list1Item = new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem();
            list1Item.Text = "Odaberite ---";
            list1Item.Value = "";
            list1Item.Disabled = true;
            list1Item.Selected = true;
            select1Items.Add(list1Item);

            foreach (var paprichica in _dbContext.Spicinesses)
            {
                list1Item = new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem();
                list1Item.Text = paprichica.Level;
                list1Item.Value = paprichica.ID.ToString();
                select1Items.Add(list1Item);
            }

            ViewBag.Spicinesses = select1Items;

        }







        public ActionResult Index1(PaprichicaFilter1Model filter)
        {
            filter ??= new PaprichicaFilter1Model();

            var paprichicaQuery = this._dbContext.Restaurants.Include(p => p.Cuisine).OrderBy(p => p.ID).AsQueryable();


            //Primjer iterativnog građenja upita - dodaje se "where clause" samo u slučaju da je parametar doista proslijeđen.
            //To rezultira optimalnijim stablom izraza koje se kvalitetnije potencijalno prevodi u SQL
            if (!string.IsNullOrWhiteSpace(filter.Name))
                paprichicaQuery = paprichicaQuery.Where(p => p.Name.ToLower().Contains(filter.Name.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Cuisine))
                paprichicaQuery = paprichicaQuery.Where(p => p.CuisineID != null && p.Cuisine.Name.ToLower().Contains(filter.Cuisine.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Address))
                paprichicaQuery = paprichicaQuery.Where(p => p.Address.ToLower().Contains(filter.Address.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.PhoneNumber))
                paprichicaQuery = paprichicaQuery.Where(p => p.PhoneNumber.Contains(filter.PhoneNumber));

            var model = paprichicaQuery.ToList();
            return View("Index1", model);
        }

        public IActionResult Details1(int? id = null)
        {
            var paprichica = this._dbContext.Restaurants
                .Include(p => p.Cuisine)
                .Where(p => p.ID == id)
                .FirstOrDefault();

            return View("Details1", paprichica);
        }

        public IActionResult Create1()
        {
            FillDropDownValues1();
            return View("Create1");
        }

        [HttpPost]
        public IActionResult Create1(Restaurant model)
        {
            FillDropDownValues1();
            if (ModelState.IsValid)
            {
                this._dbContext.Restaurants.Add(model);
                this._dbContext.SaveChanges();

                return RedirectToAction(nameof(Index1));
            }

            return View("Create1", model);
        }

        public IActionResult Edit1(int id)
        {
            FillDropDownValues1();
            var paprichica = this._dbContext.Restaurants.Include(p => p.Cuisine).FirstOrDefault(p => p.ID == id);



            if (paprichica == null)
            {
                return NotFound();
            }

            return View("Edit1", paprichica);
        }

        [HttpPost]
        [ActionName("Edit1")]
        public async Task<IActionResult> EditPost1(int id)
        {
            FillDropDownValues1();
            var paprichica = this._dbContext.Restaurants.Include(p => p.Cuisine).First(p => p.ID == id);

            paprichica.CuisineID = 1;


            var ok = await this.TryUpdateModelAsync(paprichica);

            if (ok)
            {
                this._dbContext.SaveChanges();
                return RedirectToAction(nameof(Index1));
            }



            return View();
        }

        public void FillDropDownValues1()
        {
            var selectItems = new List<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>();

            var listItem = new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem();
            listItem.Text = "Odaberite ---";
            listItem.Value = "";
            listItem.Disabled = true;
            listItem.Selected = true;
            selectItems.Add(listItem);

            foreach (var paprichica in _dbContext.Cuisines)
            {
                listItem = new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem();
                listItem.Text = paprichica.Name;
                listItem.Value = paprichica.ID.ToString();
                selectItems.Add(listItem);
            }

            ViewBag.Cuisines = selectItems;

        }
    }
}
