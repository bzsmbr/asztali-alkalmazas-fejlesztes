using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Solution.Core.Models;

public partial class TypeModel : ObservableObject
{
    [ObservableProperty]
    private int id;

    [ObservableProperty]
    public string name;

    public TypeModel()
    {
    }

    public TypeModel(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public TypeModel(MotorcycleTypeEntity entity)
    {
        if (entity is null)
        {
            return;
        }

        Id = entity.Id;
        Name = entity.Name;
    }
    public MotorcycleTypeEntity ToEntity()
    {
        return new MotorcycleTypeEntity
        {
            Name = Name,
            Id = Id
        };
    }

    public void ToEntity(MotorcycleTypeEntity entity)
    {
        entity.Name = Name;
        entity.Id = Id;
    }
}