namespace BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PALASH.BSP_INSURANCE")]
    public partial class BSP_INSURANCE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int INSURANCE_ID { get; set; }

        [Column(TypeName = "float")]
        public decimal INSURANCE_AMOUNT { get; set; }

        public DateTime? INSURANCE_DATE { get; set; }

        public int? POLICYNO { get; set; }

        public int? BIKE_ID { get; set; }

        public virtual BSP_BIKE BSP_BIKE { get; set; }
    }
}
