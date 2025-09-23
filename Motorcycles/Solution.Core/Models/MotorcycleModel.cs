namespace Solution.Core.Models;

public partial class MotorcycleModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    private string id;

    [ObservableProperty]
    [JsonPropertyName("imageId")]
    private string imageId;

    [ObservableProperty]
    [JsonPropertyName("webContentLink")]
    private string webContentLink;

    [ObservableProperty]
    [JsonPropertyName("manufacturer")]
    private ManufacturerModel manufacturer;
    
    [ObservableProperty]
    [JsonPropertyName("type")]
    private TypeModel type;
    
    [ObservableProperty]
    [JsonPropertyName("model")]
    private string model;
    
    [ObservableProperty]
    [JsonPropertyName("cubic")]
    private int cubic;
    
    [ObservableProperty]
    [JsonPropertyName("releaseYear")]
    private int releaseYear;
    
    [ObservableProperty]
    [JsonPropertyName("numberOfCylinders")]
    private int numberOfCylinders;

    public MotorcycleModel()
    {
        this.Manufacturer = new ManufacturerModel();
        this.Type = new TypeModel();
        this.Model = model;
        this.Cubic = cubic;
        this.ReleaseYear = releaseYear;
        this.NumberOfCylinders = numberOfCylinders;
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
            Cubic = Cubic,
            ReleaseYear = ReleaseYear,
            Cylinders = NumberOfCylinders
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
        entity.Cubic = Cubic;
        entity.ReleaseYear = ReleaseYear;
        entity.Cylinders = NumberOfCylinders;
    }
}
