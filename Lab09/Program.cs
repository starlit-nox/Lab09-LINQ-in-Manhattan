using Newtonsoft.Json;

// data models
public class FeatureCollection
{
    public string Type { get; set; }
    public List<Feature> Features { get; set; }
}

public class Properties
{
    public string Neighborhood { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
}

class Program
{
    static void Main()
    {
        // read the JSON data from the file
        string jsonFilePath = "data.json";
        string jsonData = File.ReadAllText(jsonFilePath);

        // deserialize the JSON data into the featurecollection object
        FeatureCollection featureCollection = JsonConvert.DeserializeObject<FeatureCollection>(jsonData);

        // get the list of features from the featurecollection
        List<Feature> features = featureCollection.Features;

        // Question 1: Output all of the neighborhoods in this data list (final total: 147 neighborhoods)
        // select all neighborhoods from the features and store in a list
        var allNeighborhoods = features.Select(feature => feature.Properties.Neighborhood).ToList();
        PrintResults("Question 1: Output all of the neighborhoods", allNeighborhoods);

        // Question 2: Filter out all the neighborhoods that do not have any names (final total: 143)
        // use where to filter out empty neighborhoods and then select non-empty neighborhoods into a list
        var nonEmptyNeighborhoods = features
            .Where(feature => !string.IsNullOrEmpty(feature.Properties.Neighborhood))
            .Select(feature => feature.Properties.Neighborhood)
            .ToList();
        PrintResults("Question 2: Filter out all the neighborhoods that do not have any names", nonEmptyNeighborhoods);

        // Question 3: Remove the duplicates (final total: 39 neighborhoods)
        // use distinct to remove duplicate neighborhoods from the non-empty neighborhoods list
        var distinctNeighborhoods = features
            .Where(feature => !string.IsNullOrEmpty(feature.Properties.Neighborhood))
            .Select(feature => feature.Properties.Neighborhood)
            .Distinct()
            .ToList();
        PrintResults("Question 3: Remove the duplicates", distinctNeighborhoods);

        // Question 4: Rewrites the queries from above and consolidate all into one single query.
        // use the same queries as Question 3 but consolidate into a single LINQ statement
        var consolidatedQuery = features
            .Where(feature => !string.IsNullOrEmpty(feature.Properties.Neighborhood))
            .Select(feature => feature.Properties.Neighborhood)
            .Distinct()
            .ToList();
        PrintResults("Question 4: Rewrites the queries and consolidate into one single query", consolidatedQuery);

        // Question 5: Rewrite at least one of these Questions only using the opposing method.
        // use LINQ query syntax (from ... where ... select) instead of LINQ method syntax
        var queryResult = (from feature in features
                           where !string.IsNullOrEmpty(feature.Properties.Neighborhood)
                           select feature.Properties.Neighborhood).Distinct().ToList();
        PrintResults("Question 5: Rewrite using LINQ query", queryResult);
    }

    // print the results along with the question description
    static void PrintResults(string queryDescription, List<string> results)
    {
        Console.WriteLine(queryDescription + $" (final total: {results.Count} neighborhoods):");
        foreach (var item in results)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }
}
