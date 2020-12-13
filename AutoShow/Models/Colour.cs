namespace AutoShow.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Colour")]
    public partial class Colour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Colour()
        {
            PaintedModel = new HashSet<PaintedModel>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ColourId { get; set; }

        [Required]
        [StringLength(30)]
        public string ColourName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PaintedModel> PaintedModel { get; set; }
    }
}
