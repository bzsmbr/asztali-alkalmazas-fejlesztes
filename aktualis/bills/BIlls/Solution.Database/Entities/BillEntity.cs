using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bills.Database.Entities;

[Table("Bill")]
public class BillEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Number { get; set; }

    [Required]
    public DateTime Date { get; set; }

    //Items
    public virtual ICollection<ItemEntity> Items { get; set; }

}
