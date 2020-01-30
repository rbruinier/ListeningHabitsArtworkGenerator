using System;
using System.Text.Json.Serialization;
using ListeningHabitsArtworkGenerator.Business.Contracts.ListeningHabits.Model;

namespace ListeningHabitsArtworkGenerator.Business.Implementations.ListeningHabits.LastFm.Model
{
    public struct AlbumImage : IAlbumImage
    {
        public string Size { get; set; }

        [JsonPropertyName("#text")]
        public string Url { get; set; }
    }
}
