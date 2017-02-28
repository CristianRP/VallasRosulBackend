namespace AdminLteMvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Visita")]
    public partial class Visita
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Visita()
        {
            Imagen = new HashSet<Imagen>();
        }

        [Key]
        public int Codigo_Visita { get; set; }

        public int? Codigo_Publicidad { get; set; }

        public int? Codigo_Problema { get; set; }

        [StringLength(250)]
        public string Observaciones { get; set; }

        public int? codSupervisor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Imagen> Imagen { get; set; }

        public virtual Problema Problema { get; set; }
         
    }
}
