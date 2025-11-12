using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Database.Entities;

[Table("Item")]
[Index(nameof(Name), IsUnique = true)]
public class ItemEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [StringLength(64)]
    [Required]
    public string Name { get; set; }

    [Required]
    public int UnitPrice { get; set; }

    [Required]
    public int Quantity { get; set; }

    public virtual ICollection<BillEntity> Bills { get; set; }
}
