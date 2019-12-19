using AutoMapper;
using MongoDB.Dtos.ClubDto;
using MongoDB.Dtos.EvenementDto;
using MongoDB.Dtos.EcoleDto;
using MongoDB.Dtos.UniversiteDto;
using MongoDB.Database.Models;

namespace MongoDB.MappingProfiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Evenement, EvenementAjout>().ReverseMap();
            CreateMap<Club, ClubSignup>().ReverseMap();
            CreateMap<Club, ClubSignin>().ReverseMap(); 
            CreateMap<Ecole, EcoleAjout>().ReverseMap(); 
            CreateMap<Universite, UniversiteAjout>().ReverseMap(); 
            CreateMap<Universite, UniversiteModif>().ReverseMap();
             
        }
    }
}