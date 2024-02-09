namespace Distributedsqlservercache.InterFaces
{
    public interface IDistributedCachAdapter
    {
        T Get<T>(string Key);
        void Set<T>(string key,T value);
    }
   
}
