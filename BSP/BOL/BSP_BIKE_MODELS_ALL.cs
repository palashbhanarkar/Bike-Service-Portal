namespace BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PALASH.BSP_BIKE_MODELS_ALL")]
    public partial class BSP_BIKE_MODELS_ALL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BSP_BIKE_MODELS_ALL()
        {
            BSP_BIKE = new HashSet<BSP_BIKE>();
            BSP_SPARE_PARTS = new HashSet<BSP_SPARE_PARTS>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MODEL_CODE { get; set; }

        public int? BHP { get; set; }

        [StringLength(20)]
        public string BRAND_NAME { get; set; }

        public int? CC { get; set; }

        [StringLength(20)]
        public string MODEL_NAME { get; set; }

        public int WEIGHT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSP_BIKE> BSP_BIKE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSP_SPARE_PARTS> BSP_SPARE_PARTS { get; set; }
    }
}
