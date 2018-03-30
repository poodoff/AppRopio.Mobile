using System;
using UIKit;

namespace AppRopio.Base.iOS.UIExtentions
{
	public static class DeviceInfo
	{
        public static float ScreenWidth = (float)UIScreen.MainScreen.Bounds.Width;
        public static float ScreenHeight = (float)UIScreen.MainScreen.Bounds.Height;
        public static float ScreenMaxLength = Math.Max(ScreenWidth, ScreenHeight);

        public static bool Is_iPhone4 = Device.IsPhone && ScreenMaxLength < 568.0f;
        public static bool Is_iPhone5 = Device.IsPhone && ScreenMaxLength == 568.0f;
        public static bool Is_iPhone6 = Device.IsPhone && ScreenMaxLength == 667.0f;
        public static bool Is_iPhone6Plus = Device.IsPhone && ScreenMaxLength == 736.0f;
        public static bool Is_iPhoneX = Device.IsPhone && ScreenMaxLength == 812.0f;
	}
}

