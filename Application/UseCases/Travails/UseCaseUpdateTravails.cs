using Application.UseCases.Travails.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Travails;

public class UseCaseUpdateTravails : IUseCaseWriter<bool, DtoInputUpdateTravails>
{
    private readonly ITravailsRepository _travailsRepository;

    public UseCaseUpdateTravails(ITravailsRepository TravailsRepository)
    {
        _travailsRepository = TravailsRepository;
    }

    public bool Execute(DtoInputUpdateTravails input)
    {
        var mapper = Mapper.GetInstance();
        var travails = mapper.Map<DbTravails>(input);
        return _travailsRepository.Update(travails);
    }
}