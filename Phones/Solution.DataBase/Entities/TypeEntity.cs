namespace Solution.Database.Entities;

[Table("Type")]
[Index(nameof(Name), IsUnique = true)]
public class TypeEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(64)]
    [Required]
    public string Name { get; set; }

    public virtual ICollection<PhoneEntity> Phones { get; set; }
}
