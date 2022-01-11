using Data.Models.Locations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models.Security
{
    [Table("User", Schema = "Security")]
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string ProfilePicture { get; set; }
        public bool IsDeleleted { get; set; }

        #region Social Linkes
        public string Facebook { get; set; }
        public string Linkedin { get; set; }
        public string Twitter { get; set; }
        public string Mobile { get; set; }
        #endregion

        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
