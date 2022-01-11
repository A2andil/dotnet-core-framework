using Data.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.WorkFlow
{
    [Table("Process", Schema = "Workflow")]
    public class Process : Audit
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public string EntityName { get; set; }
        public int WorkflowId { get; set; }
        public Workflow Workflow { get; set; }
    }
}
