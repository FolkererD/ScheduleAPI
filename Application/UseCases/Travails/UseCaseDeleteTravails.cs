using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Travails;

public class UseCaseDeleteTravails : IUseCaseWriter<bool, int>
{
    private readonly ITravailsRepository _travailsRepository;

    public UseCaseDeleteTravails(ITravailsRepository TravailsRepository)
    {
        _travailsRepository = TravailsRepository;
    }

    public bool Execute(int id)
    {
        var travails = _travailsRepository.GetById(id);
        return _travailsRepository.Delete(travails);
    }
}