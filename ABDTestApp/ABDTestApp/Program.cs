namespace ABDTestApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm(@"D:\Test\adb.exe"));
        }
    }
}