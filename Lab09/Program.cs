namespace Lab09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // this will read the json data
            string jsonFilePath = "data.json";
            string jsonData = File.ReadAllText(jsonFilePath);

            // deserializes json into featurecollection
            FeatureCollection featureCollection = JsonConvert.DeserializeObject<FeatureCollection>(jsonData);
        }
        public class FeatureCollection
        {
            public string Type { get; set; }
            public List<Feature> Features { get; set; }
        }
    }
}