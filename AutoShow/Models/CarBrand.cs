namespace AutoShow.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarBrand")]
    public partial class CarBrand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarBrand()
        {
            CarModel = new HashSet<CarModel>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarBrandId { get; set; }

        [Required]
        [StringLength(30)]
        public string CarBrandName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarModel> CarModel { get; set; }
    }
}
