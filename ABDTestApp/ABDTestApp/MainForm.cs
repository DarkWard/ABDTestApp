using AdvancedSharpAdbClient;
using System.Text.RegularExpressions;

namespace ABDTestApp
{
    public partial class MainForm : Form
    {
        private const string IPSearchQuery = "my ip address";


        private IAdbServer _server;
        private AdvancedAdbClient _client;
        private DeviceData _device;

        public MainForm(string adbPath)
        {
            InitializeComponent();
            InitializeAdb(adbPath);
        }

        private void InitializeAdb(string adbPath)
        {
            _server = AdbServer.Instance;
            if (!_server.GetStatus().IsRunning)
            {
                AdbServer server = new AdbServer();
                StartServerResult result = server.StartServer(adbPath, false);
                if (result != StartServerResult.Started)
                {
                    MessageBox.Show("Failed to start adb server.");
                    Environment.Exit(1);
                    return;
                }
            }

            _client = new AdvancedAdbClient();
            _device = _client.GetDevices().FirstOrDefault();
            if (_device == null)
            {
                MessageBox.Show("Can't connect to device");
                return;
            }
        }

        private async void KillBackgroundAppsButton_Click(object sender, EventArgs e)
        {
            _client.SendKeyEvent(_device, "KEYCODE_HOME");
            _client.SendKeyEvent(_device, "KEYCODE_APP_SWITCH");

            var closeButton = await _client.FindElementAsync(_device, "//node[@resource-id='com.android.launcher:id/btn_clear']");

            try
            {
                closeButton.Click();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void OpenChromeButton_Click(object sender, EventArgs e)
        {
            var chromeIcon = _client.FindElement(_device, "//node[@text='Chrome']");

            if (chromeIcon != null)
            {
                chromeIcon.Click();
            }
        }

        private void SearchInput_TextChanged(object sender, EventArgs e) { }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchInput.Text != "")
            {
                var urlBar = await _client.FindElementAsync(_device, "//node[@resource-id='com.android.chrome:id/url_bar']");

                try
                {
                    urlBar.Click();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (SearchInput.Text == IPSearchQuery)
                {
                    SearchInput.Clear();
                    _client.SendText(_device, "'my ip address'");
                    await _client.SendKeyEventAsync(_device, "KEYCODE_ENTER");

                    FindIp();
                }

                _client.SendText(_device, $"'{SearchInput.Text}'");
                _client.SendKeyEventAsync(_device, "KEYCODE_ENTER");
            }
        }

        private void FindIp()
        {
            var regexPattern = @"\b(?:\d{1,3}\.){3}\d{1,3}\b";
            var xmlText = _client.DumpScreen(_device).OuterXml;

            Match match = Regex.Match(xmlText, regexPattern);

            if (match.Success)
            {
                ResponsesList.Items.Add(match.Value);
            }
        }

        private void ResponsesList_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
