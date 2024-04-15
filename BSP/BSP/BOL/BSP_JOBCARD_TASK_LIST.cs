namespace BOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PALASH.BSP_JOBCARD_TASK_LIST")]
    public partial class BSP_JOBCARD_TASK_LIST
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TASK_CODE_ID { get; set; }

        public int? JOB_CARD_NO { get; set; }

        public virtual BSP_JOB_CARD BSP_JOB_CARD { get; set; }
    }
}
