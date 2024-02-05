using System.ComponentModel.DataAnnotations;

namespace CustomerUserModel.Models.TodoList
{
	public class TodoModel
	{
		[Key]
		public int Id { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public bool IsActive { get; set; }
	}
}
