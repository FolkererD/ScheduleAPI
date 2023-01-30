using Domain;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
public class EfTravailsRepository : ITravailsRepository
{

    private readonly DBContextProvider _dbContextProvider;

    public EfTravailsRepository(DBContextProvider contextProvider)
    {
        _dbContextProvider = contextProvider;
    }

    public IEnumerable<DbTravails> FetchAll()
    {
        using var context = _dbContextProvider.NewContext();
        return context.Travails.ToList();
    }

    public DbTravails GetById(int id)
    {
        using var context = _dbContextProvider.NewContext();
        var travails = context.Travails.FirstOrDefault(travails => travails.Id == id);
        if (travails == null) throw new KeyNotFoundException($"Travails with {id} has not been found");
        return travails;
    }

    public DbTravails Create(DbTravails travails)
    {
        using var context = _dbContextProvider.NewContext();
        try
        {
            context.Travails.Add(travails);
            context.SaveChanges();
            return travails;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return null;
        }
    }

    public bool Delete(DbTravails travails)
    {
        using var context = _dbContextProvider.NewContext();
        try
        {
            context.Travails.Remove(travails);
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }

    public bool Update(DbTravails travails)
    {
        using var context = _dbContextProvider.NewContext();
        try
        {
            context.Travails.Update(travails);
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }

}
