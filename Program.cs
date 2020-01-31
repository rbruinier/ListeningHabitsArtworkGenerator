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
            var periodAsString = "ThreeMonths";
            var outputPath = "output.png";

            if (args.Length >= 1)
            {
                username = args[0];
            }

            if (args.Length >= 2)
            {
                periodAsString = args[1];
            }

            try
            {
                var period = Enum.Parse<TopAlbumPeriod>(periodAsString);

                var topAlbums = await _listeningHabitsApi.FetchTopAlbums(username, period);

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

            services.AddSingleton<IListeningHabitsApi, ListeningHabitsApi>();
            services.AddSingleton<IArtworkGenerator, SquareCollageArtworkGenerator>();

            services.AddTransient<ConsoleApplication>();

            services.AddHttpClient();

            return services;
        }

        static async Task Main(string[] args)
        {
            var services = ConfigureServices();

            var serviceProvider = services.BuildServiceProvider();

            await serviceProvider.GetService<ConsoleApplication>().Run(args);
        }
    }
}
