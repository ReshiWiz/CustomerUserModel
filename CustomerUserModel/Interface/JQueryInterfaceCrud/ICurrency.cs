using CustomerUserModel.Models.JqueryCrudOps;

namespace CustomerUserModel.Interface.JQueryInterfaceCrud
{
	public interface ICurrency
	{
		Currency GetItem(int Id);
		bool Create(Currency currency);
		bool Edit(Currency currency);
		bool Delete(Currency currency);
		public bool IsExist(string name);
		public bool IsExist(string name, int id);
		public bool IsCurrencyComExists(int srcCurrencyId, int excCurrencyId);
		public string GetErrors();
	}
}
