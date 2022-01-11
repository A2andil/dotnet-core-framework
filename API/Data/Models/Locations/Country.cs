using Data.Models.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.Locations
{
    [Table("Country", Schema = "Locations")]

    public class Country : Audit
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string PhoneCode { get; set; }
    }
}
