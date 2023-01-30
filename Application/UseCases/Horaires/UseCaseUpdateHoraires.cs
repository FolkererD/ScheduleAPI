using Application.UseCases.Horaires.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Horaires;

public class UseCaseUpdateHoraires : IUseCaseWriter<Boolean, DtoInputUpdateHoraires>
{
    private readonly IHorairesRepository _horairesRepository;
    public UseCaseUpdateHoraires(IHorairesRepository HorairesRepository)
    {
         _horairesRepository = HorairesRepository;
    }

    public Boolean Execute(DtoInputUpdateHoraires input)
    {
        var mapper = Mapper.GetInstance();
        var horaires = mapper.Map<DbHoraires>(input);
        return _horairesRepository.Update(horaires);
    }
}
