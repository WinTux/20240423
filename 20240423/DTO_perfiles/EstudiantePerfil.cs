using _20240423.DTO;
using _20240423.Models;
using AutoMapper;
namespace _20240423.DTO_perfiles
{
    public class EstudiantePerfil : Profile
    {
        public EstudiantePerfil()
        {
            CreateMap<Estudiante,EstudianteReadDTO>(); // --------->
            CreateMap<EstudianteCreateDTO, Estudiante>();
            CreateMap<EstudianteUpdateDTO, Estudiante>();
            CreateMap<Estudiante, EstudianteUpdateDTO > ();
        }
    }
}
