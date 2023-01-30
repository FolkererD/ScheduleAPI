using Domain;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
public class EfPrestationsRepository : IPrestationsRepository
{

    private readonly DBContextProvider _dbContextProvider;

    public EfPrestationsRepository(DBContextProvider contextProvider)
    {
        _dbContextProvider = contextProvider;
    }

    public IEnumerable<DbPrestations> FetchAll()
    {
        using var context = _dbContextProvider.NewContext();
        return context.Prestations.ToList();
    }

    public DbPrestations GetById(int id)
    {
        using var context = _dbContextProvider.NewContext();
        var prestations = context.Prestations.FirstOrDefault(prestations => prestations.Id == id);
        if (prestations == null) throw new KeyNotFoundException($"Prestations with {id} has not been found");
        return prestations;
    }

    public DbPrestations Create(DbPrestations prestations)
    {
        using var context = _dbContextProvider.NewContext();
        try
        {
            context.Prestations.Add(prestations);
            context.SaveChanges();
            return prestations;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return null;
        }
    }

    public bool Delete(DbPrestations prestations)
    {
        using var context = _dbContextProvider.NewContext();
        try
        {
            context.Prestations.Remove(prestations);
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }

    public bool Update(DbPrestations prestations)
    {
        using var context = _dbContextProvider.NewContext();
        try
        {
            context.Prestations.Update(prestations);
            return context.SaveChanges() == 1;
        }
        catch (DbUpdateConcurrencyException e)
        {
            return false;
        }
    }

}
