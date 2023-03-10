namespace Domain;

public interface IPrestationsRepository
{
    IEnumerable<DbPrestations> FetchAll();
    IEnumerable<DbPrestations> GetNextPrestations();
    DbPrestations GetById(int id);

    DbPrestations GetNextPrestation();
    IEnumerable<DbPrestations> GetNextSalary(int jour);
    DbPrestations Create(DbPrestations prestations);
    bool Delete(DbPrestations prestations);
    bool Update(DbPrestations prestations);
}