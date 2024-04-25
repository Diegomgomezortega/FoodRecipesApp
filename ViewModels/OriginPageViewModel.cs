using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FoodRecipesApp.Interfaces;
using FoodRecipesApp.Models;
using MvvmHelpers;
using System.Collections.ObjectModel;

namespace FoodRecipesApp.ViewModels
{
    public partial class OriginPageViewModel: CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public ObservableRangeCollection<Origin> OriginObjects { get; set; } = new();
        private readonly IOriginService _originServices;
        [ObservableProperty]
        private string title;
        [ObservableProperty]
        private Origin originObject;
        [ObservableProperty]
        private Origin selectedRowData;
        [ObservableProperty]
        private bool showPopup;
        //[ObservableProperty]
        //private string message;
        //[ObservableProperty]
        //private string messageBackgroundColor;
        [ObservableProperty]
        private string headerTitle;
        public OriginPageViewModel( IOriginService originService)
        {
            _originServices = originService;
            ShowPopup = false;
            
        }
        partial void OnSelectedRowDataChanged(Origin oldValue, Origin newValue)
        {
            if (oldValue != newValue)
                ManageSelectedData(newValue);
        }
        [RelayCommand]
        private void ShowMDialog()
        {
            HeaderTitle = "Add Origin";
            OriginObject= new Origin();
            ShowPopup = true;

        }

        [RelayCommand]
        private async Task SaveObject()
        {
            if (OriginObject == null) return;
            int result;
            if (OriginObject.Id > 0)
                result = await _originServices.UpdateAsync(OriginObject);
            else 
                result= await _originServices.AddAsync(OriginObject);
            if(result > 0)
            {
                await ToastModel.MakeToast("Process completed successfully");
                ShowPopup = false;
                OriginObject = new Origin();
                await LoadOrigins();
            }
        }

        [RelayCommand]
        private async Task LoadOrigins()
        {
            var result= await _originServices.GetAllAsync();
            if (OriginObjects.Count > 0) OriginObjects.Clear();
            if (result.Count > 0) OriginObjects.ReplaceRange(result.OrderByDescending(x => x.Id));

            
        }
        private async Task ManageSelectedData(Origin selectedOriginModel)
        {
            if (selectedOriginModel is null) return;
            string action = await Shell.Current.DisplayActionSheet("Action: Choose an option", "Cancel", null, "Edit", "Delete");
            if (string.IsNullOrEmpty(action)|| string.IsNullOrWhiteSpace(action)) return;
            if (action.Equals("Cancel")) return;
            if (action.Equals("Edit"))
            {
                OriginObject = new Origin()
                {
                    Id = selectedOriginModel.Id,
                    Name= selectedOriginModel.Name,
                };
                HeaderTitle = "Update Origin";
                ShowPopup = true;
            }
            if(action.Equals("Delete"))
            {
                bool answer = await Shell.Current.DisplayAlert("Confirm Operation", "Are you sure you wanna do this?", "Yes", "No");
                if (!answer) return;

                int result = await _originServices.DeleteAsync(selectedOriginModel);
                if(result > 0)
                {
                    await ToastModel.MakeToast("Origin deleted succesfully");
                    await LoadOrigins();
                    selectedOriginModel = new Origin();
                    return;
                }
                await Shell.Current.DisplayAlert("Alert", "Error occured", "Ok");
                return;
            }

        }
    }
    
}
