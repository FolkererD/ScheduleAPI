using Application.UseCases.Prestations.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Prestations;

public class UseCaseFetchAllPrestations : IUseCaseQuery<IEnumerable<DtoOutputPrestations>>
{
    private readonly IPrestationsRepository _prestationsRepository;
    public UseCaseFetchAllPrestations(IPrestationsRepository PrestationsRepository)
    {
         _prestationsRepository = PrestationsRepository;
    }

    public IEnumerable<DtoOutputPrestations> Execute()
    {
        var prestations = _prestationsRepository.FetchAll();
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputPrestations>>(prestations);
    }
}
