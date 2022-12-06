using AutoMapper;
using FitJournal.API.AutoMapper;
using FitJournal.API.DTOs.Exercises;
using FitJournal.Domain.Models;

namespace FitJournal.Tests.Helpers;

public static class AutoMapperProvider
{
    public static Mapper GetAutoMapper()
    {
        var config = new MapperConfiguration(x =>
        {
            x.AddProfile<AutoMapperProfile>();
        });
        return new Mapper(config);
    } 
}