using MVC_CRUD.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_CRUD.Models.DataTransferObjects
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Must to type into name")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Must to type into description")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Must to type into unit price")]
        [DataType(DataType.Currency, ErrorMessage = "Must to type currency")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Must to type into stock")]
        public short UnitInStock { get; set; }

        [Required(ErrorMessage = "Must to choose category")]
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }
    }
}