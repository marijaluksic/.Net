using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vjezba.DAL;
using Vjezba.Model;
using Vjezba.Web.Models;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;

namespace Vjezba.Web.Controllers
{
    public class ClientController : Microsoft.AspNetCore.Mvc.Controller
    {
        private ClientManagerDbContext _dbContext;

        public ClientController(ClientManagerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public ActionResult Index(ClientFilterModel filter)
        {
            filter ??= new ClientFilterModel();

            var clientQuery = this._dbContext.Clients.Include(p => p.City).OrderBy(p => p.ID).AsQueryable();

            //Primjer iterativnog građenja upita - dodaje se "where clause" samo u slučaju da je parametar doista proslijeđen.
            //To rezultira optimalnijim stablom izraza koje se kvalitetnije potencijalno prevodi u SQL
            if (!string.IsNullOrWhiteSpace(filter.FullName))
                clientQuery = clientQuery.Where(p => (p.FirstName + " " + p.LastName).ToLower().Contains(filter.FullName.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Address))
                clientQuery = clientQuery.Where(p => p.Address.ToLower().Contains(filter.Address.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Email))
                clientQuery = clientQuery.Where(p => p.Email.ToLower().Contains(filter.Email.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.City))
                clientQuery = clientQuery.Where(p => p.CityID != null && p.City.Name.ToLower().Contains(filter.City.ToLower()));

            var model = clientQuery.ToList();
            return View("Index", model);
        }

        public IActionResult Details(int? id = null)
        {
            var client = this._dbContext.Clients
                .Include(p => p.City)
                .Where(p => p.ID == id)
                .FirstOrDefault();

            return View(client);
        }

        public IActionResult Create()
        {
            FillDropDownValues();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Client model)
        {
            FillDropDownValues();
            if (ModelState.IsValid)
            {
                this._dbContext.Clients.Add(model);
                this._dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            FillDropDownValues();
            var client = this._dbContext.Clients.Include(p => p.City).Include(p => p.Meetings).FirstOrDefault(p => p.ID == id);



            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> EditPost(int id)
        {
            FillDropDownValues();
            var client = this._dbContext.Clients.Include(p => p.City).Include(p => p.Meetings).First(p => p.ID == id);

            client.CityID = 1;


            var ok = await this.TryUpdateModelAsync(client);

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
            selectItems.Add(listItem);

            foreach (var city in _dbContext.Cities)
            {
                listItem = new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem();
                listItem.Text = city.Name;
                listItem.Value = city.ID.ToString();
                selectItems.Add(listItem);
            }

            ViewBag.Cities = selectItems;

        }
    }
}
