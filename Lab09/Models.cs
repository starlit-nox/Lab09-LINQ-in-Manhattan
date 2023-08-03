namespace Lab09
{
    public class Property
    {
        public string Zip { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Borough { get; set; }
        public string Neighborhood { get; set; }
        public string County { get; set; }
    }
    public class Feature
    {
        public string Type { get; set; }
        public Property Properties { get; set; }
    }
}
