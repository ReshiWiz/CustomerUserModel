//using CustomerUserModel.Data;
//using CustomerUserModel.Interface.JQueryInterfaceCrud;
//using CustomerUserModel.Models.JqueryCrudOps;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using System.Web.Mvc;

//namespace CustomerUserModel.Repositories
//{

//	public class CurrencyRepo : ICurrency
//	{
//		private string _errors;
//		private readonly ApplicationDbContext _context;
//		public CurrencyRepo(ApplicationDbContext context)
//		{
//			_context = context;
//		}
//		public bool Create(Currency currency)
//		{
//			try
//			{
//				_context.Currencies.Add(currency);
//				_context.SaveChanges();
//				return true;
//			}

//			catch (Exception ex)
//			{
//				_errors = "Sql Exception occurred" + " " + ex.Message;
//				return false;
//			}
//		}

//		public bool Delete(Currency currency)
//		{
//			//  _context.Currencies.
//			try
//			{
//				_context.Currencies.Attach(currency);
//				_context.Entry(currency).State = EntityState.Deleted;
//				_context.SaveChanges();
//				return true;
//			}
//			catch (Exception ex)
//			{
//				_errors = ex.Message;
//				return false;
//			}
//		}

//		public bool Edit(Currency currency)
//		{
//			try
//			{
//				_context.Currencies.Attach(currency);
//				_context.Entry(currency).State = EntityState.Modified;
//				_context.SaveChanges();
//				return true;
//			}
//			catch (Exception ex)
//			{
//				_errors = ex.Message;
//				return false;
//			}
//		}

//		public string GetErrors()
//		{
//			return _errors;
//		}

//		public Currency GetItem(int Id)
//		{
//			var item = _context.Currencies.Where(x => x.CurrencyId == Id).FirstOrDefault();
//			return item;
//		}
//		public List<Currency> GetItems(string sortProperty, SortOrder sortOrder, string searchText)
//		{
//			List<Currency> items;
//			if (searchText != "" && searchText != null)
//			{
//				items = _context.Currencies.Where(x => x.Name.Contains(searchText)).ToList();
//			}
//			else
//				items = _context.Currencies.ToList();
//			items = DoSort(items, sortProperty, sortOrder);
//			List<Currency> result = new List<Currency>();
//			return result;
//		}


//		public bool IsCurrencyComExists(int srcCurrencyId, int excCurrencyId)
//		{
//			throw new NotImplementedException();
//		}

//		public bool IsExist(string name)
//		{
//			throw new NotImplementedException();
//		}

//		public bool IsExist(string name, int id)
//		{
//			throw new NotImplementedException();
//		}

//		// sorting the List 

//		private List<Currency> DoSort(List<Currency> items, string sortProperty, SortOrder sortOrder)
//		{
//			if (sortProperty.ToLower() == "name")
//			{
//				if (sortOrder == SortOrder.Ascending)
//				{
//					items = items.OrderBy(x => x.Name).ToList();
//				}
//				else
//				{
//					items = items.OrderByDescending(x => x.Name).ToList();
//				}
//			}
//			else
//			{
//				if (sortOrder == SortOrder.Ascending)
//				{
//					items = items.OrderBy(x => x.Description).ToList();
//				}
//				else
//				{
//					items = items.OrderByDescending(x => x.Description).ToList();
//				}
//			}
//			return items;
//		}

//		// Is exist ;
//	}
//}
