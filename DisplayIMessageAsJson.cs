        public void DisplayResponseJson(object responedRequest, bool printToTxtFile=false)
        {
            JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(responedRequest, options);
            Console.WriteLine($"\n{DateTime.Now:G}\n_______________________________________________");
            Console.WriteLine(jsonString);
            if (printToTxtFile) new Logger().WriteToLogFile(jsonString);
        }

    internal class Logger
    {
        public void WriteToLogFile(string jsonString)
        {
            using (var sw = new StreamWriter("./logHeartbeats.json", true))
            {
                sw.Write(jsonString);
                sw.Write(Environment.NewLine);
            }
        }
    }
