namespace BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PALASH.BSP_BIKE")]
    public partial class BSP_BIKE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BSP_BIKE()
        {
            BSP_INSURANCE = new HashSet<BSP_INSURANCE>();
            BSP_JOB_CARD = new HashSet<BSP_JOB_CARD>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BIKE_ID { get; set; }

        [StringLength(10)]
        public string ENGINE_ID { get; set; }

        [StringLength(10)]
        public string REGSTR_ID { get; set; }

        public int? CUST_ID { get; set; }

        public int? MODEL_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSP_INSURANCE> BSP_INSURANCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSP_JOB_CARD> BSP_JOB_CARD { get; set; }

        public virtual BSP_CUSTOMER BSP_CUSTOMER { get; set; }

        public virtual BSP_BIKE_MODELS_ALL BSP_BIKE_MODELS_ALL { get; set; }
    }
}
