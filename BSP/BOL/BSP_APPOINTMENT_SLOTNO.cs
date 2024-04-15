namespace BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PALASH.BSP_APPOINTMENT_SLOTNO")]
    public partial class BSP_APPOINTMENT_SLOTNO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BSP_APPOINTMENT_SLOTNO()
        {
            BSP_APPOINTMENT = new HashSet<BSP_APPOINTMENT>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int APPOINTMENT_SLOTNO { get; set; }

        public int? SLOT_TIME { get; set; }

        [StringLength(255)]
        public string STATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BSP_APPOINTMENT> BSP_APPOINTMENT { get; set; }
    }
}
