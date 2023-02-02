namespace Application.UseCases.Prestations.Dtos;

public class DtoInputCreatePrestations
{
    public DtoInputPrestation Prestation { get; set; }
}

public class DtoInputPrestation
{
    public string Date { get; set; }
    public int Travail { get; set; }
    public int Horaire { get; set; }
    public decimal SalaireNet { get; set; }
}