namespace BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PALASH.BSP_JOB_CARD")]
    public partial class BSP_JOB_CARD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BSP_JOB_CARD()
        {
            BSP_PAYMENT = new HashSet<BSP_PAYMENT>();
            BSP_JOBCARD_TASK_LIST = new HashSet<BSP_JOBCARD_TASK_LIST>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JOB_CARD_NO { get; set; }

        public DateTime? JOB_CARD_DATE { get; set; }

        public int? KMS_READING { get; set; }

        [StringLength(30)]
        public string MECHANIC_COMMENTS { get; set; }

        public int? VEH_INWARD_TIME { get; set; }

        public int? APPOINTMENT_ID { get; set; }

        public int? BIKE_ID { get; set; }

        public int? EMPLOYEE_ID { get; set; }

        public int? SERVICE_TYPE_CODE { get; set; }

        public int? JOB_STATUS_CODE { get; set; }

        public virtual BSP_APPOINTMENT BSP_APPOINTMENT { get; set; }

        public virtual BSP_BIKE BSP_BIKE { get; set; }

        public virtual BSP_EMPLOYEE BSP_EMPLOYEE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSP_PAYMENT> BSP_PAYMENT { get; set; }

        public virtual BSP_SERVICE_TYPE BSP_SERVICE_TYPE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSP_JOBCARD_TASK_LIST> BSP_JOBCARD_TASK_LIST { get; set; }

        public virtual BSP_JOB_STATUS_UPDATE BSP_JOB_STATUS_UPDATE { get; set; }
    }
}
