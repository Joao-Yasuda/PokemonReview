using AutoMapper;
using Pokemon_Review_App.Models;
using PokemonReviewApp.Dto;

namespace PokemonReviewApp.Helper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Pokemon, PokemonDto>();
    }
}