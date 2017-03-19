using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace SerializerTest
{
    public class Config
    {
        // ---------------------------------------------------------------------------------------
        // Insert configurable values below:
        public int Id;
        public string Name;

        // Sets the default values of all configurable values.
        private void SetDefaultValues()
        {
            this.Id = 0;
            this.Name = "hello";
        }

        // ---------------------------------------------------------------------------------------

        // Name of configuration file.
        [XmlIgnore]
        public const string FileName = "config.xml";

        // Globally accessable instance of loaded configuration.
        [XmlIgnore]
        public static Config Instance { get; private set; }

        // Empty constructor for XmlSerializer.
        public Config()
        {
        }

        // Used to load the default configuration if Load() fails.
        public static void Default()
        {
            Config.Instance = new Config();
            Config.Instance.SetDefaultValues();
        }

        // Loads the configuration from file.
        public static void Load()
        {
            var serializer = new XmlSerializer(typeof(Config));

            using (var fStream = new FileStream(Config.FileName, FileMode.Open))
                Config.Instance = (Config)serializer.Deserialize(fStream);
        }

        // Saves the configuration to file.
        public void Save()
        {
            var serializer = new XmlSerializer(typeof(Config));

            using (var fStream = new FileStream(Config.FileName, FileMode.Create))
                serializer.Serialize(fStream, this);
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Loading settings...");

            try
            {
                Config.Load();
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load config from file. Loading default config.");
                Config.Default();
            }

            //print console message
            Console.WriteLine("Id: " + Config.Instance.Id);
            Console.WriteLine("Name: " + Config.Instance.Name);

            //Config.Instance.Id++;
            //Config.Instance.Name += Config.Instance.Name;            

            //saving config file
            Console.WriteLine("Saving config...");
            Config.Instance.Save();

            Console.WriteLine("Restart app to see changes.");
            Console.ReadLine();
        }
    }
}
