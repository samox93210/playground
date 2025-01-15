using System;
using System.IO;
using Newtonsoft.Json; // Ensure you have Newtonsoft.Json installed via NuGet

namespace SimpleJsonWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the file path
            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "EventCatalog");
            Directory.CreateDirectory(directoryPath); // Ensure the directory exists

            string fileName = "eventCatalog.json";
            FileInfo eventCatalogFile = new FileInfo(Path.Combine(directoryPath, fileName));

            // Create a sample object to serialize to JSON
            var eventCatalog = new
            {
                EventId = 1,
                EventName = "Sample Event",
                EventDate = DateTime.Now.ToString("yyyy-MM-dd"),
                Location = "Virtual"
            };

            // Serialize the object to JSON
            string json = JsonConvert.SerializeObject(eventCatalog, Formatting.Indented);

            // Write the JSON string to the file
            File.WriteAllText(eventCatalogFile.FullName, json);

            Console.WriteLine($"JSON has been written to: {eventCatalogFile.FullName}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
