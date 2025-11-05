namespace Solution.Core.Models;

public partial class ManufacturerModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    private int id;

    [ObservableProperty]
    [JsonPropertyName("name")]
    private string name;

    public ManufacturerModel()
    {
    }

    public ManufacturerModel(ManufacturerEntity entity)
    {
        this.Id = entity.Id;
        this.Name = entity.Name;
    }

    public ManufacturerEntity ToEntity()
    {
        return new ManufacturerEntity
        {
            Id = Id,
            Name = Name
        };
    }

    public void ToEntity(ManufacturerEntity entity)
    {
        entity.Id = Id;
        entity.Name = Name;
    }
}