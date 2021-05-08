using RoboticsControl.Model;
using RoboticsControl.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoboticsControl.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceConnectView : ContentPage
    {
        private static DeviceConnection connection;
        public DeviceConnectView()
        {
            InitializeComponent();
            var searcher = DeviceSearcher.GetSearcher();
            searcher.Search();
            devicesList.ItemsSource =new  ObservableCollection<Model.Device>(searcher.Devices);
            if (connection != null) devicesList.IsEnabled = false;
            
        }
        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                devicesList.IsEnabled = false;
                connection = DeviceConnection.GetConnection((Model.Device)e.Item);
                connection.Connect();
            }
            catch (Exception)
            {

                throw;
            }

            devicesList.SelectedItem = null;
            
        }

        private void DisconnectButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                connection.Disconect();
                devicesList.IsEnabled = true;
                connection = null;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}