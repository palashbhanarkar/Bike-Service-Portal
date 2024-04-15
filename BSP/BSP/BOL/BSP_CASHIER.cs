namespace BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PALASH.BSP_CASHIER")]
    public partial class BSP_CASHIER
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CASHIERID { get; set; }

        [Required]
        [StringLength(20)]
        public string CASHIER_FNAME { get; set; }

        [Required]
        [StringLength(20)]
        public string CASHIER_LNAME { get; set; }
    }
}
