using Application.UseCases.Travails.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Travails;

public class UseCaseFetchByIdTravails : IUseCaseParameterizedQuery<DtoOutputTravails, int>
{
    private readonly ITravailsRepository _travailsRepository;
    public UseCaseFetchByIdTravails(ITravailsRepository TravailsRepository)
    {
         _travailsRepository = TravailsRepository;
    }

    public DtoOutputTravails Execute(int id)
    {
        var dbtravails = _travailsRepository.GetById(id);
        return Mapper.GetInstance().Map<DtoOutputTravails>(dbtravails);
    }
}
