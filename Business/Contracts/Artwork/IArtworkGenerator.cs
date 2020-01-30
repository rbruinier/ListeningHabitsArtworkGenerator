using System.Collections.Generic;
using System.Threading.Tasks;
using ListeningHabitsArtworkGenerator.Business.Contracts.ListeningHabits.Model;

namespace ListeningHabitsArtworkGenerator.Business.Contracts.Artwork
{
    public interface IArtworkGenerator
    {
        Task CreateImageWithAlbums(List<IAlbum> albums, string outputPath);
    }
}
