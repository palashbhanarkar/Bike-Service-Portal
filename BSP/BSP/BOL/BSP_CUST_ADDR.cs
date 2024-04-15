namespace BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PALASH.BSP_CUST_ADDR")]
    public partial class BSP_CUST_ADDR
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ADDR_ID { get; set; }

        [StringLength(20)]
        public string CITY { get; set; }

        [StringLength(20)]
        public string COUNTRY { get; set; }

        [StringLength(20)]
        public string STATE { get; set; }

        public int? CUST_ID { get; set; }

        public virtual BSP_CUSTOMER BSP_CUSTOMER { get; set; }
    }
}
