using System;
using System.Configuration;
using System.IO;
using NUnit.Framework;

namespace Core.Config.Settings.Test.Tests
{
    [TestFixture()]
    public class SettingsReaderTest
    {
        public SettingsReaderTest()
        {
            Helper.PrepareCoreConfigFiles();
        }

        public static String GetSettingsPath()
        {
            return Path.Combine(Helper.GetDataPath(), "settings");
        }

        [Test]
        public void OneLevelTest()
        {
            var settingsPath = GetSettingsPath();

            var reader = new SettingsReader(settingsPath);
            var result = reader.Read();

            Assert.AreEqual(result["Acropolis.SolutionFolder"].Value, @"Please specify Acropolis.SolutionFolder in your configuration!");
        }
        
        [Test]
        public void TwoLevelTest()
        {
            var settingsPath = Path.Combine(GetSettingsPath(), "DmitrySchetnikovich");

            var reader = new SettingsReader(settingsPath);
            var result = reader.Read();

            Assert.AreEqual(result["Acropolis.SolutionFolder"].Value, @"d:\Projects\Ajeva Project");
        }

        [Test]
        public void ThreeLevelTest()
        {
            var settingsPath = Path.Combine(GetSettingsPath(), "Production\\Test");

            var reader = new SettingsReader(settingsPath);
            var result = reader.Read();

            Assert.AreEqual(result["Xomo.Application.RootUrl"].Value, @"http://xomo.epear.com");
        }

        [Test]
        public void Test()
        {
            KeyValueConfigurationCollection collection = new KeyValueConfigurationCollection();
            collection.Add("key", "value");
        }
    }
}
