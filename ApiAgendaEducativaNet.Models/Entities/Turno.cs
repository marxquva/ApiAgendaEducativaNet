using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Models.Entities
{
    [Table("ms_turno")]
    public class Turno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_turno")]
        public int IdTurno { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("descripcion")]
        public string Descripcion { get; set; }
        [Column("hora_inicio")]
        public DateTime? HoraInicio { get; set; }
        [Column("hora_final")]
        public DateTime? HoraFinal { get; set; }
        [Column("estado")]
        public int Estado { get; set; } = 1;

        [Column("id_empresa_fk")]
        public int? IdEmpresa { get; set; }

        [ForeignKey("IdEmpresa")]
        public virtual Empresa Empresa { get; set; }
    }
}
