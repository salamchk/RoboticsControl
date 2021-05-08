﻿using Android.Bluetooth;
using Java.Util;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Bluetooth.BluetoothClass;

namespace RoboticsControl.ViewModel
{
    public class DeviceConnection
    {
        public Model.Device SelectedDevice{ get;}

        private static DeviceConnection _connection;
        private static BluetoothSocket _socket;
        private static UUID _uuid = UUID.FromString("00001101-0000-1000-8000-00805f9b34fb");


        public static DeviceConnection GetConnection(Model.Device device)
        {
            _connection = new DeviceConnection(device);
                return _connection;
        }

        public static DeviceConnection GetConnection()
        {
            return _connection;
        }


        public void Connect()
        {
            try
            {
                if(_socket == null)
                {
                    var adapter = BluetoothAdapter.DefaultAdapter;
                    var currentDevice = adapter.GetRemoteDevice(SelectedDevice.Address);
                    _socket = currentDevice.CreateInsecureRfcommSocketToServiceRecord(_uuid);
                }
                _socket.Connect();
                CrossToastPopUp.Current.ShowToastMessage("Done.");
            }
            catch (Exception)
            {

                CrossToastPopUp.Current.ShowToastMessage("Can not connect to chosen device");
            }
        }

        public void Disconect()
        {
           if(_socket != null) _socket.Close();
            _socket = null;
        }

        private DeviceConnection(Model.Device device)
        {
            SelectedDevice = device;
        }
    }
}
