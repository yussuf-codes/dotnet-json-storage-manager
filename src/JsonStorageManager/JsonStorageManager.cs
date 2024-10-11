using System.IO;
using System.Text.Json;

namespace JsonStorageManager;

public class JsonStorageManager<T>
{
    private readonly string _jsonFilePath;

    public JsonStorageManager(string jsonFilePath)
    {
        _jsonFilePath = jsonFilePath;
    }

    public T? Read()
    {
        using StreamReader reader = new StreamReader(_jsonFilePath);
        string jsonString = reader.ReadToEnd();
        T? obj = JsonSerializer.Deserialize<T>(jsonString);
        return obj;
    }

    public void Write(T obj)
    {
        JsonSerializerOptions serializerOptions = new JsonSerializerOptions() { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(obj, serializerOptions);
        using StreamWriter writer = new StreamWriter(_jsonFilePath);
        writer.Write(jsonString);
    }
}
