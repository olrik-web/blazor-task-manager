namespace ApportTaskManager.Model.Freshdesk
{
    public class FreshdeskContacts
    {
        public class CustomFields
        {
        }

        public class Company
        {
            public object? id { get; set; }
            public bool? view_all_tickets { get; set; }
            public string? name { get; set; }
            public object? avatar { get; set; }
        }

        public class Result
        {
            public bool? active { get; set; }
            public string? address { get; set; }
            public CustomFields? custom_fields { get; set; }
            public object? description { get; set; }
            public string? email { get; set; }
            public List<string>? other_emails { get; set; }
            public object? id { get; set; }
            public string? job_title { get; set; }
            public string? language { get; set; }
            public string? mobile { get; set; }
            public string? name { get; set; }
            public string? phone { get; set; }
            public string? time_zone { get; set; }
            public object? twitter_id { get; set; }
            public object? facebook_id { get; set; }
            public object? external_id { get; set; }
            public DateTime? created_at { get; set; }
            public DateTime? updated_at { get; set; }
            public object? company_id { get; set; }
            public object? unique_external_id { get; set; }
            public Company? company { get; set; }
            public List<object>? other_companies { get; set; }
        }

        public List<Result>? results { get; set; }
        public int? total { get; set; }


    }
}
