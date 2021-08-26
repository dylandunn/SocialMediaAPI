using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models.PostModels
{
    public class PostCreate
    {
        [Required]
        [MinLength(1, ErrorMessage = "Please enter a title for your post")]
        [MaxLength(50, ErrorMessage = "Title is too long.")]
        public string Title { get; set; }

        [MaxLength(140)]
        public string Text { get; set; }
    }
}
