using Android.Bluetooth;
using Plugin.Toast;
//using RoboticsControl.Models;
using System;
using System.IO;

namespace RoboticsControl.ViewModel
{
    public class DeviceViewModel
    {
        private BluetoothSocket _socket;
        private static DeviceViewModel _device;
        private Stream _outStream;
       // public BluetoothDeviceModelConnection Device { get; }
        public bool IsConnected { get; private set; }

        public static DeviceViewModel GetDeviceViewModel(string address)
        {
            if (_device == null) _device = new DeviceViewModel(address);
            return _device;
        }

        public static DeviceViewModel TryLoadDevice()
        {
            if (_device == null) _device = new DeviceViewModel("00:00:00:00:00:00");
           // _device.Device.LoadAddress();
            return _device;
        }

        public void Connect()
        {
            if (_socket == null)
            {
                var adapter = BluetoothAdapter.DefaultAdapter;
             //   var device = adapter.GetRemoteDevice(Device.Address);
            //    _socket = device.CreateInsecureRfcommSocketToServiceRecord(Device.UUID);
            }
            if (_socket != null && _socket.IsConnected != true)
            {
                try
                {
                    _socket.Connect();
                    IsConnected = true;
              //      _device.Device.SaveAddress();
                    
                }
                catch (Exception e)
                {
                    CrossToastPopUp.Current.ShowToastMessage("Can not to connect to saved device");
                }
            }

        }

        public void Disconnect()
        {
            if (_socket == null) throw new NullReferenceException();
            if (!_socket.IsConnected) _socket.Close();
            IsConnected = false;
        }

        public void SendMessage(byte[] message)
        {
            if (!IsConnected) throw new Exception("You are not connected");
            try
            {
                if (_outStream == null) _outStream = _socket.OutputStream;
                _outStream.Write(message, 0, message.Length);
            }
            catch(Exception e)
            {

            }
            
        }



        private DeviceViewModel(string address)
        {
           // Device = BluetoothDeviceModelConnection.GetDevice(address);
        }
    }
}

