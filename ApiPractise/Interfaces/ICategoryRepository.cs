using ApiPractise.Models;

namespace ApiPractise.Interfaces;

public interface ICategoryRepository
{
    ICollection<Category> GetCategories();
    Category GetCategoryById(int id);
    ICollection<Pokemon> GetPokemonByCategory(int categoryId);
    bool CategoryExists(int id);
    bool CreateCategory(Category category);
    bool Save();
}