//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductManagement.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class Product
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Product Name is required.")]
        [StringLength(50)]
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid Unit Price")]
        public double UnitPrice { get; set; }
        public int CategoryID { get; set; }
    
        public virtual Category Category { get; set; }
        //public SelectList CategoryList { get; set; }
    }
}
