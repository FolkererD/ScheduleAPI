using Application.UseCases.Horaires.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Horaires;

public class UseCaseFetchAllHoraires : IUseCaseQuery<IEnumerable<DtoOutputHoraires>>
{
    private readonly IHorairesRepository _horairesRepository;

    public UseCaseFetchAllHoraires(IHorairesRepository HorairesRepository)
    {
        _horairesRepository = HorairesRepository;
    }

    public IEnumerable<DtoOutputHoraires> Execute()
    {
        var horaires = _horairesRepository.FetchAll();
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputHoraires>>(horaires);
    }
}