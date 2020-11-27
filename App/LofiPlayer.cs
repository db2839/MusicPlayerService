using LazyLofi.Backend;
using LazyLofi.Backend.Manager.Constants;
using LazyLofi.Backend.Manager.Services.Database.Models;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LazyLofiDesktop
{
    public partial class LofiPlayer : Form
    {
        private readonly BackendDomain backendDomain = new BackendDomain();

        private void button1_Click(object sender, System.EventArgs e)
        {
            SetCurrentVideo(VideoList.GetVideo(Counter.GetCounter()));
            if (Counter.GetCounter() == 5)
            {
                button2.Show();
            }
            Counter.HitCounter();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            var videos = this.backendDomain.GetVideos(true, VideoSearchConstants.GetRandomQuery()) as List<VideoDatabaseResposne>;
            Counter.setSize(videos.Count);
            VideoList.SetVideos(videos);
            this.SetCurrentVideo(VideoList.GetVideo(Counter.GetCounter()));
            Counter.HitCounter();
            button2.Hide();
        }

        private void SetCurrentVideo(VideoDatabaseResposne video)
        {
            var builder = new StringBuilder();
            builder.Append("<html><head>");
            builder.Append("<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>");
            builder.Append($"<body style='background-color: black;'><iframe id='video' title='{video.Title}' src= '{video.Url}' width='1130' height='675' frameborder='0' allowfullscreen></iframe>");
            builder.Append("</body></html>");

            this.webBrowser1.DocumentText = builder.ToString();
        }

        private void SetupVideos()
        {
            this.backendDomain.SetupDatabase();

            var videos = this.backendDomain.GetVideos() as List<VideoDatabaseResposne>;
            VideoList.SetVideos(videos);
            Counter.setSize(videos.Count);
        }

        private void SetupWebBrowser()
        {
            this.SetCurrentVideo(VideoList.GetVideo(Counter.GetCounter()));
            Counter.HitCounter();
        }

        public LofiPlayer()
        {
            InitializeComponent();
            button2.Hide();
            SetupVideos();
            SetupWebBrowser();
        }
    }
}