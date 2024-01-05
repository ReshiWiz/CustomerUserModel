using CustomerUserModel.Data;
using CustomerUserModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CustomerUserModel.Controllers
{
	public class CityController : Controller
	{
		private readonly ApplicationDbContext _context;
		public CityController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var cities = _context.Cities.Include(c => c.Country).ToList();
			return View(cities);
		}

		[HttpGet]
		public IActionResult Create()
		{
			ViewData["CountryList"] = new SelectList(_context.Countries, "Id", "Name");
			var city = new City();
			return View(city);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(City city)
		{
			if (ModelState.IsValid)
			{
				_context.Add(city);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewData["CountryList"] = new SelectList(_context.Countries, "Id", "Name", city.CountryId);
			return View(city);
		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var city = _context.Cities.Include(c => c.Country).FirstOrDefault(x => x.Id == id);

			if (city == null)
			{
				return NotFound();
			}

			ViewData["CountryList"] = new SelectList(_context.Countries, "Id", "Name", city.CountryId);
			return View(city);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(City city)
		{
			if (ModelState.IsValid)
			{
				_context.Update(city);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewData["CountryList"] = new SelectList(_context.Countries, "Id", "Name", city.CountryId);
			return View(city);
		}
		public IActionResult Details(int id)
		{
			var city = _context.Cities.Include(c => c.Country).FirstOrDefault(x => x.Id == id);
			return View(city);
		}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int id)
		{
			var city = _context.Cities.FirstOrDefault(x => x.Id == id);

			if (city == null)
			{
				return NotFound();
			}
			try
			{
				_context.Cities.Remove(city);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(city);
			}
			return RedirectToAction("Index");
		}

	}
}
