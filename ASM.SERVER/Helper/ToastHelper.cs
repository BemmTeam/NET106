using Microsoft.JSInterop;

namespace ASM.SERVER.Helper
{
    public class ToastHelper
    {
        private readonly IJSRuntime jsrunTime;

        public ToastHelper(IJSRuntime jsrunTime)
        {
            this.jsrunTime = jsrunTime;
        }

        public enum ToastType
        {
            success, info, warning, error, mail, time
        }


        public async void ShowSuccess(string message)
        {
            await jsrunTime.InvokeVoidAsync("toastApp", message, "success");
        }


        public async void ShowInfo(string message)
        {
            await jsrunTime.InvokeVoidAsync("toastApp", message, "info");
        }


        public async void ShowError(string message)
        {
            await jsrunTime.InvokeVoidAsync("toastApp", message, "error");
        }






    }
}
