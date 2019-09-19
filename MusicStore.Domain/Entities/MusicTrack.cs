namespace MusicStore.Domain.Entities
{
    public class MusicTrack
    {
        public int MusicTrackId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
