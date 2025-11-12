namespace Solution.Core.Models;

public partial class BillModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    private int id;

    [ObservableProperty]
    [JsonPropertyName("billNumber")]
    private string billNumber;

    [ObservableProperty]
    [JsonPropertyName("issueDate")]
    private DateTime issueDate;

    [ObservableProperty]
    [JsonPropertyName("")]
    private ItemModel item;

    public BillModel()
    {
    }

    public BillModel(BillEntity entity)
    {
        this.Id = entity.Id;
        this.billNumber = entity.BillNumber;
        this.issueDate = entity.IssueDate;
    }

    public BillEntity ToEntity()
    {
        return new BillEntity
        {
            Id = Id,
            BillNumber = BillNumber,
            IssueDate = IssueDate,
            ItemId = Item.Id,
        };
    }

    public void ToEntity(BillEntity entity)
    {
        entity.Id = Id;
        entity.BillNumber = BillNumber;
        entity.IssueDate = IssueDate;
        entity.ItemId = Item.Id;
    }
}
