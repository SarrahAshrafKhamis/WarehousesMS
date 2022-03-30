namespace WarehousesProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImportPermission")]
    public partial class ImportPermission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ImportPermission()
        {
            WarehouseItems = new HashSet<WarehouseItem>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string WarehouseName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public int? ImporterId { get; set; }

        public virtual Importer Importer { get; set; }

        public virtual Warhouse Warhouse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseItem> WarehouseItems { get; set; }
    }
}
