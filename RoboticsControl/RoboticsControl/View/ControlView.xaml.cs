using RoboticsControl.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoboticsControl.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlView : ContentPage
    {
        private double _width = 0;
        private double _height = 0;
        public ControlView()
        {
            InitializeComponent();
            
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(DeviceConfigurationView.GetDeviceConfigurationView());
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }

        private void TurningSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }

        private void MovingSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }
    }
}