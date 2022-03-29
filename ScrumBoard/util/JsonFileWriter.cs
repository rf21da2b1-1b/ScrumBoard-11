using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ScrumBoardLib.model;

namespace ScrumBoard.util
{
    public static class JsonFileWriter
    {
        public static void WriteToJson(List<UserStory> liste, string JsonFileName)
        {
            using (FileStream fs = File.Create(JsonFileName))
            {
                var writter = new Utf8JsonWriter(fs, new JsonWriterOptions()
                    {
                        SkipValidation = false,
                        Indented = true
                    }
                );
                JsonSerializer.Serialize<UserStory[]>(writter, liste.ToArray());
            }
        }

        public static void WriteToJsonGeneric<T>(List<T> liste, string JsonFileName)
        {
            using (FileStream fs = File.Create(JsonFileName))
            {
                var writter = new Utf8JsonWriter(fs, new JsonWriterOptions()
                    {
                        SkipValidation = false,
                        Indented = true
                    }
                );
                JsonSerializer.Serialize<T[]>(writter, liste.ToArray());
            }
        }

    }
}
