using Application.UseCases.Travails.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Travails;

public class UseCaseUpdateTravails : IUseCaseWriter<Boolean, DtoInputUpdateTravails>
{
    private readonly ITravailsRepository _travailsRepository;
    public UseCaseUpdateTravails(ITravailsRepository TravailsRepository)
    {
         _travailsRepository = TravailsRepository;
    }

    public Boolean Execute(DtoInputUpdateTravails input)
    {
        var mapper = Mapper.GetInstance();
        var travails = mapper.Map<DbTravails>(input);
        return _travailsRepository.Update(travails);
    }
}
