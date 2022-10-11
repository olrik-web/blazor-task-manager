namespace ApportTaskManager.Model.Freshdesk
{
    public class FreshdeskCase
    {
        public class CustomFields
        {
            public string? cf_impact { get; set; }
            public string? dropdownmenu { get; set; }
            public object? cf_devops { get; set; }
        }
        public List<object>? cc_emails { get; set; }
        public List<object>? fwd_emails { get; set; }
        public List<object>? reply_cc_emails { get; set; }
        public List<object>? ticket_cc_emails { get; set; }
        public bool? fr_escalated { get; set; }
        public bool? spam { get; set; }
        public object? email_config_id { get; set; }
        public long? group_id { get; set; }
        public int? priority { get; set; }
        public long? requester_id { get; set; }
        public long? responder_id { get; set; }
        public int? source { get; set; }
        public long? company_id { get; set; }
        public int? status { get; set; }
        public string? subject { get; set; }
        public object? association_type { get; set; }
        public object? support_email { get; set; }
        public object? to_emails { get; set; }
        public object? product_id { get; set; }
        public int? id { get; set; }
        public string? type { get; set; }
        public DateTime? due_by { get; set; }
        public DateTime? fr_due_by { get; set; }
        public bool? is_escalated { get; set; }
        public string? description { get; set; }
        public string? description_text { get; set; }
        public CustomFields? custom_fields { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public List<object>? tags { get; set; }
        public List<object>? attachments { get; set; }
        public object? source_additional_info { get; set; }
        public object? nr_due_by { get; set; }
        public bool? nr_escalated { get; set; }
    }
}