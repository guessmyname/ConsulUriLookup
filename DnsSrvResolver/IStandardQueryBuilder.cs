namespace DnsSrvResolver
{
    public interface IStandardQueryBuilder
    {
        string Scheme { get; }
        string GetServiceQuery();
    }
}