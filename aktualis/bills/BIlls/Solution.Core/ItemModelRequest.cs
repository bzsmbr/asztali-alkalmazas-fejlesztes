using Bills.Core.Models;
using Bills.Database.Entities;

namespace Bills.Core.DTO.Requests;

public partial class ItemModelRequest : ItemModel
{
    [JsonPropertyName("billId")]
    public int BillId { get; set; }

    public ItemEntity ToEntity()
    {
        return new ItemEntity
        {
            Id = this.Id,
            Name = this.Name,
            Price = this.Price,
            Amount = this.Amount,
            BillId = this.BillId
        };
    }
    public void ToEntity(ItemEntity entity)
    {
        entity.Id = this.Id;
        entity.Name = this.Name;
        entity.Price = this.Price;
        entity.Amount = this.Amount;
        entity.BillId = this.BillId;
    }
}
