using System.Collections.Generic;
using Core.Config.Utils;
using NUnit.Framework;

namespace Core.Config.Test.Tests
{
    [TestFixture()]
    public class FileSearcherTest : TestBase
    {
        [Test]
        public void TestFileSearcher()
        {
            var result = FileSearcher.Search(Helper.GetDataPath(), new List<string>() { "Web.config.xslt", "App.config.xslt" });

            Assert.AreEqual(result.Count, 3);
        }
    }
}
