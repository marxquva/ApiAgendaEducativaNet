using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Models.Entities
{
    [Table("ms_nivel_academico")]
    public class NivelAcademico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_nivel_academico")]
        public int IdNivelAcademico { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("descripcion")]
        public string Descripcion { get; set; }
        [Column("estado")]
        public int Estado { get; set; } = 1;

        // Llave foránea explícita
        [Column("id_empresa")]
        [ForeignKey(nameof(Empresa))]  // Indica que esta columna es la FK
        public int? IdEmpresa { get; set; }
    }
}
