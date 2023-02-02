using Application.UseCases.Prestations.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Prestations;

public class UseCaseFetchNextPrestations : IUseCaseQuery<IEnumerable<DtoOutputPrestations>>
{
    private readonly IPrestationsRepository _prestationsRepository;
    private readonly IHorairesRepository _horairesRepository;

    public UseCaseFetchNextPrestations(IPrestationsRepository prestationsRepository,
        IHorairesRepository horairesRepository)
    {
        _prestationsRepository = prestationsRepository;
        _horairesRepository = horairesRepository;
    }

    public IEnumerable<DtoOutputPrestations> Execute()
    {
        var prestations = _prestationsRepository.GetNextPrestations();
        var dtoOutputPrestations = new List<DtoOutputPrestations>();

        foreach (var prestation in prestations)
        {
            dtoOutputPrestations.Add(new DtoOutputPrestations
            {
                Id = prestation.Id,
                Date = prestation.Date,
                Debut = _horairesRepository.GetById(prestation.Horaire).Debut.ToString(),
                Fin = _horairesRepository.GetById(prestation.Horaire).Fin.ToString(),
                SalaireNet = prestation.SalaireNet * _horairesRepository.GetById(prestation.Horaire).Duree,
                Duree = _horairesRepository.GetById(prestation.Horaire).Duree
            });
        }

        return dtoOutputPrestations;
    }
}