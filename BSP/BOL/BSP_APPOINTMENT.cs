namespace BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PALASH.BSP_APPOINTMENT")]
    public partial class BSP_APPOINTMENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BSP_APPOINTMENT()
        {
            BSP_JOB_CARD = new HashSet<BSP_JOB_CARD>();
            BSP_PAYMENT = new HashSet<BSP_PAYMENT>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int APPOINTMENT_ID { get; set; }

        public DateTime? APPOINTMENT_DATE { get; set; }

        public int? APPOINTMENT_SLOTNO { get; set; }

        public int? CUST_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSP_JOB_CARD> BSP_JOB_CARD { get; set; }

        public virtual BSP_CUSTOMER BSP_CUSTOMER { get; set; }

        public virtual BSP_APPOINTMENT_SLOTNO BSP_APPOINTMENT_SLOTNO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSP_PAYMENT> BSP_PAYMENT { get; set; }
    }
}
