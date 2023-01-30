namespace Domain;
public interface IHorairesRepository
{
    IEnumerable<DbHoraires> FetchAll();
    DbHoraires GetById(int id);
    DbHoraires Create(DbHoraires horaires);
    bool Delete(DbHoraires horaires);
    bool Update(DbHoraires horaires);
}
