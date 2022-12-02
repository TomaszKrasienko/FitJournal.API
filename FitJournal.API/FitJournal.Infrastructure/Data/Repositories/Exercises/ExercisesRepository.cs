using FitJournal.Domain.Base;
using FitJournal.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FitJournal.Infrastructure.Data.Repositories.Exercises;

public class ExercisesRepository : IExercisesRepository
{
    private readonly FitJournalDbContext _context;
    public ExercisesRepository(FitJournalDbContext context)
    {
        _context = context;
    }
    public async Task<List<Exercise>> GetAllAsync()
    {
        return await _context.Exercises.ToListAsync();
    }
}