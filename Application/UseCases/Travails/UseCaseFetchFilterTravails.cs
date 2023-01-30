using Application.UseCases.Travails.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Travails;

public class UseCaseFetchFilterTravails : IUseCaseQuery<IEnumerable<DtoOutputTravails>>
{
    private readonly ITravailsRepository _travailsRepository;
    public UseCaseFetchFilterTravails(ITravailsRepository TravailsRepository)
    {
         _travailsRepository = TravailsRepository;
    }

    public IEnumerable<DtoOutputTravails> Execute(DtoInputFilteringTravails param)
    {
        var travails = _travailsRepository.FetchAll();
        travails = (param.Id != 0
            ? travails.Where(pS => pS.Id == param.Id)
            : travails);
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputTravails>>(travails);
    }

    public IEnumerable<DtoOutputTravails> Execute()
    {
        throw new NotImplementedException();
    }
}
