namespace BookIt.Models;
public class Service {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Duration { get; set; } //Dakika olarak
    public Decimal Price { get; set; }
}