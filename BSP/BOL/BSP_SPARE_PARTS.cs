namespace BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PALASH.BSP_SPARE_PARTS")]
    public partial class BSP_SPARE_PARTS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PART_CODE { get; set; }

        [StringLength(20)]
        public string PART_DESC { get; set; }

        [Column(TypeName = "float")]
        public decimal? PART_RATE { get; set; }

        public int? MODEL_CODE { get; set; }

        public int? REPAIR_CODE { get; set; }

        public virtual BSP_BIKE_MODELS_ALL BSP_BIKE_MODELS_ALL { get; set; }

        public virtual BSP_REPAIR_MASTER BSP_REPAIR_MASTER { get; set; }
    }
}
