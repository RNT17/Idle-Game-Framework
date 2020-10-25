using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public class JsonManager
{
    public static void Serialize<T>(object obj, string fileName = "")
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string jsonString = JsonSerializer.Serialize(obj, options);
        Console.WriteLine(jsonString);        
        
        if (fileName != string.Empty)
            File.WriteAllText(fileName, jsonString);
    }

    public static T Deserialize<T>(string jsonString)
    {
        return JsonSerializer.Deserialize<T>(jsonString);
    }
}