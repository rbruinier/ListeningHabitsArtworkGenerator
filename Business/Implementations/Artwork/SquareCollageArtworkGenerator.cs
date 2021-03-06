﻿using System;
using System.Net.Http;
using System.IO;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.Primitives;
using ListeningHabitsArtworkGenerator.Business.Contracts.Artwork;
using ListeningHabitsArtworkGenerator.Business.Contracts.ListeningHabits.Model;

namespace ListeningHabitsArtworkGenerator.Business.Implementations.Artwork
{
    public class SquareCollageArtworkGenerator : IArtworkGenerator
    {
        private IHttpClientFactory _httpClientFactory;

        public SquareCollageArtworkGenerator(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task CreateImageWithAlbums(List<IAlbum> albums, string outputPath)
        {
            var albumsWithArtwork = albums
                .Where(album => album.BestQualityImageUrl != null)
                .ToList();

            if (albumsWithArtwork.Count < 9)
            {
                throw new ApplicationException("Not enough images with artwork available to create a collage");
            }

            var httpClient = _httpClientFactory.CreateClient();
            
            using var image = new Image<Rgba32>(600, 600);

            var albumCounter = 0;
            for (var y = 0; y < 3; y++)
            {
                for (var x = 0; x < 3; x++)
                {
                    var url = albumsWithArtwork[albumCounter].BestQualityImageUrl;

                    var imageStream = await this.FetchImage(url, httpClient);

                    using var albumArtworkImage = Image.Load(imageStream);

                    albumArtworkImage.Mutate(o => o.Resize(new Size(200, 200)));

                    image.Mutate(context => context
                        .DrawImage(albumArtworkImage, new Point(x * 200, y * 200), 1)
                    );

                    albumCounter += 1;
                }
            }

            PrepareOutputPath(outputPath);

            using var outputStream = new FileStream(outputPath, FileMode.Create);

            image.SaveAsPng(outputStream);
        }

        private async Task<Stream> FetchImage(string url, HttpClient httpClient)
        {
            Console.WriteLine($"Fetching image '{url}'");

            return await httpClient.GetStreamAsync(url);
        }

        private void PrepareOutputPath(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
