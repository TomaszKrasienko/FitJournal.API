using FitJournal.Domain.Base;
using FitJournal.Domain.Models;
using FitJournal.Domain.Wrappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
    public async Task<Exercise> EditAsync(int id, Exercise exercise)
    {
        exercise.Id = id;
        EntityEntry entityEntry = _context.Entry<Exercise>(exercise);
        entityEntry.State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return exercise;
    }
    public async Task<int> DeleteAsync(int id)
    {
        var entity = await _context.Exercises.FirstOrDefaultAsync(x => x.Id == id);
        EntityEntry entityEntry = _context.Entry(entity);
        entityEntry.State = EntityState.Deleted;
        await _context.SaveChangesAsync();
        return id;
    }
}