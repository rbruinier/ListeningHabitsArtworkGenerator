using System.Collections.Generic;

public interface IAlbum {
    string Name { get; set; }

    IArtist Artist { get; set; }

    List<IAlbumImage> Images { get; set; }

    string BestQualityImageUrl { get; }
}
