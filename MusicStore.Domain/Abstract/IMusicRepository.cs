using System.Collections.Generic;
using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Abstract
{
    public interface IMusicRepository
    {
        IEnumerable<MusicTrack> MusicTracks { get; }
    }
}
