using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticsControl.Model
{
    public enum Command
    {
        MaxTurnRight = 0x01,
        MaxTurnLeft = 0x02,
        DirectPosition = 0x03,
        MoveForward = 0x04,
        MoveBack = 0x05,
        TurnRight = 0x06,
        TurnLeft = 0x07,
        SetDirectPosition = 0x08,
        StopMoving = 0x09
    }
}
