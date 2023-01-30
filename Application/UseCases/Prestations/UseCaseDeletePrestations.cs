using Application.UseCases.Prestations.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Prestations;

public class UseCaseDeletePrestations : IUseCaseWriter<Boolean, int>
{
    private readonly IPrestationsRepository _prestationsRepository;
    public UseCaseDeletePrestations(IPrestationsRepository PrestationsRepository)
    {
         _prestationsRepository = PrestationsRepository;
    }

    public Boolean Execute(int id)
    {
        var prestations = _prestationsRepository.GetById(id);
        return _prestationsRepository.Delete(prestations);
    }
}
