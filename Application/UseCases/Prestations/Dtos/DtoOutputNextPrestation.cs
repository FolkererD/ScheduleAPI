namespace Application.UseCases.Prestations.Dtos;

public class DtoOutputNextPrestation
{
    public DateTime Date { get; set; }
    public TimeSpan Debut { get; set; }
    public TimeSpan Fin { get; set; }
    public decimal Duree { get; set; }
    public decimal SalaireNet { get; set; }
}