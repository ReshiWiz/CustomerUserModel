//using CustomerUserModel.Data;
//using CustomerUserModel.Models.TodoList;
//using Microsoft.AspNetCore.Mvc;

//namespace CustomerUserModel.Controllers.TodoList
//{
//	public class TodoListController : Controller
//	{
//		// dummy data using list to store values
//		List<TodoModel> todoList = new List<TodoModel>();

//		// data from backend SQL
//		private readonly ApplicationDbContext _context;
//		public TodoListController(ApplicationDbContext context)
//		{
//			_context = context;
//		}
//		public IActionResult Index()
//		{
//			return View();
//		}
//		public IActionResult FetcherTodos()
//		{
//			var items = _context.Todos.ToList();
//			return Json(items);
//		}

//		[HttpPost]
//		public IActionResult AddTodo(TodoModel model)
//		{
//			if (ModelState.IsValid)
//			{
//				_context.Todos.Add(model);
//				_context.SaveChanges();
//			}
//			return RedirectToAction("Index");
//		}
//		[HttpPost]
//		public IActionResult DeleteTodo(int id)
//		{
//			var deletedModel = _context.Todos.Where(x => x.Id == id).FirstOrDefault();
//			var todoToRemove = _context.Todos.Find(id);
//			if (todoToRemove != null)
//			{
//				_context.Todos.Remove(todoToRemove);
//				_context.SaveChanges();
//			}
//			return RedirectToAction("Index");
//		}
//	}
//}
