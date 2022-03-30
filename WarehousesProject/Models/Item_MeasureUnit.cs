namespace WarehousesProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item_MeasureUnit
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string MeasureUnit { get; set; }

        public virtual Item Item { get; set; }

        public override string ToString()
        {
            return MeasureUnit;
        }
    }
}
