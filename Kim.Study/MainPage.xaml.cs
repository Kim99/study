using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace Kim.Study
{
    public partial class MainPage : ContentPage
    {
        MainViewModel _vm;
        public MainPage()
        {
            InitializeComponent();
            //this.CarouselZoos.ItemsSource = new List<string> { "早晨.png", "中午.png", "傍晚.png", "夜晚.png" };
            this._vm = new MainViewModel(this.stackIndicators);
            this.BindingContext = this._vm;

            //Device.StartTimer(new TimeSpan(0, 0, 5), () =>
            //{
            //    if (this.CarouselZoos.Position == this._vm.BannelList.Count - 1)
            //    {
            //        this.CarouselZoos.Position = 0;
            //        return true;
            //    }
            //    this.CarouselZoos.Position += 1;
            //    return true;
            //});
        }

        void Handle_PositionSelected(object sender, Xamarin.Forms.SelectedPositionChangedEventArgs e)
        {
            if (this._vm == null)
            {
                return;
            }
            int index = int.Parse(e.SelectedPosition.ToString());
            this._vm.SetSelectedStatus((int)e.SelectedPosition);
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            System.Console.WriteLine(e.SelectedItem.ToString());
        }
    }
}
