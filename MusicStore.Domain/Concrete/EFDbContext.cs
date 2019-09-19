using System.Data.Entity;
using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Concrete
{
	public class EfDbContext : DbContext
	{
		public DbSet<MusicTrack> MusicTracks { get; set; }
	}
}
