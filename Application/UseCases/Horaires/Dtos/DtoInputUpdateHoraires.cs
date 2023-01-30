using System.ComponentModel.DataAnnotations;
using Domain;
namespace Application.UseCases.Horaires.Dtos;

public class DtoInputUpdateHoraires
{
    public int Id { get;  set; }
    public int Ordre { get;  set; }
    public int Travail { get;  set; }
    public TimeSpan Debut { get;  set; }
    public TimeSpan Fin { get;  set; }
    public decimal Duree { get;  set; }
}
