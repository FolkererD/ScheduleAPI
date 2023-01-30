using Application.UseCases.Prestations.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Prestations;

public class UseCaseFetchByIdPrestations : IUseCaseParameterizedQuery<DtoOutputPrestations, int>
{
    private readonly IPrestationsRepository _prestationsRepository;
    public UseCaseFetchByIdPrestations(IPrestationsRepository PrestationsRepository)
    {
         _prestationsRepository = PrestationsRepository;
    }

    public DtoOutputPrestations Execute(int id)
    {
        var dbprestations = _prestationsRepository.GetById(id);
        return Mapper.GetInstance().Map<DtoOutputPrestations>(dbprestations);
    }
}
