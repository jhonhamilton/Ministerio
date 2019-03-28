using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Ministerio.Droid.BottomBar.Utils
{
    public interface IPageController
    {
        Rectangle ContainerArea { get; set; }

        bool IgnoresContainerArea { get; set; }

        ObservableCollection<Element> InternalChildren { get; }

        void SendAppearing();

        void SendDisappearing();
    }
}