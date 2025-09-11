namespace Solution.Core.Models;

public partial class MotorcycleModel : ObservableObject
{
    [ObservableProperty]
    private string id;

    [ObservableProperty]
    private string imageId;

    [ObservableProperty]
    private string webContentLink;

    [ObservableProperty]
    private ManufacturerModel manufacturer;

    [ObservableProperty]
    private TypeModel type;

    [ObservableProperty]
    private string model;

    [ObservableProperty]
    private int? cubic;

    [ObservableProperty]
    private int? releaseYear;

    [ObservableProperty]
    private int? numberOfCylinders;

    public MotorcycleModel()
    {
    }

    public MotorcycleModel(MotorcycleEntity entity)
    {
        this.Id = entity.PublicId;
        this.ImageId = entity.ImageId;
        this.WebContentLink = entity.WebContentLink;
        this.Manufacturer = new ManufacturerModel(entity.Manufacturer);
        this.Type = new TypeModel(entity.Type);
        this.Model = entity.Model;
        this.Cubic = entity.Cubic;
        this.ReleaseYear = entity.ReleaseYear;
        this.NumberOfCylinders = entity.Cylinders;
    }

    public MotorcycleEntity ToEntity()
    {
        return new MotorcycleEntity
        {
            PublicId = Id,
            ManufacturerId = Manufacturer.Id,
            TypeId = Type.Id,
            ImageId = ImageId,
            WebContentLink = WebContentLink,
            Model = Model,
            Cubic = Cubic.Value,
            ReleaseYear = ReleaseYear.Value,
            Cylinders = NumberOfCylinders.Value
        };
    }

    public void ToEntity(MotorcycleEntity entity)
    {
        entity.PublicId = Id;
        entity.ManufacturerId = Manufacturer.Id;
        entity.TypeId = Type.Id;
        entity.ImageId = ImageId;
        entity.WebContentLink = WebContentLink;
        entity.Model = Model;
        entity.Cubic = Cubic.Value;
        entity.ReleaseYear = ReleaseYear.Value;
        entity.Cylinders = NumberOfCylinders.Value;
    }
}
