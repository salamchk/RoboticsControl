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
        public DeviceConnectView()
        {
            InitializeComponent();
            var searcher = DeviceSearcher.GetSearcher();
            searcher.Search();
            devicesList.ItemsSource =new  ObservableCollection<Model.Device>(searcher.Devices);
            
        }
        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var connection = DeviceConnection.GetConnection((Model.Device)e.Item);
            devicesList.SelectedItem = null;
        }
    }
}