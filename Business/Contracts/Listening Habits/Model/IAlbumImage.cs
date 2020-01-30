using System;

namespace ListeningHabitsArtworkGenerator.Business.Contracts.ListeningHabits.Model
{
    public interface IAlbumImage
    {
        string Size { get; set; }

        string Url { get; set; }
    }
}
