using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace GpsSample.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.InstalledApp("com.gluwa.GpsSample").EnableLocalScreenshots().StartApp();
            }
            Environment.SetEnvironmentVariable("UITEST_FORCE_IOS_SIM_RESTART", "1");
            return ConfigureApp.iOS
                //.AppBundle("/SRC/GpsSample/GpsSample/GpsSample.iOS/bin/iPhone/Debug/device-builds/iphone10.3-13.0/GpsSample.iOS.app")
                //.AppBundle("/SRC/GpsSample/GpsSample/GpsSample.iOS/bin/iPhoneSimulator/Debug/device-builds/iphone10.4-11.4/GpsSample.iOS.app")
                .InstalledApp("com.gluwa.GpsSample")
                //.DeviceIdentifier("14FB46D2-E595-4828-A70B-B3DAE4E12F05")
                .DeviceIdentifier("e197366078cd278adf37f4f63d20ebae22a22aa2")
                .StartApp();
        }
    }
}