namespace ApiPractise.Models;

public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<Category> Categories { get; set; }
    public ICollection<Owner> Owners { get; set; }
}