using Application.UseCases.Prestations.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Prestations;

public class UseCaseCreatePrestations : IUseCaseWriter<DtoOutputPrestations, DtoInputPrestation>
{
    private readonly IPrestationsRepository _prestationsRepository;
    private readonly ITravailsRepository _travailsRepository;
    private readonly IHorairesRepository _horairesRepository;

    public UseCaseCreatePrestations(IPrestationsRepository prestationsRepository,
        ITravailsRepository travailsRepository,
        IHorairesRepository horairesRepository)
    {
        _prestationsRepository = prestationsRepository;
        _travailsRepository = travailsRepository;
        _horairesRepository = horairesRepository;
    }

    public DtoOutputPrestations Execute(DtoInputPrestation input)
    {
//        var mapper = Mapper.GetInstance();
//        var prestations = mapper.Map<DbPrestations>(mapper.Map<Domain.Prestations>(input));
        var prestations = new DbPrestations();
        
        prestations.Horaire = input.Horaire;        
        prestations.Date = DateTime.Parse(input.Date);
        prestations.Travail = 1;

        prestations.SalaireNet = _travailsRepository.GetById(prestations.Travail)!.SalaireNet;

        var dbPrestations = _prestationsRepository.Create(prestations);
        return Mapper.GetInstance().Map<DtoOutputPrestations>(dbPrestations);
    }
}