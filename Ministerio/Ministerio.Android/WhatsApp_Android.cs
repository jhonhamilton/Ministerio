using Android.Content;
using Android.Content.PM;
using Android.App;
using Android.Widget;
using Android.OS;
using Ministerio.Interfaces;
using System;

namespace Ministerio.Droid
{
    //public class WhatsApp_Android : Activity, IWhatsApp
    public class WhatsApp_Android : IWhatsApp
    {
        public string EstadoMensaje;

        //protected override void OnCreate(Bundle bundle)
        //{
        //    base.OnCreate(bundle);
        //}

        bool VerificarWhatsApp(string uri)
        {
            try
            {
                Application.Context.PackageManager.GetPackageInfo(uri, PackageInfoFlags.Activities);
                //ApplicationContext.PackageManager.GetPackageInfo(uri, PackageInfoFlags.Activities);
                return true;
            }
            catch (PackageManager.NameNotFoundException e)
            {
                EstadoMensaje = e.Message;
                return false;
            }
        }

        public void OpenWhatsApp(string whatsapp)
        {
            if (VerificarWhatsApp(whatsapp))
            {
                Intent intent = new Intent();
                intent.SetAction(Intent.ActionSend);
                intent.PutExtra(Intent.ExtraText, whatsapp.ToString());
                intent.SetType("text/plain");
                intent.SetPackage("com.whatsapp");
                Application.Context.StartActivity(intent);
                //this.ApplicationContext.StartActivity(intent);
            }
            else
            {
                //Toast.MakeText(this, "WhatsApp no esta instalado. No se puede enviar mensajes");
                MessageToast_Android message = new MessageToast_Android();
                message.LongToast("WhatsApp no esta instalado. No se puede enviar mensajes");
            }            
        }
    }
}