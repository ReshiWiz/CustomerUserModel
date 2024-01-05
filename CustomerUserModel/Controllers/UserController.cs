using CustomerUserModel.Data;
using CustomerUserModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CustomerUserModel.Controllers
{
	public class UserController : Controller
	{
		private readonly ApplicationDbContext _context;
		public UserController(ApplicationDbContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var userList = _context.Customers.Include(x => x.Country).Include(x => x
			.City).ToList();
			return View(userList);
		}

		public List<SelectListItem> GetUsers()
		{
			List<SelectListItem>? listOfUser = new List<SelectListItem>();
			List<Country>? countries = _context.Countries.ToList();
			listOfUser = countries.Select(x => new SelectListItem() { Text = x.CountryName.ToString(), Value = x.CountryName }).ToList();
			SelectListItem? dropDown = new SelectListItem() { Value = "", Text = "----select Country----" };
			listOfUser.Insert(0, dropDown);
			return listOfUser;
		}

		public List<SelectListItem> GetCities(int countryId = 1)
		{
			var listOfCities = _context.Cities.Where(x => x.Id == countryId).OrderBy(x => x.CityName).Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.CityName }).ToList();
			var dropDown = new SelectListItem() { Value = "", Text = "---Select City---" };
			listOfCities.Insert(0, dropDown);
			return listOfCities;
		}

		[HttpGet]
		public IActionResult Create()
		{
			var customer = new Customer();
			ViewBag.CountryList = GetUsers();
			ViewBag.CityList = GetCities();

			return View(customer);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Customer customer)
		{
			if (ModelState.IsValid)
			{
				_context.Add(customer);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.CountryList = GetUsers();
			ViewBag.CityList = GetCities(customer.CountryId);

			return View(customer);
		}

		[HttpGet]
		public JsonResult GetCitiesByCountry(int CountryId)
		{
			var cities = GetCities(CountryId);
			return Json(cities);
		}
	}
}
