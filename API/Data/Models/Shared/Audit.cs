using System;

namespace Data.Models.Shared
{
    public class Audit
    {
        public string CreatedById { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ChangedById { get; set; }
        public DateTime? ChangedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
