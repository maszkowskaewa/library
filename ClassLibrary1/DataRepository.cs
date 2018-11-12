public class DataRepository
{
    public DataContext DataContext { get; private set; }

    public DataRepository()
    {
        DataContext = new DataContext();
}