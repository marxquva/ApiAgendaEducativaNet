using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiAgendaEducativaNet.Models.Entities
{
    [Table("sis_tipo_empresa")]
    public class TipoEmpresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_tipo_empresa")]
        public int IdTipoEmpresa { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("nombre_tipo_empresa")]
        public string NombreTipoEmpresa { get; set; }

        // En C# 5.0, todas las referencias pueden ser null por defecto
        [Column("descripcion")]
        public string Descripcion { get; set; }
        [Column("estado")]
        public int Estado { get; set; } = 1;
        [Column("fecha_creacion")]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [Column("fecha_modificacion")]
        public DateTime? FechaModificacion { get; set; }

        // Navegación: relación con empresas
        [JsonIgnore] // Evita serializar la colección de empresas
        public ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();

    }
}
