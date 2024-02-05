using CustomerUserModel.Data;
using CustomerUserModel.Views.Cascade;
using Microsoft.AspNetCore.Mvc;

//namespace CustomerUserModel.Controllers.Cascade
//{
	//public class CascadeController : Controller
	//{
	//	private readonly ApplicationDbContext _context;
	//	public CascadeController(ApplicationDbContext context)
	//	{
	//		_context = context;
	//	}
	//	public IActionResult Index()
	//	{
	//		return View();
	//	}
	//	public IActionResult GetUserList()
	//	{
	//		var data = from user in _context.Users
	//				   join country in _context.Countries on user.CountryId equals country.CId
	//				   join state in _context.States on user.StateId equals state.SId
	//				   join city in _context.Cities on user.CityId equals city.CityId
	//				   select new UserCountryModelView
	//				   {
	//					   UserId = user.UserId,
	//					   Name = user.Name,
	//					   StateName = state.StateName,
	//					   CountryName = country.CountryName,
	//					   CityName = city.CityName
	//				   };

	//		return Json(data.ToList());
	//	}

	//	public IActionResult GetCountries()
	//	{
	//		var data = _context.Countries.ToList();
	//		return Json(data);
	//	}

	//	public IActionResult GetState(int countryId)
	//	{
	//		//var data = from state in _context.States where s select state;
	//		var data = _context.States.Where(x => x.Country.CId == countryId).ToList();
	//		return Json(data);
	//	}
	//	public IActionResult GetCity(int stateId)
	//	{
	//		var data = _context.Cities.Where(x => x.State.SId == stateId).ToList();
	//		return Json(data);
	//	}

//	}
//}
