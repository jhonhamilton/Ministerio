﻿//using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Pages;
using System;
using Xamarin.Forms.Xaml;

namespace Ministerio.View.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddInformeView : PopupPage
    {
        public event EventHandler<object> CallbackEvent;
        public event EventHandler<object> CancelCallbackEvent;
        protected override void OnDisappearing()
        {
            CallbackEvent?.Invoke(this, EventArgs.Empty);
            CancelCallbackEvent?.Invoke(this, EventArgs.Empty);
        }
        public AddInformeView()
        {
            InitializeComponent();
        }
    }
}