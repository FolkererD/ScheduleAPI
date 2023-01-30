using Application.UseCases.Horaires;
using Application.UseCases.Horaires.Dtos;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class HorairesController : ControllerBase
{

    private readonly UseCaseCreateHoraires _useCaseCreateHoraires;
    private readonly UseCaseFetchAllHoraires _useCaseFetchAllHoraires;
    private readonly UseCaseUpdateHoraires _useCaseUpdateHoraires;
    private readonly UseCaseDeleteHoraires _useCaseDeleteHoraires;
    private readonly UseCaseFetchByIdHoraires _useCaseFetchByIdHoraires;
    private readonly UseCaseFetchFilterHoraires _UseCaseFetchFilterHoraires;

    public HorairesController(UseCaseCreateHoraires useCaseCreateHoraires,
        UseCaseFetchAllHoraires useCaseFetchAllHoraires,
        UseCaseUpdateHoraires useCaseUpdateHoraires,
        UseCaseDeleteHoraires useCaseDeleteHoraires,
        UseCaseFetchByIdHoraires useCaseFetchByIdHoraires,
        UseCaseFetchFilterHoraires UseCaseFetchFilterHoraires)
    {
        _useCaseCreateHoraires = useCaseCreateHoraires;
        _useCaseFetchAllHoraires = useCaseFetchAllHoraires;
        _useCaseUpdateHoraires = useCaseUpdateHoraires;
        _useCaseDeleteHoraires = useCaseDeleteHoraires;
        _useCaseFetchByIdHoraires = useCaseFetchByIdHoraires;
        _UseCaseFetchFilterHoraires = UseCaseFetchFilterHoraires;
    }

    [HttpPost]
    [Route("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputHoraires> Create(DtoInputCreateHoraires dto)
    {
        return Ok(_useCaseCreateHoraires.Execute(dto));
    }

/*  // SANS FILTRE 
    [HttpGet]
    [Route("fetch/all")]
    public ActionResult<IEnumerable<DtoOutputHoraires>> FetchAll()
    {
        return Ok(_useCaseFetchAllHoraires.Execute());
    }
*/

    // En ajoutant un numero dans ID, il n'affiche que cet ID là. A modifier avec d'autres filtres
    [HttpGet]
    [Route("fetch/all")]
    public ActionResult<IEnumerable<DtoOutputHoraires>> FetchAll([FromQuery] int id)
    {
        return Ok(_UseCaseFetchFilterHoraires.Execute(
            new DtoInputFilteringHoraires
            {
                 Id = id
            }));
    }

    [HttpGet]
    [Route("fetch/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputHoraires> FetchById(int id)
    {
        try
        {
            return _useCaseFetchByIdHoraires.Execute(id);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Boolean> Delete(int id)
    {
        return _useCaseDeleteHoraires.Execute(id);
    }

    [HttpPut]
    [Route("update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Boolean> Update(DtoInputUpdateHoraires dto)
    {
        return _useCaseUpdateHoraires.Execute(dto);
    }

}
