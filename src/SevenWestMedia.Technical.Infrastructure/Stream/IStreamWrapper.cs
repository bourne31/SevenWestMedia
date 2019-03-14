namespace SevenWestMedia.Technical.Infrastructure.Stream
{
    public interface IStreamWrapper
    {
        T ReadFromStream<T>(string templateFilePath);
    }
}