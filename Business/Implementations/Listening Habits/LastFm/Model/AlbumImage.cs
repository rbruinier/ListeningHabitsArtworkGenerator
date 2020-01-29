using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LastFm {
    public struct AlbumImage: IAlbumImage {
        public string Size { get; set; }

        [JsonPropertyName("#text")]
        public string Url { get; set; }
    }
}