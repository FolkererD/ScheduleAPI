using Application.UseCases.Horaires.Dtos;
using Application.UseCases.Utils;
using Domain;

namespace Application.UseCases.Horaires;

public class UseCaseDeleteHoraires : IUseCaseWriter<Boolean, int>
{
    private readonly IHorairesRepository _horairesRepository;
    public UseCaseDeleteHoraires(IHorairesRepository HorairesRepository)
    {
         _horairesRepository = HorairesRepository;
    }

    public Boolean Execute(int id)
    {
        var horaires = _horairesRepository.GetById(id);
        return _horairesRepository.Delete(horaires);
    }
}
