using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JsonStorageManager;

public class JsonStorageManager<T>(string jsonFilePath)
{
    public List<T>? Read()
    {
        using StreamReader reader = new StreamReader(jsonFilePath);
        string jsonStringified = reader.ReadToEnd();
        List<T>? jsonDeserialized = JsonSerializer.Deserialize<List<T>>(jsonStringified);
        return jsonDeserialized;
    }

    public void Write(List<T> objects)
    {
        using StreamWriter writer = new StreamWriter(jsonFilePath);
        JsonSerializerOptions serializerOptions = new JsonSerializerOptions { WriteIndented = true };
        string jsonStringified = JsonSerializer.Serialize(objects, serializerOptions);
        writer.Write(jsonStringified);
    }
}
