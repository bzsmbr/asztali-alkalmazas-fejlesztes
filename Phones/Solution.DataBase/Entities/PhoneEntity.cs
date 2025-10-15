namespace Solution.Database.Entities;

[Table("Phone")]
public class PhoneEntity
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(128)]
    [Required]
    public string PublicId { get; set; }

    [StringLength(128)]
    public string? ImageId { get; set; }

    [StringLength(512)]
    public string? WebContentLink { get; set; }

    [StringLength(128)]
    [Required]
    public string Model {  get; set; }

    [Required]
    public int ReleaseYear { get; set; }

    [Required]
    public int? StorageInGB { get; set; }

    [ForeignKey("Manufacturer")]
    public int ManufacturerId { get; set; }
    public virtual ManufacturerEntity Manufacturer { get; set; }

    [ForeignKey("Type")]
    public int TypeId { get; set; }

    public virtual TypeEntity Type { get; set; }
}
