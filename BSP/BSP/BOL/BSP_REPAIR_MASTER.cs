namespace BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PALASH.BSP_REPAIR_MASTER")]
    public partial class BSP_REPAIR_MASTER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BSP_REPAIR_MASTER()
        {
            BSP_SPARE_PARTS = new HashSet<BSP_SPARE_PARTS>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int REPAIR_CODE { get; set; }

        [Column(TypeName = "float")]
        public decimal? ADDNL_CHRG { get; set; }

        [Column(TypeName = "float")]
        public decimal? LABOUR_CHRG { get; set; }

        [StringLength(50)]
        public string REPAIR_DESCR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSP_SPARE_PARTS> BSP_SPARE_PARTS { get; set; }
    }
}
