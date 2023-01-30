using Application.UseCases.Prestations;
using Application.UseCases.Prestations.Dtos;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class PrestationsController : ControllerBase
{

    private readonly UseCaseCreatePrestations _useCaseCreatePrestations;
    private readonly UseCaseFetchAllPrestations _useCaseFetchAllPrestations;
    private readonly UseCaseUpdatePrestations _useCaseUpdatePrestations;
    private readonly UseCaseDeletePrestations _useCaseDeletePrestations;
    private readonly UseCaseFetchByIdPrestations _useCaseFetchByIdPrestations;
    private readonly UseCaseFetchFilterPrestations _UseCaseFetchFilterPrestations;

    public PrestationsController(UseCaseCreatePrestations useCaseCreatePrestations,
        UseCaseFetchAllPrestations useCaseFetchAllPrestations,
        UseCaseUpdatePrestations useCaseUpdatePrestations,
        UseCaseDeletePrestations useCaseDeletePrestations,
        UseCaseFetchByIdPrestations useCaseFetchByIdPrestations,
        UseCaseFetchFilterPrestations UseCaseFetchFilterPrestations)
    {
        _useCaseCreatePrestations = useCaseCreatePrestations;
        _useCaseFetchAllPrestations = useCaseFetchAllPrestations;
        _useCaseUpdatePrestations = useCaseUpdatePrestations;
        _useCaseDeletePrestations = useCaseDeletePrestations;
        _useCaseFetchByIdPrestations = useCaseFetchByIdPrestations;
        _UseCaseFetchFilterPrestations = UseCaseFetchFilterPrestations;
    }

    [HttpPost]
    [Route("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputPrestations> Create(DtoInputCreatePrestations dto)
    {
        return Ok(_useCaseCreatePrestations.Execute(dto));
    }

/*  // SANS FILTRE 
    [HttpGet]
    [Route("fetch/all")]
    public ActionResult<IEnumerable<DtoOutputPrestations>> FetchAll()
    {
        return Ok(_useCaseFetchAllPrestations.Execute());
    }
*/

    // En ajoutant un numero dans ID, il n'affiche que cet ID là. A modifier avec d'autres filtres
    [HttpGet]
    [Route("fetch/all")]
    public ActionResult<IEnumerable<DtoOutputPrestations>> FetchAll([FromQuery] int id)
    {
        return Ok(_UseCaseFetchFilterPrestations.Execute(
            new DtoInputFilteringPrestations
            {
                 Id = id
            }));
    }

    [HttpGet]
    [Route("fetch/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputPrestations> FetchById(int id)
    {
        try
        {
            return _useCaseFetchByIdPrestations.Execute(id);
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
        return _useCaseDeletePrestations.Execute(id);
    }

    [HttpPut]
    [Route("update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Boolean> Update(DtoInputUpdatePrestations dto)
    {
        return _useCaseUpdatePrestations.Execute(dto);
    }

}
