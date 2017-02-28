namespace AdminLteMvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Proveedores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedores()
        {
            Contrato = new HashSet<Contrato>();
        }

        [Key]
        public int Codigo { get; set; }

        [StringLength(250)]
        public string Nombre { get; set; }

        [StringLength(250)]
        public string Contacto { get; set; }

        [StringLength(50)]
        public string Telefono1 { get; set; }

        [StringLength(50)]
        public string Telefono2 { get; set; }

        [StringLength(50)]
        public string CorreoElectronico { get; set; }

        [StringLength(250)]
        public string Observaciones { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato> Contrato { get; set; }
    }
}
