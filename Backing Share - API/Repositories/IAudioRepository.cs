namespace Backing_Share___API.Repositories
{
    public interface IAudioRepository
    {
        void StoreInDB(string location, string filename, int project, int userId);
    }
}