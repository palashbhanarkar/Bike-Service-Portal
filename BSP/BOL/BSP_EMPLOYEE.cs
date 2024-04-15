namespace BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PALASH.BSP_EMPLOYEE")]
    public partial class BSP_EMPLOYEE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BSP_EMPLOYEE()
        {
            BSP_PAYMENT = new HashSet<BSP_PAYMENT>();
            BSP_JOB_CARD = new HashSet<BSP_JOB_CARD>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EMPLOYEE_ID { get; set; }

        public int? DEPARTMENT_NO { get; set; }

        [Column(TypeName = "float")]
        public decimal? EMP_SALARY { get; set; }

        [StringLength(20)]
        public string FIRST_NAME { get; set; }

        public DateTime? HIRE_DATE { get; set; }

        [StringLength(20)]
        public string JOB_ROLE { get; set; }

        [StringLength(20)]
        public string LAST_NAME { get; set; }

        [StringLength(20)]
        public string PASSWORD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSP_PAYMENT> BSP_PAYMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSP_JOB_CARD> BSP_JOB_CARD { get; set; }
    }
}
