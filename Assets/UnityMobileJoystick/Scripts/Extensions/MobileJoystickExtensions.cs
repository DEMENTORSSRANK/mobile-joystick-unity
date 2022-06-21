using UnityEngine;
using UnityMobileJoystick.Scripts.Core;

namespace UnityMobileJoystick.Scripts.Extensions
{
    public static class MobileJoystickExtensions
    {
        public static int GetDirectionAngle(this MobileJoystick joystick)
        {
            float cos = joystick.Direction.x;

            float sin = joystick.Direction.y;

            return Mathf.RoundToInt(Mathf.Atan2(sin, cos) * Mathf.Rad2Deg);
        }
    }
}