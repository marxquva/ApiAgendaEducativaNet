using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Models.Entities
{
    [Table("sis_anio_academico")]
    public class Periodo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_anio_academico")]
        public int IdPeriodo { get; set; }
        [Column("codigo")]
        public string Codigo { get; set; }
        [Column("nombre")]
        public string Nombre { get; set; }
        [Column("descripcion")]
        public string Descripcion { get; set; }
        [Column("fecha_inicio")]
        public DateTime? FechaInicio { get; set; }
        [Column("fecha_final")]
        public DateTime? FechaFinal { get; set; }
        [Column("estado")]
        public int Estado { get; set; } = 1;
    }
}
