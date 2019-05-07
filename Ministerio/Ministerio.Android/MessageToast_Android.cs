using Android.Widget;
using Ministerio.Droid;
using Ministerio.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(MessageToast_Android))]
namespace Ministerio.Droid
{
    public class MessageToast_Android : IMessage
    {
        public void LongToast(string mensaje)
        {
            Toast.MakeText(Android.App.Application.Context, mensaje, ToastLength.Long).Show();
        }

        public void ShortToast(string mensaje)
        {
            Toast.MakeText(Android.App.Application.Context, mensaje, ToastLength.Short).Show();
        }
    }
}