namespace BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PALASH.BSP_CUSTOMER")]
    public partial class BSP_CUSTOMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BSP_CUSTOMER()
        {
            BSP_APPOINTMENT = new HashSet<BSP_APPOINTMENT>();
            BSP_BIKE = new HashSet<BSP_BIKE>();
            BSP_CUST_ADDR = new HashSet<BSP_CUST_ADDR>();
            BSP_SERVICE_HISTORY = new HashSet<BSP_SERVICE_HISTORY>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CUST_ID { get; set; }

        public DateTime? DATE_OF_BIRTH { get; set; }

        [StringLength(20)]
        public string EMAIL { get; set; }

        [StringLength(20)]
        public string F_NAME { get; set; }

        [StringLength(10)]
        public string GENDER { get; set; }

        [StringLength(20)]
        public string L_NAME { get; set; }

        [StringLength(10)]
        public string MOBILE { get; set; }

        [StringLength(20)]
        public string PASSWORD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSP_APPOINTMENT> BSP_APPOINTMENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSP_BIKE> BSP_BIKE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSP_CUST_ADDR> BSP_CUST_ADDR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSP_SERVICE_HISTORY> BSP_SERVICE_HISTORY { get; set; }
    }
}
