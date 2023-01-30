using System.ComponentModel.DataAnnotations;
namespace Application.UseCases.Prestations.Dtos;

public class DtoInputCreatePrestations
{
    public DateTime Date { get;  set; }
    public int Travail { get;  set; }
    public int Horaire { get;  set; }
    public decimal SalaireNet { get;  set; }
    public string Notes { get;  set; }
}
