using System.Threading.Tasks;

public interface IListeningHabitsApi {        
    public Task<ITopAlbums> FetchTopAlbums(string username);
}