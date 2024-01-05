using CustomerUserModel.Data;
using CustomerUserModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerUserModel.Controllers
{
	public class CustomerController : Controller
	{
		private readonly ApplicationDbContext _context;
		public CustomerController(ApplicationDbContext context)
		{
			_context = context;
		}

		// list the Customers
		public IActionResult Index()
		{
			return View();
		}

		public JsonResult GetCustomer()
		{
			var customers = _context.Customers.ToList();
			return Json(customers);
		}
		[HttpPost]
		public JsonResult Insert(Customer customer)
		{
			if (ModelState.IsValid)
			{
				_context.Customers.Add(customer);
				_context.SaveChanges();
				return Json("Customer details are saved");
			}
			var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
			return Json($"Model validation failed: {string.Join(", ", errors)}");
		}

		// Edit the Modal
		[HttpGet]
		public JsonResult Edit(int id)
		{
			var customer = _context.Customers.Find(id);
			return Json(customer);
		}

		// posting the method 
		[HttpPost]
		public JsonResult Update(Customer modal)
		{
			if (ModelState.IsValid)
			{
				_context.Customers.Update(modal);
				_context.SaveChanges();
				return Json("Customer details are updated");
			}
			return Json("Model validation failed");
		}
	}
}
