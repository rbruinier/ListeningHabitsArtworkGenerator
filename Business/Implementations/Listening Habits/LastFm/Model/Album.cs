using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using ListeningHabitsArtworkGenerator.Business.Contracts.ListeningHabits.Model;

namespace ListeningHabitsArtworkGenerator.Business.Implementations.ListeningHabits.LastFm.Model
{
    public struct Album : IAlbum
    {
        public string Name { get; set; }

        [JsonConverter(typeof(ArtistConverter))]
        public IArtist Artist { get; set; }

        [JsonPropertyName("image")]
        [JsonConverter(typeof(AlbumImageListConverter))]
        public List<IAlbumImage> Images { get; set; }

        public string BestQualityImageUrl
        {
            get
            {
                return this.Images.First(image => image.Size == "extralarge").Url;
            }
        }

        private class ArtistConverter : JsonConverter<IArtist>
        {
            public override IArtist Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return JsonSerializer.Deserialize<Artist>(ref reader, options);
            }

            public override void Write(Utf8JsonWriter writer, IArtist artist, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }

        private class AlbumImageListConverter : JsonConverter<List<IAlbumImage>>
        {
            public override List<IAlbumImage> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                return JsonSerializer.Deserialize<List<AlbumImage>>(ref reader, options)
                    .Cast<IAlbumImage>()
                    .ToList();
            }

            public override void Write(Utf8JsonWriter writer, List<IAlbumImage> albums, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}
