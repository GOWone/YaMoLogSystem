namespace YaMoLogger.Test
{
    public class LoggerHelperTest
    {
        [Test]
        public void TestLogger()
        {
            YaMoLoggerHepler.Error("Hello World");
            var result = File.ReadAllText("log.txt");
            Assert.That(result.Trim(), Is.EqualTo("Hello World"));
        }
    }
}