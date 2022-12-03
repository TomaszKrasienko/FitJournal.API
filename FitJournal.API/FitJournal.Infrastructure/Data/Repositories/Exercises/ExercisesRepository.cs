using FitJournal.Domain.Base;
using FitJournal.Domain.Models;
using FitJournal.Domain.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace FitJournal.Infrastructure.Data.Repositories.Exercises;

public class ExercisesRepository : IExercisesRepository
{
    private readonly FitJournalDbContext _context;
    public ExercisesRepository(FitJournalDbContext context)
    {
        _context = context;
    }
    public async Task<List<Exercise>> GetAllAsync(PaginationParameters parameters)
    {
        return await _context
            .Exercises
            .OrderBy(x =>x.Id)
            .Skip((parameters.PageNumber - 1) * parameters.PageSize )
            .Take(parameters.PageSize)
            .ToListAsync();
    }

    public async Task<Exercise> AddAsync(Exercise entity)
    {
        await _context.Exercises.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}