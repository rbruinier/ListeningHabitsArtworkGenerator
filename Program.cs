using System;
using System.Threading.Tasks;
using ListeningHabitsArtworkGenerator.Business.Implementations.Artwork;
using Microsoft.Extensions.DependencyInjection;
using ListeningHabitsArtworkGenerator.Business.Contracts.ListeningHabits;
using ListeningHabitsArtworkGenerator.Business.Contracts.Artwork;
using ListeningHabitsArtworkGenerator.Business.Implementations.ListeningHabits.LastFm;

namespace ListeningHabitsArtworkGenerator
{
    public class ConsoleApplication
    {
        private readonly IListeningHabitsApi _listeningHabitsApi;
        private readonly IArtworkGenerator _artworkGenerator;

        public ConsoleApplication(IListeningHabitsApi listeningHabitsApi, IArtworkGenerator artworkGenerator)
        {
            _listeningHabitsApi = listeningHabitsApi;
            _artworkGenerator = artworkGenerator;
        }

        public async Task Run(string[] args)
        {
            var username = "CrossProduct";
            var outputPath = "output.png";

            if (args.Length >= 1)
            {
                username = args[0];
            }

            try
            {
                var topAlbums = await _listeningHabitsApi.FetchTopAlbums(username);

                await _artworkGenerator.CreateImageWithAlbums(topAlbums.Albums, outputPath);

                Console.WriteLine($"Artwork is generated and exported to {outputPath}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Apologies, something went wrong: {e.Message}");
            }
        }
    }

    class Program
    {
        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IListeningHabitsApi, ListeningHabitsApi>();
            services.AddTransient<IArtworkGenerator, SquareCollageArtworkGenerator>();

            services.AddTransient<ConsoleApplication>();

            return services;
        }

        static async Task Main(string[] args)
        {
            // Create service collection and configure our services
            var services = ConfigureServices();

            // Generate a provider
            var serviceProvider = services.BuildServiceProvider();

            // Kick off our actual code
            await serviceProvider.GetService<ConsoleApplication>().Run(args);
        }
    }
}
