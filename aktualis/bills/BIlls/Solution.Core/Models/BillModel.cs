using Bills.Database.Entities;
using System.Collections.ObjectModel;

namespace Bills.Core.Models;
public partial class BillModel : ObservableObject
{
    [ObservableProperty]
    [JsonPropertyName("id")]
    private int id;

    [ObservableProperty]
    [JsonPropertyName("number")]
    private string number;

    [ObservableProperty]
    [JsonPropertyName("date")]
    private DateTime date = DateTime.Now;

    [ObservableProperty]
    [JsonPropertyName("items")]
    private ObservableCollection<ItemModel>? items;

    public double? Total => Items?.Sum(x => x.Total);

    public BillModel()
    {
        this.Id = id;
        this.Number = number;
        this.Date = date;
        this.Items = items;
    }

    public BillModel(BillEntity entity)
    {
        this.Id = entity.Id;
        this.Number = entity.Number;
        this.Date = entity.Date;
        this.Items = new ObservableCollection<ItemModel>(
            entity.Items?.Select(x => new ItemModel(x))
        );
    }

    public BillEntity ToEntity()
    {
        return new BillEntity
        {
            Id = this.Id,
            Number = this.Number,
            Date = this.Date,
            Items = this.Items?.Select(x => x.ToEntity()).ToList()
        };
    }

    public void ToEntity(BillEntity entity)
    {
        entity.Id = this.Id;
        entity.Number = this.Number;
        entity.Date = this.Date;
        entity.Items = this.Items?.Select(x => x.ToEntity()) as ICollection<ItemEntity>;
    }
}
