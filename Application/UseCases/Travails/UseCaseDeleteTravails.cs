using Application.UseCases.Travails.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Travails;

public class UseCaseDeleteTravails : IUseCaseWriter<Boolean, int>
{
    private readonly ITravailsRepository _travailsRepository;
    public UseCaseDeleteTravails(ITravailsRepository TravailsRepository)
    {
         _travailsRepository = TravailsRepository;
    }

    public Boolean Execute(int id)
    {
        var travails = _travailsRepository.GetById(id);
        return _travailsRepository.Delete(travails);
    }
}
