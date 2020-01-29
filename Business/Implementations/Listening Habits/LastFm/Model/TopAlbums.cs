using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LastFm {
    public struct TopAlbums : ITopAlbums {        
        [JsonPropertyName("album")]
        [JsonConverter(typeof(AlbumsListConverter))]
        public List<IAlbum> Albums { get; set; }

        private class AlbumsListConverter : JsonConverter<List<IAlbum>> {
            public override List<IAlbum> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
                return JsonSerializer.Deserialize<List<Album>>(ref reader, options)
                    .Cast<IAlbum>()
                    .ToList();
            }

            public override void Write(Utf8JsonWriter writer, List<IAlbum> albums, JsonSerializerOptions options) {                
                throw new NotImplementedException();
            }
        }
    }    
}