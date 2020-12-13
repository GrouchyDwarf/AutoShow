namespace AutoShow.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TechnicalInformation")]
    public partial class TechnicalInformation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TechnicalInformation()
        {
            CarModel = new HashSet<CarModel>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TechnicalInformationId { get; set; }

        public int BodyTypeId { get; set; }

        public int DoorsAmount { get; set; }

        public int SeatsAmount { get; set; }

        public int EngineDisplacement { get; set; }

        public int EngineTypeId { get; set; }

        public int EngineLocationId { get; set; }

        public virtual BodyType BodyType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarModel> CarModel { get; set; }

        public virtual EngineLocation EngineLocation { get; set; }

        public virtual EngineType EngineType { get; set; }
    }
}
