using MVC_CRUD.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD.Models.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitInStock { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}