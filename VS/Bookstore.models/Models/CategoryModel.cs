using Bookstore.models.ViewModels;

namespace Bookstore.models.Models
{
    public class CategoryModel
    {
        public CategoryModel(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
