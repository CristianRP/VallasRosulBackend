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
    
    public partial class Imagen
    {
        public int CodigoImagen { get; set; }
        public byte[] Imagen1 { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> Codigo_Visita { get; set; }
        public string Estado { get; set; }
    
        public virtual Visita Visita { get; set; }
    }
}