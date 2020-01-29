public class ListeningHabitsApiFactory {
    public static IListeningHabitsApi create() {
        return new LastFm.ListeningHabitsApi();
    }
}