namespace AdminLteMvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Imagen")]
    public partial class Imagen
    {
        [Key]
        public int CodigoImagen { get; set; }

        [Column("Imagen", TypeName = "image")]
        public byte[] Imagen1 { get; set; }

        public DateTime? fecha { get; set; }

        public int? Codigo_Visita { get; set; }

        public virtual Visita Visita { get; set; }
    }
}
