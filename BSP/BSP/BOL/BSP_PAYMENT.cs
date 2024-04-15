namespace BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PALASH.BSP_PAYMENT")]
    public partial class BSP_PAYMENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BSP_PAYMENT()
        {
            BSP_SERVICE_HISTORY = new HashSet<BSP_SERVICE_HISTORY>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int INVOICENO { get; set; }

        [StringLength(10)]
        public string DISCOUNT_CODE { get; set; }

        public DateTime? INVOICE_DATE { get; set; }

        [Required]
        [StringLength(10)]
        public string PAYMENT_STATUS { get; set; }

        [StringLength(20)]
        public string PAYMENT_TYPE { get; set; }

        [Column(TypeName = "float")]
        public decimal TOTAL_AMOUNT { get; set; }

        public int? JOB_CARD_NO { get; set; }

        public int? EMPLOYEE_ID { get; set; }

        public int? APPOINTMENT_ID { get; set; }

        public virtual BSP_APPOINTMENT BSP_APPOINTMENT { get; set; }

        public virtual BSP_EMPLOYEE BSP_EMPLOYEE { get; set; }

        public virtual BSP_JOB_CARD BSP_JOB_CARD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSP_SERVICE_HISTORY> BSP_SERVICE_HISTORY { get; set; }
    }
}
