using Application.UseCases.Prestations.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Prestations;

public class UseCaseUpdatePrestations : IUseCaseWriter<Boolean, DtoInputUpdatePrestations>
{
    private readonly IPrestationsRepository _prestationsRepository;
    public UseCaseUpdatePrestations(IPrestationsRepository PrestationsRepository)
    {
         _prestationsRepository = PrestationsRepository;
    }

    public Boolean Execute(DtoInputUpdatePrestations input)
    {
        var mapper = Mapper.GetInstance();
        var prestations = mapper.Map<DbPrestations>(input);
        return _prestationsRepository.Update(prestations);
    }
}
