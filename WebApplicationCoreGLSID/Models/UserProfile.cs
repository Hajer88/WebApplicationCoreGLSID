using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApplicationCoreGLSID.Models.DTO;

namespace WebApplicationCoreGLSID.Models
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Categorie, CategorieDTO>();
            CreateMap<CategorieDTO, Categorie>();
        }
    }
}
