using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Core.Config.Test
{
    public class TestBase
    {
        [TestFixtureSetUp]
        public void PrepareConfigFiles()
        {
            Helper.PrepareCoreConfigFiles();
        }
    }
}
