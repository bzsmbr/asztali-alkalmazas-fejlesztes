namespace Solution.Core.Models;

public partial class TypeModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    private int id;

    [ObservableProperty]
    [JsonPropertyName("name")]
    private string name;

    public TypeModel()
    {
    }

    public TypeModel(MotorcycleTypeEntity entity)
    {
        this.Id = entity.Id;
        this.Name = entity.Name;
    }

    public MotorcycleTypeEntity ToEntity()
    {
        return new MotorcycleTypeEntity
        {
            Id = Id,
            Name = Name
        };
    }

    public void ToEntity(MotorcycleTypeEntity entity)
    {
        entity.Id = Id;
        entity.Name = Name;
    }
}