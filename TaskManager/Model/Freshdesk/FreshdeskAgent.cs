namespace ApportTaskManager.Model.Freshdesk
{
    public class FreshdeskAgent
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Contact
        {
            public bool? active { get; set; }
            public string? email { get; set; }
            public string? job_title { get; set; }
            public string? language { get; set; }
            public DateTime? last_login_at { get; set; }
            public string? mobile { get; set; }
            public string? name { get; set; }
            public string? phone { get; set; }
            public string? time_zone { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
        }

        public class Availability
        {
            public string? channel { get; set; }
            public bool? available { get; set; }
            public DateTime? available_since { get; set; }
        }


        public long? id { get; set; }
        public string? org_agent_id { get; set; }
        public List<long>? group_ids { get; set; }
        public List<object>? org_group_ids { get; set; }
        public bool? available { get; set; }
        public DateTime? available_since { get; set; }
        public bool? occasional { get; set; }
        public int? ticket_scope { get; set; }
        public List<long>? role_ids { get; set; }
        public List<object>? skill_ids { get; set; }
        public string? type { get; set; }
        public DateTime? last_active_at { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string? signature { get; set; }
        public Contact? contact { get; set; }
        public int? scope { get; set; }
        public List<Availability>? availability { get; set; }



    }
}
