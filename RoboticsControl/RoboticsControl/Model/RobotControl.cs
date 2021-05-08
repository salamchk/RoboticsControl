using RoboticsControl.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace RoboticsControl.Model
{
    [Serializable]
    public class RobotControl
    {
        private byte _maxTurnRight;
        private byte _maxTurnLeft;
        private byte _directPosition;
        private static DeviceViewModel _device;

 

        public byte MaxTurnRight
        {
            get => _maxTurnRight;
            private set
            {
                if (value > 180)
                    _maxTurnRight = 180;
                else _maxTurnRight = value;
            }
        }
        public byte MaxTurnLeft
        {
            get => _maxTurnLeft;
            private set
            {
                if (value > 180)
                    _maxTurnLeft = 180;
                else _maxTurnLeft = value;
            }
        }
        public byte DirectPosition
        {
            get => _directPosition;
            private set
            {
                if (value > 180)
                    _directPosition = 180;
                else _directPosition = value;
            }
        }



        public RobotControl(DeviceViewModel device)
        {
            _device = device;
        }

        public void ConfigureAngle(Command typeOfAConfiguration, byte position)
        {
            if (_device.IsConnected)
            {
                if (typeOfAConfiguration != Command.MaxTurnRight && typeOfAConfiguration != Command.MaxTurnLeft && typeOfAConfiguration != Command.DirectPosition)
                    throw new Exception("wrong command");
                if (position > 180) position = 180;
                if (typeOfAConfiguration == Command.DirectPosition && position != DirectPosition)
                    DirectPosition = position;
                if (typeOfAConfiguration == Command.MaxTurnRight && position != MaxTurnRight) 
                    MaxTurnRight = position;
                if (typeOfAConfiguration == Command.MaxTurnLeft && position != MaxTurnLeft) 
                    MaxTurnLeft = position;
                
                _device.SendMessage(new byte[] { (byte)typeOfAConfiguration, position });
            }
            else throw new Exception("Not connected");
        }


        public void Move(bool allowMoving, bool forward, byte speed)
        {
            if (_device.IsConnected)
            {
                if (!allowMoving)
                    _device.SendMessage(new byte[] { (byte)Command.StopMoving, 0 });
                if (forward)
                    _device.SendMessage(new byte[] { (byte)Command.MoveForward, speed });
                else _device.SendMessage(new byte[] { (byte)Command.MoveBack, speed });
            }
            else throw new Exception("Not connected");
        }

        public void Turn(bool right, byte angle)
        {
            if (_device.IsConnected)
            {
                if (right)
                {
                    if (angle > MaxTurnRight) angle = MaxTurnRight;
                    _device.SendMessage(new byte[] { (byte)Command.TurnRight, angle });

                }
                else
                {
                    if (angle > MaxTurnLeft) angle = MaxTurnLeft;
                    _device.SendMessage(new byte[] { (byte)Command.MaxTurnLeft, angle });

                }
            }
            else throw new Exception("Not connected");

        }

        public void ToDirectPosition()
        {
            if (_device.IsConnected)
            {
                _device.SendMessage(new byte[] { (byte)Command.SetDirectPosition, DirectPosition });
            }
            else throw new Exception("Not connected");
        }

        public void HardStop()
        {
            if (_device.IsConnected)
            {
                _device.SendMessage(new byte[] { (byte)Command.StopMoving, 0});
            }
            else throw new Exception("Not connected");
        }

        public void SaveConfigurations()
        {
            Preferences.Set("MaxTurnRight", MaxTurnRight);
            Preferences.Set("MaxTurnLeft", MaxTurnLeft);
            Preferences.Set("DirectPosition", DirectPosition);
        }

        public void LoadConfigurations()
        {
            ConfigureAngle(Model.Command.MaxTurnRight, (byte)Preferences.Get("MaxTurnRight", 180));
            ConfigureAngle(Model.Command.MaxTurnLeft, (byte)Preferences.Get("MaxTurnLeft", 0));
            ConfigureAngle(Model.Command.DirectPosition, (byte)Preferences.Get("DirectPosition", 90));

        }

        public void SetDefaultConfigrations()
        {
            MaxTurnRight = 180;
            MaxTurnLeft = 0;
            DirectPosition = 90;
        }
    }
}
