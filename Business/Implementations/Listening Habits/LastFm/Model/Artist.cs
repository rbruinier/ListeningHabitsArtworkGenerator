using System;
using ListeningHabitsArtworkGenerator.Business.Contracts.ListeningHabits.Model;

namespace ListeningHabitsArtworkGenerator.Business.Implementations.ListeningHabits.LastFm.Model
{
    public struct Artist : IArtist
    {
        public string Name { get; set; }
        public string MBId { get; set; }
    }
}
