namespace AutoShow.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BodyType")]
    public partial class BodyType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BodyType()
        {
            TechnicalInformation = new HashSet<TechnicalInformation>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BodyTypeId { get; set; }

        [Required]
        [StringLength(30)]
        public string BodyTypeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TechnicalInformation> TechnicalInformation { get; set; }
    }
}
