using System;
using System.Threading.Tasks;

namespace SeeSharp001 {
    public class Program {
        static async Task Main(string[] args) {
            try {       
                var username = "CrossProduct";
                var outputPath = "output.png";

                if (args.Length >= 1) {
                    username = args[0];
                }

                var listeningHabitsApi = ListeningHabitsApiFactory.create();
                var artworkGenerator = ArtworkGeneratorFactory.Create(ArtworkStyle.SquareCollage);

                var topAlbums = await listeningHabitsApi.FetchTopAlbums(username);

                await artworkGenerator.CreateImageWithAlbums(topAlbums.Albums, outputPath);

                Console.WriteLine($"Artwork is generated and exported to {outputPath}");
            }
            catch (Exception e) {
                Console.WriteLine($"Something went wrong: {e.Message}");
            }
        }
    }
}
