using System;
using System.Threading.Tasks;
using ListeningHabitsArtworkGenerator.Business.Implementations.ListeningHabits;
using ListeningHabitsArtworkGenerator.Business.Implementations.Artwork;

namespace ListeningHabitsArtworkGenerator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var username = "CrossProduct";
            var outputPath = "output.png";

            if (args.Length >= 1)
            {
                username = args[0];
            }

            try
            {
                
                var listeningHabitsApi = ListeningHabitsApiFactory.Create();
                var artworkGenerator = ArtworkGeneratorFactory.Create(ArtworkStyle.SquareCollage);
                
                var topAlbums = await listeningHabitsApi.FetchTopAlbums(username);

                await artworkGenerator.CreateImageWithAlbums(topAlbums.Albums, outputPath);

                Console.WriteLine($"Artwork is generated and exported to {outputPath}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Apologies, something went wrong: {e.Message}");
            }
        }
    }
}
