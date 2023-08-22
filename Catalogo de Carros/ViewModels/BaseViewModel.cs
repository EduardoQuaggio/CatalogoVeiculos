using Catalogo_de_Carros.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using Mopups.Services;
using System.Diagnostics;

namespace Catalogo_de_Carros.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private bool _isEmpty;

        public BaseViewModel() { }

        public async Task ShowLoading(string messageLoading = null)
        {
            try
            {
                var waitingPopup = new WaitingPopupPage();
                await MopupService.Instance.PushAsync(waitingPopup);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public async Task HideLoading()
        {
            try
            {
                await MopupService.Instance.PopAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

    }
}
