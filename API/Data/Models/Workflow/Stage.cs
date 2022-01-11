using Data.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.WorkFlow
{
    [Table("Stage", Schema = "Workflow")]
    public class Stage : Audit
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public int ProcessId { get; set; }
        public Process Process { get; set; }
    }
}
