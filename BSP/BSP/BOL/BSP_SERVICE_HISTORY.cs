namespace BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PALASH.BSP_SERVICE_HISTORY")]
    public partial class BSP_SERVICE_HISTORY
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SERVICE_HISTORY_ID { get; set; }

        public int? CUSTOMER_ID { get; set; }

        public int? INVOICENO { get; set; }

        public virtual BSP_CUSTOMER BSP_CUSTOMER { get; set; }

        public virtual BSP_PAYMENT BSP_PAYMENT { get; set; }
    }
}
