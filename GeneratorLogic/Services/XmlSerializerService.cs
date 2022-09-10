using GeneratorLogic.Interfaces;
using System.Xml.Serialization;

namespace GeneratorLogic.Services
{
    public class XmlSerializerService : ISerializerService
    {
        public string FilePath { get; }

        public XmlSerializerService(string filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public void Serialize<TObject>(TObject serializableObject)
        {
            var formatter = new XmlSerializer(typeof(TObject));
            using var fileStream = new FileStream(FilePath, FileMode.OpenOrCreate);
            formatter.Serialize(fileStream, serializableObject);
        }

        public TObject Deserialize<TObject>()
        {
            var formatter = new XmlSerializer(typeof(TObject));
            using var fileStream = new FileStream(FilePath, FileMode.OpenOrCreate);

            var deserializedObject = formatter.Deserialize(fileStream);

            if (deserializedObject is null)
                throw new NullReferenceException("Deserialized object can not be null");

            return (TObject)deserializedObject;
        }
    }
}
