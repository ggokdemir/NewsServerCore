using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsServerMVC.Models
{
 

        public class NewsModel
        {
            [Display(Name = "ID of the article.")]
            [Required(ErrorMessage = "You need to give an ID to the article.")]
            [Range(1, 999, ErrorMessage = " You need to input a number less than 100")]
            public int newsId { get; set; }

            [Required(ErrorMessage = "What is the title of the article?")]
            [Display(Name = "Title of the article.")]
            public String newsTitle { get; set; }

            [Required(ErrorMessage = "It must start with 'http://' and ends with image extension.(.png, .jpg, or .jpeg)")]
            [Display(Name = "Add an image location to article.")]
            public String newsImage { get; set; }

            [Required(ErrorMessage = "Itself of the article is necessary.")]
            [Display(Name = "Content of the article.")]
            public String newsContent { get; set; }

            [Required(ErrorMessage = "Type World, Economics, Sport or Education here.")]
            [Display(Name = "Genre of the article.")]
            public String newsTopic { get; set; }

            //[Display(Name = "Date published.")]
            public DateTime newsDate { get; set; }

        }
    

}
