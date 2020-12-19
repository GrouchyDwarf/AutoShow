namespace AutoShow.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarModel")]
    public partial class CarModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarModel()
        {
            PaintedModel = new HashSet<PaintedModel>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarModelId { get; set; }

        [Required]
        [StringLength(30)]
        public string CarModelName { get; set; }

        public int CarBrandId { get; set; }

        public int CountryId { get; set; }

        public int TechnicalInformationId { get; set; }

        public virtual CarBrand CarBrand { get; set; }

        public virtual Country Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaintedModel> PaintedModel { get; set; }

        public virtual TechnicalInformation TechnicalInformation { get; set; }
    }
}
