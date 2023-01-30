using Domain;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
public class EfHorairesRepository : IHorairesRepository
{

    private readonly DBContextProvider _dbContextProvider;

    public EfHorairesRepository(DBContextProvider contextProvider)
    {
        _dbContextProvider = contextProvider;
    }

    public IEnumerable<DbHoraires> FetchAll()
    {
        using var context = _dbContextProvider.NewContext();
        return context.Horaires.ToList();
    }

    public DbHoraires GetById(int id)
    {
        using var context = _dbContextProvider.NewContext();
        var horaires = context.Horaires.FirstOrDefault(horaires => horaires.Id == id);
        if (horaires == null) throw new KeyNotFoundException($"Horaires with {id} has not been found");
        return horaires;
    }

    public DbHoraires Create(DbHoraires horaires)
    {
        using var context = _dbContextProvider.NewContext();
        try
        {
            context.Horaires.Add(horaires);
            context.SaveChanges();
            return horaires;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return null;
        }
    }

    public bool Delete(DbHoraires horaires)
    {
        using var context = _dbContextProvider.NewContext();
        try
        {
            context.Horaires.Remove(horaires);
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }

    public bool Update(DbHoraires horaires)
    {
        using var context = _dbContextProvider.NewContext();
        try
        {
            context.Horaires.Update(horaires);
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }

}
