using GeneratorLogic.Interfaces;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace GeneratorLogic.Services
{
    public class JsonSerializerService : ISerializerService
    {
        private readonly JsonSerializerOptions _options;

        public string FilePath { get; }

        public JsonSerializerService(string filePath)
        {
            FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));

            _options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public void Serialize<TObject>(TObject serializableObject)
        {
            var json = JsonSerializer.Serialize(serializableObject, _options);
            File.WriteAllText(FilePath, json);
        }

        public TObject Deserialize<TObject>()
        {
            var text = File.ReadAllText(FilePath);
            var deserializedObject = JsonSerializer.Deserialize<TObject>(text, _options);

            if (deserializedObject is null)
                throw new NullReferenceException("Deserialized object can not be null");

            return deserializedObject;
        }
    }
}
