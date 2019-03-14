using Newtonsoft.Json;
using System.IO;

namespace SevenWestMedia.Technical.Infrastructure.Stream
{
    public class StreamWrapper : IStreamWrapper
    {
        public T ReadFromStream<T>(string templateFilePath)
        {
            try
            {
                using (var reader = File.OpenText(templateFilePath))
                {
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        var serializer = new JsonSerializer();
                        var result = serializer.Deserialize<T>(jsonReader);
                        return result;
                    }
                }
            }
            catch
            {
                //TODO: add error logging
                return default(T);
            }
        }
    }
}