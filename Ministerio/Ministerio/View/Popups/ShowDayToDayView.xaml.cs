using Rg.Plugins.Popup.Pages;
using System;
using Xamarin.Forms.Xaml;

namespace Ministerio.View.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShowDayToDayView : PopupPage
	{
        public event EventHandler<object> CallbackEvent;
        public ShowDayToDayView ()
		{
			InitializeComponent ();
		}
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CallbackEvent?.Invoke(this, EventArgs.Empty);
        }        
    }
}