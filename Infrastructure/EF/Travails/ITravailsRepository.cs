namespace Domain;

public interface ITravailsRepository
{
    IEnumerable<DbTravails> FetchAll();
    DbTravails GetById(int id);
    DbTravails Create(DbTravails travails);
    bool Delete(DbTravails travails);
    bool Update(DbTravails travails);
}