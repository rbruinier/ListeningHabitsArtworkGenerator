using System.Collections.Generic;

public interface IAlbum {
    public string Name { get; set; }

    public IArtist Artist { get; set; }

    public List<IAlbumImage> Images { get; set; }

    public string BestQualityImageUrl { get; }
}
