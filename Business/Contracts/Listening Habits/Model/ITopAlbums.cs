using System;
using System.Collections.Generic;

namespace ListeningHabitsArtworkGenerator.Business.Contracts.ListeningHabits.Model
{
    public interface ITopAlbums
    {
        List<IAlbum> Albums { get; set; }
    }
}
