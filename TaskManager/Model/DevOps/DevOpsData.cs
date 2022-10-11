namespace 
{
    public class DevOpsData
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class DependentField
        {
            public string referenceName { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public int count { get; set; }
        public List<Value> value { get; set; }

        public class Value
        {
            public string defaultValue { get; set; }
            public List<string> allowedValues { get; set; }
            public bool alwaysRequired { get; set; }
            public List<DependentField> dependentFields { get; set; }
            public string referenceName { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public string helpText { get; set; }
        }


    }
}
