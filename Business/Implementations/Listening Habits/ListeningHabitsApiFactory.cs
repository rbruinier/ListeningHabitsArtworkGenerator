using ListeningHabitsArtworkGenerator.Business.Contracts.ListeningHabits;
using ListeningHabitsArtworkGenerator.Business.Implementations.ListeningHabits.LastFm;

namespace ListeningHabitsArtworkGenerator.Business.Implementations.ListeningHabits
{
    public class ListeningHabitsApiFactory
    {
        public static IListeningHabitsApi Create()
        {
            return new ListeningHabitsApi();
        }
    }
}
