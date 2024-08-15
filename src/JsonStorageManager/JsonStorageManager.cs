using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JsonStorageManager;

public class JsonStorageManager<T>(string jsonFilePath)
{
    public T? Read()
    {
        using StreamReader reader = new StreamReader(jsonFilePath);
        string jsonStringified = reader.ReadToEnd();
        return JsonSerializer.Deserialize<T>(jsonStringified);
    }

    public void Write(T obj)
    {
        using StreamWriter writer = new StreamWriter(jsonFilePath);
        JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
        writer.Write(JsonSerializer.Serialize(obj, jsonSerializerOptions));
    }
}
