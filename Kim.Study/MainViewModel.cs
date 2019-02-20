using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using Kim.Study.Utils;
using System.Linq;
using System.Linq.Expressions;

namespace Kim.Study
{
    public class CarouselModel : INotifyPropertyChanged
    {
        private string _image;
        private bool _selected;

        public string Image { get => _image; set { _image = value; OnPropertyChanged("Image"); } }
        public bool Selected { get => _selected; set { _selected = value; OnPropertyChanged("Selected"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<string> _bannelList;
        public ObservableCollection<string> BannelList
        {
            set
            {
                _bannelList = value;
                OnPropertyChanged("BannelList");
            }
            get
            {
                return _bannelList;
            }
        }

        public Command MyCommand { protected set; get; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        StackLayout StackIndicators;

        public MainViewModel(StackLayout stackIndicators)
        {
            this.StackIndicators = stackIndicators;
            BannelList = new ObservableCollection<string>()
            {
                 "早晨.png" ,
                 "中午.png" ,
                 "傍晚.png" ,
                 "夜晚.png"
            };
            for (int i = 0; i < this.BannelList.Count; i++)
            {
                Frame img = new Frame
                {
                    BackgroundColor = Color.FromHex(i == 0 ? "000000" : "aaa9aa"),
                    BorderColor = Color.White,
                    BindingContext = i == 0 ? true : false,
                    WidthRequest = SizeUtil.GetSize(.5),
                    HeightRequest = SizeUtil.GetSize(2.5)
                };
                this.StackIndicators.Children.Add(img);
            }
        }

        public void SetSelectedStatus(int index)
        {
            var imgs = this.StackIndicators.Children.OfType<Frame>().ToList();
            for (int i = 0; i < this.BannelList.Count; i++)
            {
                if ((bool)imgs[i].BindingContext == true & i != index)
                {
                    imgs[i].BackgroundColor = Color.FromHex("aaa9aa");
                    imgs[i].BindingContext = false;
                    continue;
                }
                if (i == index && (bool)imgs[i].BindingContext == false)
                {
                    imgs[i].BackgroundColor = Color.FromHex("000000");
                    imgs[i].BindingContext = true;
                    continue;
                }
            }
        }
    }
}
