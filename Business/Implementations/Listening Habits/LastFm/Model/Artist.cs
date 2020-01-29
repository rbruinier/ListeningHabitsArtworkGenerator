using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LastFm {
    public struct Artist: IArtist {
        public string Name { get; set; }
        public string MBId { get; set; }
    }
}