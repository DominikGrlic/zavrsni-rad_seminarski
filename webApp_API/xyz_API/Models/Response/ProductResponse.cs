namespace xyz_API.Models.Response;

public class ProductResponse
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public int InStock { get; set; }

    public decimal Price { get; set; }

    public string? Image { get; set; }
}