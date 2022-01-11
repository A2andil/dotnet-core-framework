using Data.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.WorkFlow
{
    [Table("StageTarget", Schema = "Workflow")]
    public class StageTarget : Audit
    {
        public int Id { get; set; }
        public int FromStageId { get; set; }
        public int ToStageId { get; set; }
        public int SNPStageId { get; set; }
        public virtual Stage FromStage { get; set; }
        public virtual Stage ToStage { get; set; }
        public virtual Stage SNPStage { get; set; }
    }
}
