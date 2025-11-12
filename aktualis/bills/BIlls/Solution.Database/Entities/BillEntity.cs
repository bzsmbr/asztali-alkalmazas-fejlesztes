using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution.Database.Entities;

[Table("Bill")]
public class BillEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }


    [StringLength(20)]
    [Required]
    public string BillNumber { get; set; }

    [Required]
    public DateTime IssueDate { get; set; }

    [ForeignKey("Item")]
    public int ItemId { get; set; }

    public virtual BillEntity Item { get; set; }
}
