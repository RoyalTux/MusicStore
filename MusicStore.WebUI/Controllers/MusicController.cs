using System.Linq;
using MusicStore.Domain.Abstract;
using System.Web.Mvc;

namespace MusicStore.WebUI.Controllers
{
	public class MusicController : Controller
	{
		private IMusicRepository _musicRepository;
		public int pageSize = 4;

		public MusicController(IMusicRepository repository)
		{
			_musicRepository = repository;
		}

		public ViewResult List(int page = 1)
		{
			return View(_musicRepository.MusicTracks
				.OrderBy(musicTrack => musicTrack.MusicTrackId)
				.Skip((page - 1) * pageSize)
				.Take(pageSize));
		}
	}
}