using Microsoft.AspNetCore.Mvc;
using CustomerUserModel.Models;
using CustomerUserModel.Models.Udemy;
using CustomerUserModel.Data;
using PagedList;

namespace CustomerUserModel.Controllers.UdemyController
{
	public class AdminController : Controller
	{
		private readonly ApplicationDbContext _context;

		public AdminController(ApplicationDbContext context)
		{
			_context = context;
		}
		// GET : Admin // Login 
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		// POST : Admin // Login 

		[HttpPost]
		public IActionResult Index(Admin AInputs)
		{
			try
			{
				Admin admin = (from a in _context.Admins
							   where a.ad_userName == AInputs.ad_userName && a.ad_password == AInputs.ad_password
							   select a).SingleOrDefault();


				if (admin != null)
				{
					HttpContext.Session.SetString("admin_id", admin.ad_id.ToString());
					return RedirectToAction("ViewCategory");
				}
				else
				{
					ViewBag.error = "Invalid username or password";
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception: {ex.Message}");
				ViewBag.error = "An error occurred during login.";
			}

			return View();
		}

		// GET : Admin Register

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		// POST : Admin // Register
		[HttpPost]
		public IActionResult Register(Admin InputAdmin)
		{
			try
			{
				Admin existingAdmin = _context.Admins
					.FirstOrDefault(a => a.ad_userName == InputAdmin.ad_userName);

				if (existingAdmin != null)
				{
					ViewBag.error = "User name already exists";
				}
				else
				{
					_context.Admins.Add(InputAdmin); // Use Admin instead of User
					_context.SaveChanges();
					ViewBag.error = "Admin registered successfully";

				}
			}
			catch (Exception ex)
			{
				ViewBag.error = ex.Message.ToString();
			}

			return RedirectToAction("Index");
		}
		// GET : Admin // ViewCategory
		public IActionResult ViewCategory(int? page)
		{
			int pageSize = 8, pageIndex = 1;
			pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
			var list = _context.Categories.Where(x => x.Cat_Status == 1).OrderByDescending(x => x.Cat_Id).ToList();
			IPagedList<ViewCategory> pageList = list.ToPagedList(pageIndex, pageSize);
			return View(pageList);
		}
	}
}
