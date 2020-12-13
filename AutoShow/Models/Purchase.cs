namespace AutoShow.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Purchase")]
    public partial class Purchase
    {
        [Column(TypeName = "date")]
        public DateTime PurchaseDate { get; set; }

        public bool Delivery { get; set; }

        public int PaymentTypeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime PaymentDate { get; set; }

        public int ClientId { get; set; }

        public decimal Price { get; set; }

        public int ManagerId { get; set; }

        public int ProductId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PurchaseId { get; set; }

        public virtual Client Client { get; set; }

        public virtual Manager Manager { get; set; }

        public virtual PaymentType PaymentType { get; set; }

        public virtual Product Product { get; set; }
    }
}
