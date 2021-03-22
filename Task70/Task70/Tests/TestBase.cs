 using NUnit.Framework;
using  Task70.App;

namespace Task70.Tests
{
    public class TestBase
    {
        public Application app;

        [SetUp]
        public void Start()
        {
            app = new Application();
        }

        [TearDown]
        public void Stop()
        {
            app.Quit();
            app = null;
        }
    }
}
