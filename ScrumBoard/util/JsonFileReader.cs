using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ScrumBoardLib.model;

namespace ScrumBoard.util
{
    public static class JsonFileReader
    {
        public static List<UserStory> ReadJson(string fileName)
        {
            /*
             * if first time (no file exists) - create a file with an empty list
             */
            if (!File.Exists(fileName))
            {
                JsonFileWriter.WriteToJson(new List<UserStory>(), fileName);
            }

            using (var jReader = File.OpenText(fileName))
            {
                return JsonSerializer.Deserialize<List<UserStory>>(jReader.ReadToEnd());
            }
        }

        public static List<T> ReadJsonGeneric<T>(string fileName)
        {
            /*
             * if first time (no file exists) - create a file with an empty list
             */
            if (!File.Exists(fileName))
            {
                JsonFileWriter.WriteToJsonGeneric(new List<T>(), fileName);
            }

            using (var jReader = File.OpenText(fileName))
            {
                return JsonSerializer.Deserialize<List<T>>(jReader.ReadToEnd());
            }
        }

    }
}
