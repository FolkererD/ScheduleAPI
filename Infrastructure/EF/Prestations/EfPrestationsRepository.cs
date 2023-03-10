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
        return context.Prestations.OrderBy(prestations => prestations.Date).ToList();
    }
    
    public IEnumerable<DbPrestations> GetNextPrestations()
    {
        using var context = _dbContextProvider.NewContext();
        
        var prestations = context.Prestations
            .Where(prestations => prestations.Date >= DateTime.Today)
            .OrderBy(prestations => prestations.Date)
            .ToList();

        return prestations;
    }

    public DbPrestations GetById(int id)
    {
        using var context = _dbContextProvider.NewContext();
        var prestations = context.Prestations.FirstOrDefault(prestations => prestations.Id == id);
        if (prestations == null) throw new KeyNotFoundException($"Prestations with {id} has not been found");
        return prestations;
    }

    public DbPrestations GetNextPrestation()
    {
        using var context = _dbContextProvider.NewContext();

        var prestations = context.Prestations
            .Where(prestations => prestations.Date >= DateTime.Today)
            .OrderBy(prestations => prestations.Date)
            .FirstOrDefault();

        return prestations;
    }

    public decimal CalculSalaire(DbPrestations db)
    {
        return db.SalaireNet * _dbContextProvider.NewContext().Horaires.FirstOrDefault(horaires => horaires.Id == db.Horaire)!.Duree;
    }
    
    public IEnumerable<DbPrestations> GetNextSalary(int jour)
    {
        using var context = _dbContextProvider.NewContext();

        var prestations = context.Prestations
            .OrderBy(prestations => prestations.Date)
            .ToList();

        var premierJour = 0;
        var dernierJour = 0;
        var mois = 0;

        if (DateTime.Today.Day <= 13)
        {
            if (jour <= 13)
            {
                premierJour = 16;
                dernierJour = 31;
                mois = -1;
            }
            else
            {
                premierJour = 1;
                dernierJour = 15;
                mois = 0;
            }
        }
        else
        {
            if (jour <= 13)
            {
                premierJour = 16;
                if(DateTime.Today.Month == 1 || DateTime.Today.Month == 3 || DateTime.Today.Month == 5 || DateTime.Today.Month == 7 || DateTime.Today.Month == 8 || DateTime.Today.Month == 10 || DateTime.Today.Month == 12)
                    dernierJour = 31;
                else if(DateTime.Today.Month == 4 || DateTime.Today.Month == 6 || DateTime.Today.Month == 9 || DateTime.Today.Month == 11)
                    dernierJour = 30;
                else if(DateTime.Today.Month == 2)
                    dernierJour = 28;
                mois = 0;
            }
            else
            {
                premierJour = 1;
                dernierJour = 15;
                mois = 0;
            }
        }


        prestations = prestations.Where(prestations =>
            prestations.Date >= new DateTime(DateTime.Today.Year, DateTime.Today.Month + mois, premierJour)
            &&
            prestations.Date <= new DateTime(DateTime.Today.Year, DateTime.Today.Month + mois, dernierJour)).ToList();

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