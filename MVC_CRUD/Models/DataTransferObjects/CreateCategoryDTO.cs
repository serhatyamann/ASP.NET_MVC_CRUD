using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_CRUD.Models.DataTransferObjects
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Must to type into name")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Must to type into name")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        public string Description { get; set; }
    }
}