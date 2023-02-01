using Application.UseCases.Prestations.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Prestations;

public class UseCaseFetchNextSalary : IUseCaseParameterizedQuery<DtoOutputNextSalary, int>
{
    private readonly IHorairesRepository _horairesRepository;
    private readonly IPrestationsRepository _prestationsRepository;

    public UseCaseFetchNextSalary(IPrestationsRepository prestationsRepository,
        IHorairesRepository horairesRepository)
    {
        _prestationsRepository = prestationsRepository;
        _horairesRepository = horairesRepository;
    }

    public DtoOutputNextSalary Execute(int jour)
    {
        var prestations = _prestationsRepository.GetNextSalary(jour);
        var nextSalary = new DtoOutputNextSalary();

        nextSalary.Date = jour <= 13
            ? new DateTime(DateTime.Today.Year, DateTime.Today.Month, 13)
            : new DateTime(DateTime.Today.Year, DateTime.Today.Month, 28);

        if (nextSalary.Date.Day == 13 && DateTime.Today.Day >= 13)
            nextSalary.Date = nextSalary.Date.AddMonths(1);

        nextSalary.SalaireNet =
            Math.Round(
                prestations.Sum(prestations =>
                    prestations.SalaireNet * _horairesRepository.GetById(prestations.Horaire).Duree), 2);


        return Mapper.GetInstance().Map<DtoOutputNextSalary>(nextSalary);
    }
}