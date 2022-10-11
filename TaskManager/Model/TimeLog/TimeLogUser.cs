namespace ApportTaskManager.Model.TimeLog
{
    public class TimeLogUser
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Properties
        {
            public string? TotalRecord { get; set; }
            public string? TotalPage { get; set; }
            public string? PageNumber { get; set; }
            public int? UserID { get; set; }
            public string? ID { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Initials { get; set; }
            public bool? IsActive { get; set; }
            public string? UserType { get; set; }
        }

        public class Link
        {
            public string? Href { get; set; }
            public string? Rel { get; set; }
        }

        public class Entity
        {
            public Properties? properties { get; set; }
            public List<Link>? Links { get; set; }
        }

        public Properties? properties { get; set; }
        public List<Entity>? entities { get; set; }
        public List<Link>? links { get; set; }
    }
}
