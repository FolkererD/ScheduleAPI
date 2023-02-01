namespace Application.UseCases.Travails.Dtos;

public class DtoInputUpdateTravails
{
    public int Id { get; set; }
    public string Travail { get; set; }
    public decimal SalaireBrut { get; set; }
    public decimal SalaireNet { get; set; }
}