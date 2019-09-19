using System.Collections.Generic;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Concrete
{
	public class EfMusicRepository : IMusicRepository
	{
		readonly EfDbContext _context = new EfDbContext();

		public IEnumerable<MusicTrack> MusicTracks => _context.MusicTracks;
	}
}
