using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Solution.Core.Interfaces;
using Solution.Core.Models;
using Solution.DataBase;
using Solution.Validators;
using System.Windows.Input;
using FluentValidation;

namespace Solution.DesktopApp.ViewModels;

public partial class CreateOrEditBillViewModel(
    AppDbContext dbContext,
    IBillService billService) : BillModel, IQueryAttributable
{
    #region life cycle commands
    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingkAsync);
    public IAsyncRelayCommand DisappearingCommand => new AsyncRelayCommand(OnDisappearingAsync);
    #endregion

    #region validation
    public ICommand ValidateCommand => new Command<string>(OnValidateAsync);
    #endregion

    #region event commands
    public IAsyncRelayCommand SubmitCommand => new AsyncRelayCommand(OnSubmitAsync);
    #endregion

    private BillModelValidator validator => new BillModelValidator(null);

    [ObservableProperty]
    private ValidationResult validationResult = new ValidationResult();

    private delegate Task ButtonActionDelagate();
    private ButtonActionDelagate asyncButtonAction;

    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private IList<ItemModel> items = [];
    
    private FileResult selectedFile = null;

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        await Task.Run(LoadItemsAsync);

        bool hasValue = query.TryGetValue("Bill", out object result);

        if(!hasValue)
        {
            asyncButtonAction = OnSaveAsync;
            Title = "Add new bill";
            return;
        }

        BillModel bill = result as BillModel;

        this.Id = bill.Id;
        this.BillNumber = bill.BillNumber;
        this.IssueDate = bill.IssueDate;

        asyncButtonAction = OnUpdateAsync;
        Title = "Update bill";
    }

    private async Task OnAppearingkAsync()
    {
    }

    private async Task OnDisappearingAsync()
    { }

    private async Task OnSubmitAsync() => await asyncButtonAction();

    private async Task OnSaveAsync()
    {
        this.ValidationResult = await validator.ValidateAsync(this);

        if (!ValidationResult.IsValid)
        {
            return;
        }

        var result = await billService.CreateAsync(this);
        var message = result.IsError ? result.FirstError.Description : "Bill saved.";
        var title = result.IsError ? "Error" : "Information";

        if (!result.IsError)
        {
            ClearForm();
        }

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }

    private async Task OnUpdateAsync()
    {
        this.ValidationResult = await validator.ValidateAsync(this);

        if (!ValidationResult.IsValid)
        {
            return;
        }

        var result = await billService.UpdateAsync(this);

        var message = result.IsError ? result.FirstError.Description : "Bill updated.";
        var title = result.IsError ? "Error" : "Information";

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }

    private async Task LoadItemsAsync()
    {
        Items = await dbContext.Items.AsNoTracking().OrderBy(x => x.Name)
                                                     .Select(x => new ItemModel(x))
                                                     .ToListAsync();
    }

    private void ClearForm()
    {
        this.IssueDate = DateTime.Now;
        this.BillNumber = null;
    }

    private async void OnValidateAsync(string propertyName)
    {
        var result = await validator.ValidateAsync(this, options => options.IncludeProperties(propertyName));

        ValidationResult.Errors.Remove(ValidationResult.Errors.FirstOrDefault(x => x.PropertyName == propertyName));

        ValidationResult.Errors.Remove(ValidationResult.Errors.FirstOrDefault(x => x.PropertyName == BillModelValidator.GlobalProperty));
        ValidationResult.Errors.AddRange(result.Errors);

        OnPropertyChanged(nameof(ValidationResult));
    }
}
