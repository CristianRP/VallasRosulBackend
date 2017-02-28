namespace AdminLteMvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contrato")]
    public partial class Contrato
    {
        [Key]
        public int CodigoContrato { get; set; }

        [StringLength(50)]
        public string Descripcion { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaInicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaFIn { get; set; }

        public int? CodigoProveedor { get; set; }

        public int? CodigoProyecto { get; set; }

        public virtual Proveedores Proveedores { get; set; }
         
    }
}
