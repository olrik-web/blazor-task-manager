namespace ApportTaskManager.Model.Freshdesk
{
    public class FreshdeskCompanies
    {
        public class Company
        {
            public long? id { get; set; }
            public string? name { get; set; }
        }
        public List<Company>? companies { get; set; }
    }
}
