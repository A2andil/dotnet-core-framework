using Data.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.WorkFlow
{
    [Table("Workflow", Schema = "Workflow")]
    public class Workflow : Audit
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
    }
}
