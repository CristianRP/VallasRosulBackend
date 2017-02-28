namespace AdminLteMvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int idUsuario { get; set; }

        [Required]
        public string nombreUsuario { get; set; }

        [Required]
        public string userPassword { get; set; }

        [Required]
        public string idDispositivo { get; set; }

        [Required]
        public string primerNombre { get; set; }

        public string segundoNombre { get; set; }

        [Required]
        public string primerApellido { get; set; }

        [Required]
        public string segundoApellido { get; set; }

        public int idProyecto { get; set; }
         
    }
}
