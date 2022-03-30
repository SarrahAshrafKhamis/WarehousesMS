namespace WarehousesProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WarehouseItem")]
    public partial class WarehouseItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WarehouseItem()
        {
            ExportPermissions = new HashSet<ExportPermission>();
            ImportPermissions = new HashSet<ImportPermission>();
        }

        [StringLength(50)]
        public string WarehouseName { get; set; }

        public int? ItemCode { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpiaryDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ProductionDate { get; set; }

        public int? Quantity { get; set; }

        public virtual Item Item { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExportPermission> ExportPermissions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportPermission> ImportPermissions { get; set; }
    }
}
