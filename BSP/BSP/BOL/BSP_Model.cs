namespace BOL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BSP_Model : DbContext
    {
        public BSP_Model()
            : base("name=BSP_Model")
        {
        }

        public virtual DbSet<BSP_APPOINTMENT> BSP_APPOINTMENT { get; set; }
        public virtual DbSet<BSP_APPOINTMENT_SLOTNO> BSP_APPOINTMENT_SLOTNO { get; set; }
        public virtual DbSet<BSP_BIKE> BSP_BIKE { get; set; }
        public virtual DbSet<BSP_BIKE_MODELS_ALL> BSP_BIKE_MODELS_ALL { get; set; }
        public virtual DbSet<BSP_CASHIER> BSP_CASHIER { get; set; }
        public virtual DbSet<BSP_CUST_ADDR> BSP_CUST_ADDR { get; set; }
        public virtual DbSet<BSP_CUSTOMER> BSP_CUSTOMER { get; set; }
        public virtual DbSet<BSP_EMPLOYEE> BSP_EMPLOYEE { get; set; }
        public virtual DbSet<BSP_INSURANCE> BSP_INSURANCE { get; set; }
        public virtual DbSet<BSP_JOB_CARD> BSP_JOB_CARD { get; set; }
        public virtual DbSet<BSP_JOB_STATUS_UPDATE> BSP_JOB_STATUS_UPDATE { get; set; }
        public virtual DbSet<BSP_JOBCARD_TASK_LIST> BSP_JOBCARD_TASK_LIST { get; set; }
        public virtual DbSet<BSP_PAYMENT> BSP_PAYMENT { get; set; }
        public virtual DbSet<BSP_REPAIR_MASTER> BSP_REPAIR_MASTER { get; set; }
        public virtual DbSet<BSP_SERVICE_HISTORY> BSP_SERVICE_HISTORY { get; set; }
        public virtual DbSet<BSP_SERVICE_TYPE> BSP_SERVICE_TYPE { get; set; }
        public virtual DbSet<BSP_SPARE_PARTS> BSP_SPARE_PARTS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BSP_APPOINTMENT_SLOTNO>()
                .Property(e => e.STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_BIKE>()
                .Property(e => e.ENGINE_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_BIKE>()
                .Property(e => e.REGSTR_ID)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_BIKE_MODELS_ALL>()
                .Property(e => e.BRAND_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_BIKE_MODELS_ALL>()
                .Property(e => e.MODEL_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_BIKE_MODELS_ALL>()
                .HasMany(e => e.BSP_BIKE)
                .WithOptional(e => e.BSP_BIKE_MODELS_ALL)
                .HasForeignKey(e => e.MODEL_ID);

            modelBuilder.Entity<BSP_CASHIER>()
                .Property(e => e.CASHIER_FNAME)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_CASHIER>()
                .Property(e => e.CASHIER_LNAME)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_CUST_ADDR>()
                .Property(e => e.CITY)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_CUST_ADDR>()
                .Property(e => e.COUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_CUST_ADDR>()
                .Property(e => e.STATE)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_CUSTOMER>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_CUSTOMER>()
                .Property(e => e.F_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_CUSTOMER>()
                .Property(e => e.GENDER)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_CUSTOMER>()
                .Property(e => e.L_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_CUSTOMER>()
                .Property(e => e.MOBILE)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_CUSTOMER>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_CUSTOMER>()
                .HasMany(e => e.BSP_SERVICE_HISTORY)
                .WithOptional(e => e.BSP_CUSTOMER)
                .HasForeignKey(e => e.CUSTOMER_ID);

            modelBuilder.Entity<BSP_EMPLOYEE>()
                .Property(e => e.EMP_SALARY)
                .HasPrecision(38, 0);

            modelBuilder.Entity<BSP_EMPLOYEE>()
                .Property(e => e.FIRST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_EMPLOYEE>()
                .Property(e => e.JOB_ROLE)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_EMPLOYEE>()
                .Property(e => e.LAST_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_EMPLOYEE>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_INSURANCE>()
                .Property(e => e.INSURANCE_AMOUNT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<BSP_JOB_CARD>()
                .Property(e => e.MECHANIC_COMMENTS)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_JOB_STATUS_UPDATE>()
                .Property(e => e.JOB_STATUS_REMARK)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_PAYMENT>()
                .Property(e => e.DISCOUNT_CODE)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_PAYMENT>()
                .Property(e => e.PAYMENT_STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_PAYMENT>()
                .Property(e => e.PAYMENT_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_PAYMENT>()
                .Property(e => e.TOTAL_AMOUNT)
                .HasPrecision(38, 0);

            modelBuilder.Entity<BSP_REPAIR_MASTER>()
                .Property(e => e.ADDNL_CHRG)
                .HasPrecision(38, 0);

            modelBuilder.Entity<BSP_REPAIR_MASTER>()
                .Property(e => e.LABOUR_CHRG)
                .HasPrecision(38, 0);

            modelBuilder.Entity<BSP_REPAIR_MASTER>()
                .Property(e => e.REPAIR_DESCR)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_SERVICE_TYPE>()
                .Property(e => e.SERVICE_TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_SPARE_PARTS>()
                .Property(e => e.PART_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<BSP_SPARE_PARTS>()
                .Property(e => e.PART_RATE)
                .HasPrecision(38, 0);
        }
    }
}
