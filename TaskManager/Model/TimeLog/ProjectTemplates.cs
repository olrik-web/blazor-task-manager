namespace ApportTaskManager.Model.TimeLog
{
    public class ProjectTemplates
    {

        public class Properties
        {
            public string? ProjectTemplateGuid { get; set; }
            public int? ProjectTemplateID { get; set; }
            public string? ProjectTemplateName { get; set; }
            public string? ProjectTemplateDescription { get; set; }
            public bool? IsActive { get; set; }
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


        public List<Entity>? entities { get; set; }
        public List<Link>? links { get; set; }
    }

}
