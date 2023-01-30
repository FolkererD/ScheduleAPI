using Application.UseCases.Prestations.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Prestations;

public class UseCaseFetchFilterPrestations : IUseCaseQuery<IEnumerable<DtoOutputPrestations>>
{
    private readonly IPrestationsRepository _prestationsRepository;
    public UseCaseFetchFilterPrestations(IPrestationsRepository PrestationsRepository)
    {
         _prestationsRepository = PrestationsRepository;
    }

    public IEnumerable<DtoOutputPrestations> Execute(DtoInputFilteringPrestations param)
    {
        var prestations = _prestationsRepository.FetchAll();
        prestations = (param.Id != 0
            ? prestations.Where(pS => pS.Id == param.Id)
            : prestations);
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputPrestations>>(prestations);
    }

    public IEnumerable<DtoOutputPrestations> Execute()
    {
        throw new NotImplementedException();
    }
}
