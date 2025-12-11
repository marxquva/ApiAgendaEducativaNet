using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiAgendaEducativaNet.Models.Entities
{
    [Table("sis_empresa")]
    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_empresa")]
        public int IdEmpresa { get; set; }
        [Column("codigo")]
        public Guid Codigo { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(120)]
        [Column("nombre_empresa")]
        public string NombreEmpresa { get; set; }
        [Column("descripcion")]
        public string Descripcion { get; set; }
        [Column("imagen")]
        public string Imagen { get; set; }
        [Column("direccion")]
        public string Direccion { get; set; }
        [Column("dominio")]
        public string Dominio { get; set; }
        [Column("nota_maxima")]
        public string NotaMaxima { get; set; }
        [Column("nota_minima")]
        public string NotaMinima { get; set; }
        [Column("estado")]
        public int Estado { get; set; } = 1;
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [Column("fecha_modificacion")]
        public DateTime? FechaModificacion { get; set; }

        // 🔗 Llave foránea explícita
        [Column("id_tipo_empresa")]
        [ForeignKey(nameof(TipoEmpresa))]  // Indica que esta columna es la FK
        public int? IdTipoEmpresa { get; set; } = 2;

        // Navegación
        public TipoEmpresa TipoEmpresa { get; set; }
    }
}
