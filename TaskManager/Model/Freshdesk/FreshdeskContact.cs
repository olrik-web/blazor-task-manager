namespace ApportTaskManager.Model.Freshdesk
{
    public class FreshdeskContact
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class CustomFields
        {
        }

        public bool? active { get; set; }
        public object? address { get; set; }
        public object? description { get; set; }
        public string? email { get; set; }
        public object? id { get; set; }
        public string? job_title { get; set; }
        public string? language { get; set; }
        public string? mobile { get; set; }
        public string? name { get; set; }
        public string? phone { get; set; }
        public string? time_zone { get; set; }
        public object? twitter_id { get; set; }
        public CustomFields? custom_fields { get; set; }
        public object? facebook_id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public object? csat_rating { get; set; }
        public string? preferred_source { get; set; }
        public object? company_id { get; set; }
        public List<object>? other_companies { get; set; }
        public object? unique_external_id { get; set; }


    }
}
