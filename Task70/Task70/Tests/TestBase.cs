 using NUnit.Framework;
 using NUnit.Framework.Interfaces;
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
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                app.MakeScreenShot();
            }

            app.Quit();
            app = null;
        }

        
    }
}
