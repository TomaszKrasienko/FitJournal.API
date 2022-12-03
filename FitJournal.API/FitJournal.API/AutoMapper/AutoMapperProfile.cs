using AutoMapper;
using FitJournal.API.DTOs.Exercises;
using FitJournal.Domain.Models;
namespace FitJournal.API.AutoMapper;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ExerciseDto, Exercise>();
    }
}