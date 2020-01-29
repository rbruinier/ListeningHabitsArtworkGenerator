using System.Threading.Tasks;

public interface IListeningHabitsApi {        
    Task<ITopAlbums> FetchTopAlbums(string username);
}