using RtspViewer.Configuration;
using System;
using System.Windows.Forms;

namespace RtspViewerTest
{
    public partial class Form1 : Form
    {

        private const string ConfigurationFilename = "config.json.enc";

        private bool _isRunning = false;
        private StreamConfiguration _config = new StreamConfiguration();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoView.Stop();
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            _config.Address = "rtsp://192.168.10.40";
            _config.Username = "admin";
            _config.Password = "admin123";
            _config.Protocol = ConnectionType.UDP;

            if (_isRunning)
            {
                videoView.Stop();
                playBtn.Text = "Play";
                _isRunning = false;
                videoView.SetPicture("https://qr.gatepro.mn/static/2025/01/15/1222%D0%A3%D0%9A%D0%9E-20250129170823.jpg");
            }
            else
            {
                videoView.InitialiseStream(_config);
                StreamConfiguration.Save(ConfigurationFilename, _config);

                if (string.IsNullOrWhiteSpace(_config.Address))
                {
                    videoView.Stop();
                }
                else
                {
                    videoView.Start();
                    playBtn.Text = "Stop";
                    _isRunning = true;
                }
            }
        }
    }
}
