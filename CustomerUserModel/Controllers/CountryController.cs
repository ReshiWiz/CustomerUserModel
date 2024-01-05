using CustomerUserModel.Data;
using CustomerUserModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerUserModel.Controllers
{
	public class CountryController : Controller
	{
		private readonly ApplicationDbContext _context;
		public CountryController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var countries = _context.Countries.ToList();
			return View(countries);
		}
		[HttpGet]
		public IActionResult Create()
		{
			var country = new Country();
			return View(country);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Country country)
		{
			_context.Add(country);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Details(int id)
		{
			var country = _context.Countries.FirstOrDefault(x => x.Id == id);
			return View(country);
		}
		[HttpGet]
		public IActionResult Edit(int Id)
		{
			var country = _context.Countries.FirstOrDefault(x => x.Id == Id);
			return View(country);
		}

		public IActionResult Edit(Country country)
		{
			_context.Update(country);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Delete(Country country)
		{
			_context.Attach(country);
			_context.Entry(country).State = EntityState.Deleted;
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
