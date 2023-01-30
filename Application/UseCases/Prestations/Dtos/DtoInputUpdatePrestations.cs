using System.ComponentModel.DataAnnotations;
using Domain;
namespace Application.UseCases.Prestations.Dtos;

public class DtoInputUpdatePrestations
{
    public int Id { get;  set; }
    public DateTime Date { get;  set; }
    public int Travail { get;  set; }
    public int Horaire { get;  set; }
    public decimal SalaireNet { get;  set; }
    public string Notes { get;  set; }
}
