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

            return ConfigureApp.iOS.InstalledApp("com.gluwa.GpsSample").EnableLocalScreenshots().StartApp();
        }
    }
}