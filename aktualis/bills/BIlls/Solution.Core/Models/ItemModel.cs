namespace Solution.Core.Models;

public partial class ItemModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    private int id;

    [ObservableProperty]
    [JsonPropertyName("name")]
    private string name;

    [ObservableProperty]
    [JsonPropertyName("unitPrice")]
    private int unitPrice;

    [ObservableProperty]
    [JsonPropertyName("quantity")]
    private int quantity;


    public ItemModel()
    {
    }

    public ItemModel(ItemEntity entity)
    {
        this.Id = entity.Id;
        this.Name = entity.Name;
        this.UnitPrice = entity.UnitPrice;
        this.Quantity = entity.Quantity;
    }

    public ItemEntity ToEntity()
    {
        return new ItemEntity
        {
            Id = Id,
            Name = Name,
            UnitPrice = UnitPrice,
            Quantity = Quantity
        };
    }
}