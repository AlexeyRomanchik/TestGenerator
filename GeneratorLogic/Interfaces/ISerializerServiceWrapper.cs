namespace GeneratorLogic.Interfaces
{
    public interface ISerializerServiceWrapper
    {
        ISerializerService GetXmlSerializer(string filePath);
        ISerializerService GetJsonSerializerService(string filePath);
    }
}
