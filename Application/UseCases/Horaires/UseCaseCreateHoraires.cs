using Application.UseCases.Horaires.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Horaires;

public class UseCaseCreateHoraires : IUseCaseWriter<DtoOutputHoraires, DtoInputCreateHoraires>
{
    private readonly IHorairesRepository _horairesRepository;

    public UseCaseCreateHoraires(IHorairesRepository HorairesRepository)
    {
        _horairesRepository = HorairesRepository;
    }

    public DtoOutputHoraires Execute(DtoInputCreateHoraires input)
    {
        var mapper = Mapper.GetInstance();
        var horaires = mapper.Map<DbHoraires>(mapper.Map<Domain.Horaires>(input));
        var dbHoraires = _horairesRepository.Create(horaires);
        return Mapper.GetInstance().Map<DtoOutputHoraires>(dbHoraires);
    }
}