using LazyLofi.Backend;
using LazyLofi.Backend.Manager.Constants;
using LazyLofi.Backend.Manager.Services.Database.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LazyLofi.Controllers
{
    public class HomeController : Controller
    {
        private readonly BackendDomain backendDomain = new BackendDomain();

        public ActionResult About()
        {
            if (Counter.GetCounter() == 0)
            {
                backendDomain.SetupDatabase();
                var videos = backendDomain.GetVideos() as List<VideoDatabaseResposne>;
                VideoList.SetVideos(videos);

                var vid = VideoList.GetVideo(Counter.GetCounter());
                ViewBag.VideoTitle = vid.Title;
                ViewBag.Url = vid.Url;

                Counter.setSize(videos.Count);
                Counter.HitCounter();
            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Refresh()
        {
            var videos = backendDomain.GetVideos(true, VideoSearchConstants.Vibez) as List<VideoDatabaseResposne>;
            Counter.setSize(videos.Count);
            VideoList.SetVideos(videos);

            ViewBag.VideoTitle = VideoList.GetVideo(Counter.GetCounter()).Title;
            ViewBag.Url = VideoList.GetVideo(Counter.GetCounter()).Url;
            Counter.HitCounter();

            return View("About");
        }

        public ActionResult Update()
        {
            var vid = VideoList.GetVideo(Counter.GetCounter());
            ViewBag.VideoTitle = vid.Title;
            ViewBag.Url = vid.Url;
            Counter.HitCounter();
            return View("About");
        }
    }
}