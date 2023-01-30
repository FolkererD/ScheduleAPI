using Application.UseCases.Travails.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Travails;

public class UseCaseCreateTravails : IUseCaseWriter<DtoOutputTravails, DtoInputCreateTravails>
{
    private readonly ITravailsRepository _travailsRepository;
    public UseCaseCreateTravails(ITravailsRepository TravailsRepository)
    {
         _travailsRepository = TravailsRepository;
    }

    public DtoOutputTravails Execute(DtoInputCreateTravails input)
    {
        var mapper = Mapper.GetInstance();
        var travails = mapper.Map<DbTravails>(mapper.Map<Domain.Travails>(input));
        var dbTravails = _travailsRepository.Create(travails);
        return Mapper.GetInstance().Map<DtoOutputTravails>(dbTravails);
    }
}
