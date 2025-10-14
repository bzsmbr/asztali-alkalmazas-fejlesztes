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

    public TypeModel(TypeEntity entity)
    {
        this.Id = entity.Id;
        this.Name = entity.Name;
    }

    public TypeEntity ToEntity()
    {
        return new TypeEntity
        {
            Id = Id,
            Name = Name
        };
    }

    public void ToEntity(TypeEntity entity)
    {
        entity.Id = Id;
        entity.Name = Name;
    }

    public override bool Equals(object? obj)
    {
        return obj is TypeModel model &&
               this.Id == model.Id &&
               this.Name == model.Name;
    }
}