namespace InternetShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using DataAnnotationsExtensions;

    public partial class item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public item()
        {
            order_item = new HashSet<order_item>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[-à-ÿÀ-ß¸¨a-zA-Z0-9]+$", ErrorMessage = "Incorrect name")]
        
        public string name { get; set; }

        [StringLength(500)]
        public string description { get; set; }

        public int? category_id { get; set; }

        [Required]
        [Range(0.01, 20000.0, ErrorMessage = "Price must be more than null")]
        public decimal price { get; set; }
        
        [Min(0)]
        public double? quantity { get; set; }

        public virtual category category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_item> order_item { get; set; }

        public string image_url { get; set; }
    }
}
