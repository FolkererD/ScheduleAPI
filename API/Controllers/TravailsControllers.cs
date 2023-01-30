using Application.UseCases.Travails;
using Application.UseCases.Travails.Dtos;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class TravailsController : ControllerBase
{

    private readonly UseCaseCreateTravails _useCaseCreateTravails;
    private readonly UseCaseFetchAllTravails _useCaseFetchAllTravails;
    private readonly UseCaseUpdateTravails _useCaseUpdateTravails;
    private readonly UseCaseDeleteTravails _useCaseDeleteTravails;
    private readonly UseCaseFetchByIdTravails _useCaseFetchByIdTravails;
    private readonly UseCaseFetchFilterTravails _UseCaseFetchFilterTravails;

    public TravailsController(UseCaseCreateTravails useCaseCreateTravails,
        UseCaseFetchAllTravails useCaseFetchAllTravails,
        UseCaseUpdateTravails useCaseUpdateTravails,
        UseCaseDeleteTravails useCaseDeleteTravails,
        UseCaseFetchByIdTravails useCaseFetchByIdTravails,
        UseCaseFetchFilterTravails UseCaseFetchFilterTravails)
    {
        _useCaseCreateTravails = useCaseCreateTravails;
        _useCaseFetchAllTravails = useCaseFetchAllTravails;
        _useCaseUpdateTravails = useCaseUpdateTravails;
        _useCaseDeleteTravails = useCaseDeleteTravails;
        _useCaseFetchByIdTravails = useCaseFetchByIdTravails;
        _UseCaseFetchFilterTravails = UseCaseFetchFilterTravails;
    }

    [HttpPost]
    [Route("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputTravails> Create(DtoInputCreateTravails dto)
    {
        return Ok(_useCaseCreateTravails.Execute(dto));
    }

/*  // SANS FILTRE 
    [HttpGet]
    [Route("fetch/all")]
    public ActionResult<IEnumerable<DtoOutputTravails>> FetchAll()
    {
        return Ok(_useCaseFetchAllTravails.Execute());
    }
*/

    // En ajoutant un numero dans ID, il n'affiche que cet ID là. A modifier avec d'autres filtres
    [HttpGet]
    [Route("fetch/all")]
    public ActionResult<IEnumerable<DtoOutputTravails>> FetchAll([FromQuery] int id)
    {
        return Ok(_UseCaseFetchFilterTravails.Execute(
            new DtoInputFilteringTravails
            {
                 Id = id
            }));
    }

    [HttpGet]
    [Route("fetch/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputTravails> FetchById(int id)
    {
        try
        {
            return _useCaseFetchByIdTravails.Execute(id);
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
        return _useCaseDeleteTravails.Execute(id);
    }

    [HttpPut]
    [Route("update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Boolean> Update(DtoInputUpdateTravails dto)
    {
        return _useCaseUpdateTravails.Execute(dto);
    }

}
