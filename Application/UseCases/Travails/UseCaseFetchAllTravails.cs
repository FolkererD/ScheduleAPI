using Application.UseCases.Travails.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Travails;

public class UseCaseFetchAllTravails : IUseCaseQuery<IEnumerable<DtoOutputTravails>>
{
    private readonly ITravailsRepository _travailsRepository;
    public UseCaseFetchAllTravails(ITravailsRepository TravailsRepository)
    {
         _travailsRepository = TravailsRepository;
    }

    public IEnumerable<DtoOutputTravails> Execute()
    {
        var travails = _travailsRepository.FetchAll();
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputTravails>>(travails);
    }
}
