namespace GeneratorLogic.Interfaces
{
    public interface ISerializerService
    {
        string FilePath { get; }
        void Serialize<TObject>(TObject serializableObject);
        TObject Deserialize<TObject>();
    }
}
