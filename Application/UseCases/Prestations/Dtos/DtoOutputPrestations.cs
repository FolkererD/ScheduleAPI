namespace Application.UseCases.Prestations.Dtos;

public class DtoOutputPrestations
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Debut { get; set; }
    public string Fin { get; set; }
    public decimal SalaireNet { get; set; }
    public decimal Duree { get; set; }
}