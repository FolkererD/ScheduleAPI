namespace Domain;

public class DbPrestations
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int Travail { get; set; }
    public int Horaire { get; set; }
    public decimal SalaireNet { get; set; }
}