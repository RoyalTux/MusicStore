using System.Collections.Generic;
using MusicStore.Domain.Entities;

namespace MusicStore.WebUI.Models
{
	public class MusicListViewModel
	{
		public IEnumerable<MusicTrack> musicTracks { get; set; }
		public PagingInfo pagingInfo { get; set; }
	}
}