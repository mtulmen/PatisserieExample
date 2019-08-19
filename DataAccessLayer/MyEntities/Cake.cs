using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.MyEntities
{
   public class Cake: BaseEntity
    {
      
        [Required(ErrorMessage ="name Alanı kesin gereklidir :D:)")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        
        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
