using Application.UseCases.Prestations.Dtos;
using Domain;

namespace Application.UseCases.Prestations;

public class UseCaseFetchNextPrestation : DtoOutputNextPrestation
{
    private readonly IHorairesRepository _horairesRepository;
    private readonly IPrestationsRepository _prestationsRepository;

    public UseCaseFetchNextPrestation(IPrestationsRepository prestationsRepository,
        IHorairesRepository horairesRepository)
    {
        _prestationsRepository = prestationsRepository;
        _horairesRepository = horairesRepository;
    }

    public DtoOutputNextPrestation Execute()
    {
        var nextPrestation = new DtoOutputNextPrestation();

        var dbPrestations = _prestationsRepository.GetNextPrestation();
        var dbHoraires = _horairesRepository.GetById(dbPrestations.Horaire);

        nextPrestation.Date = dbPrestations.Date;

        nextPrestation.Duree = dbHoraires.Duree;
        nextPrestation.Debut = dbHoraires.Debut;
        nextPrestation.Fin = dbHoraires.Fin;

        nextPrestation.SalaireNet = dbPrestations.SalaireNet;

        return Mapper.GetInstance().Map<DtoOutputNextPrestation>(nextPrestation);
    }
}