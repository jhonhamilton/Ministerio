using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ministerio.Droid;
using Ministerio.Interfaces;
using Xamarin.Forms;

[assembly:Dependency(typeof(MessageToast_Android))]
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