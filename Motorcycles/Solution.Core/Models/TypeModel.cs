

namespace Solution.Core.Models;

public partial class TypeModel: ObservableObject
{
    [ObservableProperty]
    private int id;

    [ObservableProperty]
    private string name;

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
}
