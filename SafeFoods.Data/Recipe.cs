﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeFoods.Data
{
    public class Recipe 
    {
        [Key]
        public int RecipeId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [MaxLength(30,ErrorMessage = " There are too many characters in this field.")]
        [MinLength(2,ErrorMessage = "Please add at least 2 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = " There are too many characters in this field.")]
        [MinLength(2, ErrorMessage = "Please add at least 2 characters")]
        public string Description { get; set; }
        [Required]
        [MaxLength(2000, ErrorMessage = " There are too many characters in this field.")]
        [MinLength(50, ErrorMessage = "Please add at least 50 characters")]
        public string Instructions { get; set; }
        [Range(1,10,ErrorMessage = "Please choose a number between 1 and 10")]
        public int? Rating { get; set; }
        [Display(Name = "Preparation Time in minutes")]
        [Required]
        public TimeSpan PrepTime { get; set; } 
        [Display(Name = "Total Coocking Time")]
        [Required]
        public int CookTime { get; set; }
        [Required]
        [Display(Name = "Created On")]
        public DateTimeOffset DateAdded { get; set; }
        [Display(Name = "Modified On")]
        public DateTimeOffset? DateModified { get; set; }
        public virtual ICollection<IngredientTag> ListOfIngredients { get; set; }

        public Recipe() 
        {
            ListOfIngredients = new HashSet<IngredientTag>();
        }
    }
}
