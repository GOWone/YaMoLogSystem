namespace YaMoLogger.Test
{
    public class LoggerHelperTest
    {
        [Test]
        public void TestLogger()
        {
            YaMoLoggerHepler.Error("Hello World");
            var result = File.ReadAllText("file.log");
            Console.WriteLine(result);
        }
    }
}