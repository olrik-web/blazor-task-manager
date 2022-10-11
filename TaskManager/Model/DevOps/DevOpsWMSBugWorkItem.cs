using Newtonsoft.Json;

namespace 
{
    public class DevOpsWMSBugWorkItem
    {

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Avatar
        {
            public string? href { get; set; }
        }

        public class Links
        {
            public Avatar? avatar { get; set; }
            public Self? self { get; set; }
            public WorkItemUpdates? workItemUpdates { get; set; }
            public WorkItemRevisions? workItemRevisions { get; set; }
            public WorkItemComments? workItemComments { get; set; }
            public Html? html { get; set; }
            public WorkItemType? workItemType { get; set; }
            public Fields? fields { get; set; }
        }

        public class SystemAssignedTo
        {
            public string? displayName { get; set; }
            public string? url { get; set; }
            public Links? _links { get; set; }
            public string? id { get; set; }
            public string? uniqueName { get; set; }
            public string? imageUrl { get; set; }
            public string? descriptor { get; set; }
        }

        public class SystemCreatedBy
        {
            public string? displayName { get; set; }
            public string? url { get; set; }
            public Links? _links { get; set; }
            public string? id { get; set; }
            public string? uniqueName { get; set; }
            public string? imageUrl { get; set; }
            public string? descriptor { get; set; }
        }

        public class SystemChangedBy
        {
            public string? displayName { get; set; }
            public string? url { get; set; }
            public Links? _links { get; set; }
            public string? id { get; set; }
            public string? uniqueName { get; set; }
            public string? imageUrl { get; set; }
            public string? descriptor { get; set; }
        }

        public class Fields
        {
            [JsonProperty("System.AreaPath")]
            public string? SystemAreaPath { get; set; }

            [JsonProperty("System.TeamProject")]
            public string? SystemTeamProject { get; set; }

            [JsonProperty("System.IterationPath")]
            public string? SystemIterationPath { get; set; }

            [JsonProperty("System.WorkItemType")]
            public string? SystemWorkItemType { get; set; }

            [JsonProperty("System.State")]
            public string? SystemState { get; set; }

            [JsonProperty("System.Reason")]
            public string? SystemReason { get; set; }

            [JsonProperty("System.AssignedTo")]
            public SystemAssignedTo? SystemAssignedTo { get; set; }

            [JsonProperty("System.CreatedDate")]
            public DateTime SystemCreatedDate { get; set; }

            [JsonProperty("System.CreatedBy")]
            public SystemCreatedBy? SystemCreatedBy { get; set; }

            [JsonProperty("System.ChangedDate")]
            public DateTime SystemChangedDate { get; set; }

            [JsonProperty("System.ChangedBy")]
            public SystemChangedBy? SystemChangedBy { get; set; }

            [JsonProperty("System.CommentCount")]
            public int SystemCommentCount { get; set; }

            [JsonProperty("System.Title")]
            public string? SystemTitle { get; set; }
            [JsonProperty("Custom.Timelogproject")]
            public string? CustomTimelogproject { get; set; }

            [JsonProperty("Custom.FreshDesk")]
            public string? CustomFreshDesk { get; set; }

            [JsonProperty("Microsoft.VSTS.Common.Priority")]
            public int MicrosoftVSTSCommonPriority { get; set; }

            [JsonProperty("Microsoft.VSTS.Common.StateChangeDate")]
            public DateTime MicrosoftVSTSCommonStateChangeDate { get; set; }

            [JsonProperty("Microsoft.VSTS.Common.Severity")]
            public string? MicrosoftVSTSCommonSeverity { get; set; }

            [JsonProperty("Microsoft.VSTS.Common.ValueArea")]
            public string? MicrosoftVSTSCommonValueArea { get; set; }

            [JsonProperty("Custom.Customer")]
            public string? CustomCustomer { get; set; }

            [JsonProperty("Custom.Category")]
            public string? CustomCategory { get; set; }

            [JsonProperty("Custom.Application")]
            public string? CustomApplication { get; set; }

            [JsonProperty("Custom.BackupName")]
            public string? CustomBackupName { get; set; }
            [JsonProperty("Custom.Process")]
            public string? CustomProcess { get; set; }

            [JsonProperty("Custom.Workdescription")]
            public string? CustomWorkdescription { get; set; }


            [JsonProperty("Custom.Devbranch")]
            public string? CustomDevbranch { get; set; }

            [JsonProperty("Microsoft.VSTS.TCM.SystemInfo")]
            public string? MicrosoftVSTSTCMSystemInfo { get; set; }

            [JsonProperty("Microsoft.VSTS.TCM.ReproSteps")]
            public string? MicrosoftVSTSTCMReproSteps { get; set; }

            [JsonProperty("System.Tags")]
            public string? SystemTags { get; set; }
            public string? href { get; set; }
        }

        public class Self
        {
            public string? href { get; set; }
        }

        public class WorkItemUpdates
        {
            public string? href { get; set; }
        }

        public class WorkItemRevisions
        {
            public string? href { get; set; }
        }

        public class WorkItemComments
        {
            public string? href { get; set; }
        }

        public class Html
        {
            public string? href { get; set; }
        }

        public class WorkItemType
        {
            public string? href { get; set; }
        }


        public int id { get; set; }
        public int rev { get; set; }
        public Fields? fields { get; set; }
        public Links? _links { get; set; }
        public string? url { get; set; }



    }
}