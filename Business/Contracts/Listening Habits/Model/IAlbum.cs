using System;
using System.Collections.Generic;

namespace ListeningHabitsArtworkGenerator.Business.Contracts.ListeningHabits.Model
{
    public interface IAlbum
    {
        string Name { get; set; }

        IArtist Artist { get; set; }

        List<IAlbumImage> Images { get; set; }

        string BestQualityImageUrl { get; }
    }
}
