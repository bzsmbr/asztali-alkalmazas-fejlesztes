namespace Solution.Core.Models;

public partial class PhoneModel: ObservableObject
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
    [JsonPropertyName("")]
    private TypeModel type;

    [ObservableProperty]
    [JsonPropertyName("model")]
    private string model;

    [ObservableProperty]
    private int? releaseYear;

    [ObservableProperty]
    [JsonPropertyName("storageInGB")]
    private int? storageInGB;

    public PhoneModel()
    {
    }

    public PhoneModel(PhoneEntity entity)
    {
        this.Id = entity.PublicId;
        this.ImageId = entity.ImageId;
        this.WebContentLink = entity.WebContentLink;
        this.Manufacturer = new ManufacturerModel(entity.Manufacturer);
        this.Type = new TypeModel(entity.Type);
        this.Model = entity.Model;
        this.ReleaseYear = entity.ReleaseYear;
        this.StorageInGB = entity.StorageInGB;
    }

    public PhoneEntity ToEntity()
    {
        return new PhoneEntity
        {
            ManufacturerId = Manufacturer.Id,
            TypeId = Type.Id,
            ImageId = ImageId,
            WebContentLink = WebContentLink,
            Model = Model,
            ReleaseYear = ReleaseYear.Value,
            StorageInGB = StorageInGB.Value
        };
    }

    public void ToEntity(PhoneEntity entity)
    {
        entity.PublicId = Id;
        entity.ManufacturerId = Manufacturer.Id;
        entity.TypeId = Type.Id;
        entity.ImageId = ImageId;
        entity.WebContentLink = WebContentLink;
        entity.Model = Model;
        entity.ReleaseYear = ReleaseYear.Value;
        entity.StorageInGB = StorageInGB.Value;
    }
}
