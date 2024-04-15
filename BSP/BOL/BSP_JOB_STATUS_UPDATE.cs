namespace BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PALASH.BSP_JOB_STATUS_UPDATE")]
    public partial class BSP_JOB_STATUS_UPDATE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BSP_JOB_STATUS_UPDATE()
        {
            BSP_JOB_CARD = new HashSet<BSP_JOB_CARD>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JOB_STATUS_CODE { get; set; }

        [StringLength(30)]
        public string JOB_STATUS_REMARK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSP_JOB_CARD> BSP_JOB_CARD { get; set; }
    }
}
