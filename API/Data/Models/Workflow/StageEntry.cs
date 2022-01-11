using Data.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.WorkFlow
{
    [Table("StageEntry", Schema = "Workflow")]
    public class StageEntry : Audit
    {
        public int Id { get; set; }
        public int StageId { get; set; }
        public bool IsHead { get; set; }
        public int EntityEntryId { get; set; }
        public Stage Stage { get; set; }
    }
}
