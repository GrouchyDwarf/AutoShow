namespace AutoShow.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EngineType")]
    public partial class EngineType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EngineType()
        {
            TechnicalInformation = new HashSet<TechnicalInformation>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EngineTypeId { get; set; }

        [Required]
        [StringLength(30)]
        public string EngineTypeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TechnicalInformation> TechnicalInformation { get; set; }
    }
}
