namespace ApportTaskManager.Model.TimeLog
{
    public class TimeLogCustomer
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Properties
        {
            public string? TotalRecord { get; set; }
            public string? TotalPage { get; set; }
            public string? PageNumber { get; set; }
            public int? CustomerID { get; set; }
            public string? ID { get; set; }
            public string? Name { get; set; }
            public string? No { get; set; }
            public int? DefaultMileageDistance { get; set; }
            public int? CustomerStatusID { get; set; }
        }

        public class Link
        {
            public string? Href { get; set; }
            public string? Rel { get; set; }
        }

        public class Entity
        {
            public Properties? properties { get; set; }
            public List<Link>? links { get; set; }
        }

            public Properties? properties { get; set; }
            public List<Entity>? entities { get; set; }
            public List<Link>? links { get; set; }
        


    }

}
