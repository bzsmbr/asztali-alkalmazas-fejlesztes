using System.Numerics;

namespace Bills.Core.Models;
public partial class ItemModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    private int id;

    [ObservableProperty]
    [JsonPropertyName("name")]
    private string name;

    [ObservableProperty]
    [JsonPropertyName("price")]
    private double price;

    [ObservableProperty]
    [JsonPropertyName("amount")]
    private int amount;

    public double Total => Amount * Price;
    
    public Guid TempId { get; set; } = Guid.NewGuid();
    
    public ItemModel()
    {
        this.Id = id;
        this.Name = name;
        this.Price = price;
        this.Amount = amount;
    }

    public ItemModel(ItemEntity entity)
    {
        this.Id = entity.Id;
        this.Name = entity.Name;
        this.Price = entity.Price;
        this.Amount = entity.Amount;
    }

    public ItemEntity ToEntity()
    {
        return new ItemEntity
        {
            Id = this.Id,
            Name = this.Name,
            Price = this.Price,
            Amount = this.Amount
        };
    }

    public void ToEntity(ItemEntity entity)
    {
        entity.Id = this.Id;
        entity.Name = this.Name;
        entity.Price = this.Price;
        entity.Amount = this.Amount;
    }

    partial void OnAmountChanged(int oldValue, int newValue)
    {
        OnPropertyChanged(nameof(Total));
    }

    partial void OnPriceChanged(double oldValue, double newValue)
    {
        OnPropertyChanged(nameof(Total));
    }
}
