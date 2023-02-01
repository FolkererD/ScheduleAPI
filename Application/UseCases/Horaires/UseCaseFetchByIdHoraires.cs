using Application.UseCases.Horaires.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Horaires;

public class UseCaseFetchByIdHoraires : IUseCaseParameterizedQuery<DtoOutputHoraires, int>
{
    private readonly IHorairesRepository _horairesRepository;

    public UseCaseFetchByIdHoraires(IHorairesRepository HorairesRepository)
    {
        _horairesRepository = HorairesRepository;
    }

    public DtoOutputHoraires Execute(int id)
    {
        var dbhoraires = _horairesRepository.GetById(id);
        return Mapper.GetInstance().Map<DtoOutputHoraires>(dbhoraires);
    }
}