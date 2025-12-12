using ApiAgendaEducativaNet.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAgendaEducativaNet.Data.Repositories
{
    public interface INivelAcademicoRepository
    {
        Task<IEnumerable<NivelAcademico>> ObtenerNivelesAcademicosAsync();
        Task<NivelAcademico> ObtenerNivelAcademicoByIdAsync(int id);
        Task<NivelAcademico> CrearNivelAcademicoAsync(NivelAcademico nivel);
        Task<NivelAcademico> ActualizarNivelAcademicoAsync(NivelAcademico nivel);
        Task<bool> EliminarNivelAcademicoAsync(int id);
    }
}
