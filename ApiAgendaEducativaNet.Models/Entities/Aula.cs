using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Models.Entities
{
    [Table("ms_grado_academico")]
    public class Aula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_grado_academico")]
        public int IdAula { get; set; }
        [Column("nombre_grado")]
        public string NombreAula { get; set; }
        [Column("descripcion_aula")]
        public string Descripcion { get; set; }
        [Column("numero_vacante")]
        public int? NumeroVacante { get; set; }
        [Column("estado")]
        public int Estado { get; set; } = 1;


        [Column("id_anio_academico_fk")]
        public int? IdPeriodo { get; set; }

        [ForeignKey("IdPeriodo")]
        public virtual Periodo Periodo { get; set; }



        [Column("id_nivel_academico_fk")]
        public int? IdNivelAcademico { get; set; }

        [ForeignKey("IdNivelAcademico")]
        public virtual NivelAcademico NivelAcademico { get; set; }


        [Column("id_turno_fk")]
        public int? IdTurno { get; set; }

        [ForeignKey("IdTurno")]
        public virtual Turno Turno { get; set; }


        [Column("id_empresa_fk")]
        public int? IdEmpresa { get; set; }

        [ForeignKey("IdEmpresa")]
        public virtual Empresa Empresa { get; set; }

    }
}
