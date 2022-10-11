namespace ApportTaskManager.Model.TimeLog
{
    public class ProjectCategories
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Properties
        {
            public string? TotalRecord { get; set; }
            public string? TotalPage { get; set; }
            public string? PageNumber { get; set; }
            public int? ProjectCategoryID { get; set; }
            public string? Name { get; set; }
            public bool? IsActive { get; set; }
            public string? ProductNo { get; set; }
            public string? ID { get; set; }
        }

        public class Entity
        {
            public Properties? properties { get; set; }
        }

        public class Link
        {
            public string? Href { get; set; }
            public string? Rel { get; set; }
        }

            public Properties? properties { get; set; }
            public List<Entity>? entities { get; set; }
            public List<Link>? links { get; set; }


    }
}
