using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MyEntities
{
    public class User : BaseEntity
    {
        [DisplayName("User Name")]
        [Required]
        public string UserName { get; set; }

        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DefaultValue(0)]
        [Description("0:normal user, 1:admin user")]
        public int UserType { get; set; }

        public virtual List<Comment> Comments { get; set; }

    }
}
