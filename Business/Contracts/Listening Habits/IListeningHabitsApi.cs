using System.Threading.Tasks;
using ListeningHabitsArtworkGenerator.Business.Contracts.ListeningHabits.Model;

namespace ListeningHabitsArtworkGenerator.Business.Contracts.ListeningHabits
{
    public enum TopAlbumPeriod
    {
        OneMonth,
        ThreeMonths,
        SixMonths,
        OneYear,
        AllTime
    }

    public interface IListeningHabitsApi
    {
        Task<ITopAlbums> FetchTopAlbums(string username, TopAlbumPeriod period = TopAlbumPeriod.OneYear);
    }
}
