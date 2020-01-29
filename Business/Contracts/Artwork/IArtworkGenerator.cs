using System.Threading.Tasks;
using System.Collections.Generic;

public interface IArtworkGenerator {
    Task CreateImageWithAlbums(List<IAlbum> albums, string outputPath);   
}