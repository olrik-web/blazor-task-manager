using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApportTaskManager.Model.TimeLog
{
    public class Project
    {
        public int? AccountManagerID { get; set; }
        public int? CurrencyID { get; set; }
        public int? CustomerID { get; set; }
        public int? DepartmentID { get; set; }
        public string? Description { get; set; }
        public int? LegalEntityID { get; set; }
        public string? Name { get; set; }
        public int? PartnerID { get; set; }
        public int? ProjectCategoryID { get; set; }
        public string? ProjectEndDate { get; set; }
        public int? ProjectManagerID { get; set; }
        public string? ProjectNo { get; set; }
        public string? ProjectStartDate { get; set; }
        public int? ProjectTemplateID { get; set; }
        public int? ProjectTypeID { get; set; }


    }
}
