using FitJournal.Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FitJournal.Infrastructure.Data;

public class FitJournalDbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<FitJournalDbContext>();
            context.Database.EnsureCreated();
            if (!context.Units.Any())
            {
                context.Units.AddRange(new List<Unit>()
                {
                    new Unit()
                    {
                        Name = "Repeat",
                        Shortcut = "reps"
                    },
                    new Unit()
                    {
                        Name = "Minutes",
                        Shortcut = "min"
                    },
                    new Unit()
                    {
                        Name = "Meters",
                        Shortcut = "m"
                    }
                });
                context.SaveChanges();
            }
            if (!context.ExercisesTypes.Any())
            {
                context.ExercisesTypes.AddRange(new List<ExerciseType>()
                {
                    new ExerciseType()
                    {
                        Name = "Upper"
                    },
                    new ExerciseType()
                    {
                        Name = "Lower"
                    },
                    new ExerciseType()
                    {
                        Name = "Cardio"
                    }
                });
                context.SaveChanges();
            }
            if (!context.TrainingsUnits.Any())
            {
                context.TrainingsUnits.AddRange(new List<TrainingUnit>()
                {
                    new TrainingUnit()
                    {    
                        Date = new DateTime(2022, 11, 20)
                    },
                    new TrainingUnit()
                    {
                        Date = new DateTime(2022, 11, 21)
                    }
                });
                context.SaveChanges();
            }

            if (!context.Exercises.Any())
            {
                context.Exercises.AddRange(new List<Exercise>()
                {
                    new Exercise()
                    {
                        Name = "Bench Press",
                        Description = "Bench press description",
                        WithWeight = true,
                        UnitId = 1
                    },
                    new Exercise()
                    {
                        Name = "Squats",
                        Description = "Squats description",
                        WithWeight = true,
                        UnitId = 1
                    },
                    new Exercise()
                    {
                        Name = "Pull ups",
                        Description = "Pull ups description",
                        WithWeight = false,
                        UnitId = 1
                    },
                    new Exercise()
                    {
                        Name = "Running",
                        Description = "Running description",
                        WithWeight = false,
                        UnitId = 3
                    },
                    new Exercise()
                    {
                        Name = "Plank",
                        Description = "Plank description",
                        WithWeight = false,
                        UnitId = 2
                    }
                });
                context.SaveChanges();
            }

            if (!context.ExercisesTypeExercises.Any())
            {
                context.ExercisesTypeExercises.AddRange(new List<ExercisesTypeExercise>()
                {
                    new ExercisesTypeExercise()
                    {
                        ExerciseId = 1,
                        ExerciseTypeId = 1
                    },
                    new ExercisesTypeExercise()
                    {
                        ExerciseId = 2,
                        ExerciseTypeId = 2
                    },
                    new ExercisesTypeExercise()
                    {
                        ExerciseId = 3,
                        ExerciseTypeId = 1
                    },
                    new ExercisesTypeExercise()
                    {
                        ExerciseId = 4,
                        ExerciseTypeId = 3
                    },
                    new ExercisesTypeExercise()
                    {
                        ExerciseId = 5,
                        ExerciseTypeId = 1
                    },
                });
                context.SaveChanges();
            }

            if (!context.ExercisesTrainingUnits.Any())
            {
                context.ExercisesTrainingUnits.AddRange(new List<ExerciseTrainingUnit>()
                {
                    new ExerciseTrainingUnit()
                    {
                        ExerciseId = 1,
                        TrainingUnitId = 1,
                        Quantity = 10,
                        Weight = 60
                    },
                    new ExerciseTrainingUnit()
                    {
                        ExerciseId = 1,
                        TrainingUnitId = 1,
                        Quantity = 10,
                        Weight = 60
                    },
                    new ExerciseTrainingUnit()
                    {
                        ExerciseId = 1,
                        TrainingUnitId = 1,
                        Quantity = 10,
                        Weight = 60
                    },
                    new ExerciseTrainingUnit()
                    {
                        ExerciseId = 1,
                        TrainingUnitId = 1,
                        Quantity = 10,
                        Weight = 60
                    },
                    new ExerciseTrainingUnit()
                    {
                        ExerciseId = 2,
                        TrainingUnitId = 1,
                        Quantity = 10,
                        Weight = 60
                    },
                    new ExerciseTrainingUnit()
                    {
                        ExerciseId = 2,
                        TrainingUnitId = 1,
                        Quantity = 10,
                        Weight = 60
                    },
                    new ExerciseTrainingUnit()
                    {
                        ExerciseId = 2,
                        TrainingUnitId = 1,
                        Quantity = 10,
                        Weight = 60
                    },
                    new ExerciseTrainingUnit()
                    {
                        ExerciseId = 2,
                        TrainingUnitId = 1,
                        Quantity = 10,
                        Weight = 60
                    },
                    
                    
                    new ExerciseTrainingUnit()
                    {
                        ExerciseId = 3,
                        TrainingUnitId = 2,
                        Quantity = 8,
                    },
                    new ExerciseTrainingUnit()
                    {
                        ExerciseId = 3,
                        TrainingUnitId = 2,
                        Quantity = 8,
                    },
                    new ExerciseTrainingUnit()
                    {
                        ExerciseId = 3,
                        TrainingUnitId = 2,
                        Quantity = 8,
                    },
                    new ExerciseTrainingUnit()
                    {
                        ExerciseId = 3,
                        TrainingUnitId = 2,
                        Quantity = 8,
                    },
                    new ExerciseTrainingUnit()
                    {
                        ExerciseId = 3,
                        TrainingUnitId = 2,
                        Quantity = 8,
                    },
                    new ExerciseTrainingUnit()
                    {
                        ExerciseId = 3,
                        TrainingUnitId = 2,
                        Quantity = 8,
                    },
                    new ExerciseTrainingUnit()
                    {
                        ExerciseId = 3,
                        TrainingUnitId = 2,
                        Quantity = 8,
                    },
                    new ExerciseTrainingUnit()
                    {
                        ExerciseId = 3,
                        TrainingUnitId = 2,
                        Quantity = 8,
                    },
                });
                context.SaveChanges();
            }
        }
    }
}