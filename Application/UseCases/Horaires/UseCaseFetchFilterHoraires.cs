using Application.UseCases.Horaires.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Horaires;

public class UseCaseFetchFilterHoraires : IUseCaseQuery<IEnumerable<DtoOutputHoraires>>
{
    private readonly IHorairesRepository _horairesRepository;
    public UseCaseFetchFilterHoraires(IHorairesRepository HorairesRepository)
    {
         _horairesRepository = HorairesRepository;
    }

    public IEnumerable<DtoOutputHoraires> Execute(DtoInputFilteringHoraires param)
    {
        var horaires = _horairesRepository.FetchAll();
        horaires = (param.Id != 0
            ? horaires.Where(pS => pS.Id == param.Id)
            : horaires);
        return Mapper.GetInstance().Map<IEnumerable<DtoOutputHoraires>>(horaires);
    }

    public IEnumerable<DtoOutputHoraires> Execute()
    {
        throw new NotImplementedException();
    }
}
