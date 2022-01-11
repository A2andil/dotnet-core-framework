using Data.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.Locations
{
    [Table("City", Schema = "Locations")]
    public class City : Audit
    { 
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
