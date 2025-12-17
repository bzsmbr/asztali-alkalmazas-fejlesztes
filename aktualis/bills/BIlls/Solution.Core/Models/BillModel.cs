using System.Collections.ObjectModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
    [JsonPropertyName("items")]
    private ObservableCollection<ItemModel>? items;

    public BillModel()
    {
        this.Id = id;
        this.billNumber = BillNumber;
        this.issueDate = IssueDate;
        this.Items = items;
    }

    public BillModel(BillEntity entity)
    {
        this.Id = entity.Id;
        this.billNumber = entity.BillNumber;
        this.issueDate = entity.IssueDate;
        this.Items = new ObservableCollection<ItemModel>(
                entity.Items?.Select(x => new ItemModel(x))
        );
    }

    public BillEntity ToEntity()
    {
        return new BillEntity
        {
            Id = Id,
            BillNumber = BillNumber,
            IssueDate = IssueDate,
            Items = this.Items?.Select(x => x.ToEntity()).ToList()
        };
    }

    public void ToEntity(BillEntity entity)
    {
        entity.Id = Id;
        entity.BillNumber = BillNumber;
        entity.IssueDate = IssueDate;
        entity.Items = this.Items?.Select(x => x.ToEntity()) as ICollection<ItemEntity>;
    }
}
