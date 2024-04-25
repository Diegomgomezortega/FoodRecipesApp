using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;

namespace FoodRecipesApp.Models
{
    public class ToastModel
    {
        public static async Task MakeToast(string message)
        {
            CancellationTokenSource cancellationTokenSource= new CancellationTokenSource();
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;
            var toast = Toast.Make(message,duration,fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
    }
}
