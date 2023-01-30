using Application.UseCases.Prestations.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Prestations;

public class UseCaseCreatePrestations : IUseCaseWriter<DtoOutputPrestations, DtoInputCreatePrestations>
{
    private readonly IPrestationsRepository _prestationsRepository;
    public UseCaseCreatePrestations(IPrestationsRepository PrestationsRepository)
    {
         _prestationsRepository = PrestationsRepository;
    }

    public DtoOutputPrestations Execute(DtoInputCreatePrestations input)
    {
        var mapper = Mapper.GetInstance();
        var prestations = mapper.Map<DbPrestations>(mapper.Map<Domain.Prestations>(input));
        var dbPrestations = _prestationsRepository.Create(prestations);
        return Mapper.GetInstance().Map<DtoOutputPrestations>(dbPrestations);
    }
}
