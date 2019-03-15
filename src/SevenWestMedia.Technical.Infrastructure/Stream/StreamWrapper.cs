using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SevenWestMedia.Technical.Infrastructure.Stream
{
    public class StreamWrapper : IStreamWrapper
    {
        private readonly ILogger<StreamWrapper> _logger;

        public StreamWrapper(ILogger<StreamWrapper> logger)
        {
            _logger = logger;
        }

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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to open file or parse json content.");
                return default(T);
            }
        }
    }
}