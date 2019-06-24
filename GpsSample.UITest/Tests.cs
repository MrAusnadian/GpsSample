using System;
using System.IO;
using System.Linq;
using System.Threading;
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
            double latDouble = 49.2463;
            double longDouble = -123.1162;

            app.Device.SetLocation(latDouble, longDouble);
            Thread.Sleep(1000);
            AppResult[] message       = app.WaitForElement(c => c.Marked("Welcome to GPS Sample!"));
            AppResult[] latitudeTest  = app.WaitForElement(c => c.Marked("Latitude: " + latDouble));
            AppResult[] longitudeTest = app.WaitForElement(c => c.Marked("Longitude: " + longDouble));
            app.Screenshot("Should be " + latDouble + ", " + longDouble);
            Assert.IsTrue(message.Any());
            Assert.IsTrue(latitudeTest.Any());
            Assert.IsTrue(longitudeTest.Any());
        }

        [Test]
        public void CanadaGPS()
        {
            double latDouble = 43.6529;
            double longDouble = -79.3849;

            app.Device.SetLocation(latDouble, longDouble);
            Thread.Sleep(1000);
            AppResult[] message = app.WaitForElement(c => c.Marked("Welcome to GPS Sample!"));
            AppResult[] latitudeTest = app.WaitForElement(c => c.Marked("Latitude: " + latDouble));
            AppResult[] longitudeTest = app.WaitForElement(c => c.Marked("Longitude: " + longDouble));
            app.Screenshot("Should be " + latDouble + ", " + longDouble);
            Assert.IsTrue(message.Any());
            Assert.IsTrue(latitudeTest.Any());
            Assert.IsTrue(longitudeTest.Any());
        }

        [Test]
        public void UsaGPS()
        {
            double latDouble = 37.7740;
            double longDouble = -122.4313;

            app.Device.SetLocation(latDouble, longDouble);
            Thread.Sleep(1000);
            AppResult[] message = app.WaitForElement(c => c.Marked("Welcome to GPS Sample!"));
            AppResult[] latitudeTest = app.WaitForElement(c => c.Marked("Latitude: " + latDouble));
            AppResult[] longitudeTest = app.WaitForElement(c => c.Marked("Longitude: " + longDouble));
            app.Screenshot("Should be " + latDouble + ", " + longDouble);
            Assert.IsTrue(message.Any());
            Assert.IsTrue(latitudeTest.Any());
            Assert.IsTrue(longitudeTest.Any());
        }

        [Test]
        public void NoCustomGPS()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to GPS Sample!"));
            app.Screenshot("No custom GPS provided");
            Assert.IsTrue(results.Any());
        }
    }
}
