

using RoboticsControl.Model;
using RoboticsControl.ViewModel;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RoboticsControl.Views
{
    public partial class DeviceConfigurationView : ContentPage
    {
        private DeviceViewModel _device;
        private RobotControl _control;
        private static DeviceConfigurationView _view;
        private DeviceConfigurationView()
        {

            InitializeComponent();
            _device = DeviceViewModel.TryLoadDevice();
            _control = new RobotControl(_device);
            _control.LoadConfigurations();
            this.BindingContext = _control;
        }

        public static DeviceConfigurationView GetDeviceConfigurationView()
        {
            if (_view == null) _view = new DeviceConfigurationView();
            return _view;
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            
            var value = (int)e.NewValue;
            lblText = new Label();
            lblText.SetBinding(Label.TextProperty, new Binding("Value", source: MaxRight) { StringFormat = "0:F0" });
        }

        private void MaxLeft_ValueChanged(object sender, ValueChangedEventArgs e)
        {
        }

        private void DirectPosition_ValueChanged(object sender, ValueChangedEventArgs e)
        {
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _control.SaveConfigurations();
        }

        private void ResetButton_Clicked(object sender, EventArgs e)
        {
            _control.SetDefaultConfigrations();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void MaxRight_DragCompleted(object sender, EventArgs e)
        {
            _control.ConfigureAngle(Model.Command.MaxTurnRight, (byte)MaxRight.Value);
        }

        private void MaxLeft_DragCompleted(object sender, EventArgs e)
        {
            _control.ConfigureAngle(Model.Command.MaxTurnLeft, (byte)MaxLeft.Value);

        }

        private void DirectPosition_DragCompleted(object sender, EventArgs e)
        {
            _control.ConfigureAngle(Model.Command.MaxTurnRight, (byte)DirectPosition.Value);

        }
    }
}