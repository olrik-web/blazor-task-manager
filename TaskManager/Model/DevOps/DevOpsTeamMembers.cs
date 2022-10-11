namespace 
{
    public class DevOpsTeamMembers
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Avatar
        {
            public string? href { get; set; }
        }

        public class Identity
        {
            public string? displayName { get; set; }
            public string? url { get; set; }
            public Links? _links { get; set; }
            public string? id { get; set; }
            public string? uniqueName { get; set; }
            public string? imageUrl { get; set; }
            public string? descriptor { get; set; }
        }

        public class Links
        {
            public Avatar? avatar { get; set; }
        }

        public List<Value>? value { get; set; }
        public int? count { get; set; }


        public class Value
        {
            public Identity? identity { get; set; }
            public bool? isTeamAdmin { get; set; }
        }
    }
}
