namespace Bills.Database.Entities;

[Table("Item")]
public class ItemEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(64)]
    public string Name { get; set; }

    [Required]
    public double Price { get; set; }

    [Required]
    public int Amount { get; set; }

    //Bills fk
    [Required]
    [ForeignKey("Bill")]
    public int BillId { get; set; }
    public virtual BillEntity Bill { get; set; }
}
