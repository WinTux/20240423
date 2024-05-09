using _20240423.DTO;

namespace _20240423.ComunicacionSync.Http
{
    public interface ICampusHistorialCliente
    {
        Task ComunicarseConCampus(EstudianteReadDTO est);
    }
}
