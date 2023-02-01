using Application.UseCases.Horaires.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Horaires;

public class UseCaseUpdateHoraires : IUseCaseWriter<bool, DtoInputUpdateHoraires>
{
    private readonly IHorairesRepository _horairesRepository;

    public UseCaseUpdateHoraires(IHorairesRepository HorairesRepository)
    {
        _horairesRepository = HorairesRepository;
    }

    public bool Execute(DtoInputUpdateHoraires input)
    {
        var mapper = Mapper.GetInstance();
        var horaires = mapper.Map<DbHoraires>(input);
        return _horairesRepository.Update(horaires);
    }
}