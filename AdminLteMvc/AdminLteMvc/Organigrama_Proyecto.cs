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
    
    public partial class Organigrama_Proyecto
    {
        public int id { get; set; }
        public Nullable<int> Codigo_Empleado { get; set; }
        public Nullable<int> Padre { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<int> Codigo_Proyecto { get; set; }
    }
}