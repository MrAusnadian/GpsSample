using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace GpsSample.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void KoreaGPS()
        {
            app.Device.SetLocation(49.2463, -123.1162);
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            app.Screenshot("49.2463, -123.1162.");
            Assert.IsTrue(results.Any());
        }

        [Test]
        public void CanadaGPS()
        {
            app.Device.SetLocation(43.6529, -79.3849);
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            app.Screenshot("43.6529, -79.3849");
            Assert.IsTrue(results.Any());
        }

        [Test]
        public void UsaGPS()
        {
            app.Device.SetLocation(37.7740, -122.4313);
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            app.Screenshot("37.7740, -122.4313");
            Assert.IsTrue(results.Any());
        }

        [Test]
        public void NoCustomGPS()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
            app.Screenshot("No custom GPS provided");
            Assert.IsTrue(results.Any());
        }
    }
}
