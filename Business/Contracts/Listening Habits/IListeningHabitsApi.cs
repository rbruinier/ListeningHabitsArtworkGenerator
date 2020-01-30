using System;
using System.Threading.Tasks;
using ListeningHabitsArtworkGenerator.Business.Contracts.ListeningHabits.Model;

namespace ListeningHabitsArtworkGenerator.Business.Contracts.ListeningHabits
{
    public interface IListeningHabitsApi
    {
        Task<ITopAlbums> FetchTopAlbums(string username);
    }
}
