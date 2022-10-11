using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApportTaskManager.Model.TimeLog
{
    public class Projects
    {
        public class Properties
        {
            public string? TotalRecord { get; set; }
            public string? TotalPage { get; set; }
            public string? PageNumber { get; set; }
            public int? ProjectID { get; set; }
            public string? ID { get; set; }
            public string? Name { get; set; }
            public string? No { get; set; }
            public bool? ExpenseIsBillable { get; set; }
            public int? CustomerID { get; set; }
            public object? Customer { get; set; }
        }

        public class Link
        {
            public string? Href { get; set; }
            public string? Rel { get; set; }
        }

        public class Field
        {
            public string? Name { get; set; }
            public string? Type { get; set; }
            public List<string>? Enums { get; set; }
        }

        public class Action
        {
            public string? Name { get; set; }
            public string? Title { get; set; }
            public string? Method { get; set; }
            public object? Href { get; set; }
            public string? Type { get; set; }
            public List<Field>? Fields { get; set; }
        }

        public class Entity
        {
            public Properties? Properties { get; set; }
            public List<Link>? Links { get; set; }
            public List<Action>? Actions { get; set; }
        }

            public Properties? properties { get; set; }
            public List<Entity>? entities { get; set; }
            public List<Link>? links { get; set; }
            public List<Action>? actions { get; set; }
    }
}
