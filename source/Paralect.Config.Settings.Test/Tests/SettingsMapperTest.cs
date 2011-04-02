using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Paralect.Config.Settings.Test.Tests
{
    public class MyInnerSettings
    {
        [SettingsProperty("MyApp.Name")]
        public String Name { get; set; }

        [SettingsProperty("MyApp.Value")]
        public String Value { get; set; }

        [SettingsProperty("MyApp.Year")]
        public String Year { get; set; }
    }

    public class MySettings
    {
        [SettingsProperty("MyApp.Name")]
        public String Name { get; set; }

        [SettingsProperty("MyApp.Value")]
        public String Value { get; set; }

        [SettingsProperty("MyApp.Year")]
        public Int32 Year { get; set; }

        [SettingsProperty]
        public MyInnerSettings InnerSettings { get; set; }
    }

    [TestFixture]
    public class SettingsMapperTest
    {
        [Test]
        public void SimpleTest()
        {
            var obj = SettingsMapper.Map<MySettings>();

            Assert.AreEqual(obj.Name, "TestName");
            Assert.AreEqual(obj.Value, "Hello");
            Assert.AreEqual(obj.Year, 2011);
        }
    }
}
