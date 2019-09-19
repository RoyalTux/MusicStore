using MusicStore.Domain.Abstract;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
    public class MusicController : Controller
    {
        private IMusicRepository _musicRepository;
        public MusicController(IMusicRepository repository)
        {
            _musicRepository = repository;
        }
        public ViewResult List()
        {
            return View(_musicRepository.MusicTracks);
        }
    }
}