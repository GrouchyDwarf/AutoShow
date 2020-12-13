namespace AutoShow.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supply")]
    public partial class Supply
    {
        public int ProductId { get; set; }

        [Column(TypeName = "date")]
        public DateTime SupplyDate { get; set; }

        public int Quantity { get; set; }

        public int ProviderId { get; set; }

        public decimal Price { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupplyId { get; set; }

        public virtual Product Product { get; set; }

        public virtual Provider Provider { get; set; }
    }
}
