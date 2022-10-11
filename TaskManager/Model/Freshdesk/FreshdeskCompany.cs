namespace ApportTaskManager.Model.Freshdesk
{
    public class FreshdeskCompany
    {
        public class CustomFields
        {
            public string? product { get; set; }
        }

        public long? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public object? note { get; set; }
        public List<string>? domains { get; set; }
        public CustomFields? custom_fields { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string? health_score { get; set; }
        public string? account_tier { get; set; }
        public DateTime? renewal_date { get; set; }
        public object? industry { get; set; }
    }
}
