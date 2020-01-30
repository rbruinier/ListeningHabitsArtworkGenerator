using System;

namespace ListeningHabitsArtworkGenerator.Business.Contracts.ListeningHabits.Model
{
    public interface IArtist
    {
        string Name { get; set; }
        string MBId { get; set; }
    }
}
