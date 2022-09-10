using GeneratorLogic.Interfaces;

namespace GeneratorLogic.Services
{
    public class SerializerServiceWrapper : ISerializerServiceWrapper
    {
        public ISerializerService GetXmlSerializer(string filePath)
        {
            return new XmlSerializerService(filePath);
        }

        public ISerializerService GetJsonSerializerService(string filePath)
        {
            return new JsonSerializerService(filePath);
        }
    }
}
