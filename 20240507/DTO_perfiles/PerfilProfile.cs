using _20240507.DTO;
using _20240507.Models;
using AutoMapper;

namespace _20240507.DTO_perfiles
{
    public class PerfilProfile : Profile
    {
        public PerfilProfile()
        {
            CreateMap<Estudiante, EstudianteReadDTO>();
            CreateMap<Perfil,PerfilReadDTO>();
            CreateMap<PerfilCreateDTO, Perfil>();
            CreateMap<EstudiantePublisherDTO, Estudiante>().ForMember(
                destino => destino.fId,
                opcion => opcion.MapFrom(fuente => fuente.Id)
            );
        }
    }
}
