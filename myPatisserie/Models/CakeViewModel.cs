using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myPatisserie.Models
{
    public class CakeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "name Alanı kesin gereklidir :D:)")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(10,ErrorMessage ="bi 10 harf gir ")]
        public string Description { get; set; }
        
        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        public List<CommentViewModel> Comments { get; set; }
        
    }
}