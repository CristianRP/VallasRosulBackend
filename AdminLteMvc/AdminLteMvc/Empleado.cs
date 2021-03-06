//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminLteMvc
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleado()
        {
            this.Equipo_Proyecto = new HashSet<Equipo_Proyecto>();
            this.Tarea = new HashSet<Tarea>();
            this.Empleado1 = new HashSet<Empleado>();
            this.Proyecto = new HashSet<Proyecto>();
            this.Proyecto1 = new HashSet<Proyecto>();
        }
    
        public int Codigo_Empleado { get; set; }
        public Nullable<int> Codigo_Departamento { get; set; }
        public Nullable<int> Codigo_Empresa { get; set; }
        public Nullable<int> Codigo_Puesto { get; set; }
        public string Primer_Nombre { get; set; }
        public string Segundo_Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public string Sexo { get; set; }
        public string Telefono { get; set; }
        public string Extension { get; set; }
        public string Correo { get; set; }
        public string Codigo_Empleado_Externo { get; set; }
        public string Estado { get; set; }
        public Nullable<int> ReportID { get; set; }
    
        public virtual Empresa Empresa { get; set; }
        public virtual Puesto Puesto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Equipo_Proyecto> Equipo_Proyecto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tarea> Tarea { get; set; }
        public virtual Departamento Departamento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empleado> Empleado1 { get; set; }
        public virtual Empleado Empleado2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proyecto> Proyecto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Proyecto> Proyecto1 { get; set; }
    }
}
