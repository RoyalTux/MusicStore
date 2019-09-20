using System.Linq;
using MusicStore.Domain.Abstract;
using System.Web.Mvc;
using MusicStore.Domain.Entities;
using MusicStore.WebUI.Models;

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
			var model = new MusicListViewModel
			{
				musicTracks = _musicRepository.MusicTracks
					.OrderBy(music => music.MusicTrackId)
					.Skip((page - 1) * pageSize)
					.Take(pageSize),
				pagingInfo = new PagingInfo
				{
					CurrentPage = page,
					ItemsPerPage = pageSize,
					TotalItems = _musicRepository.MusicTracks.Count()
				}
			};
			return View(model);



			//return View(_musicRepository.MusicTracks
			//	.OrderBy(musicTrack => musicTrack.MusicTrackId)
			//	.Skip((page - 1) * pageSize)
			//	.Take(pageSize));
		}
	}
}