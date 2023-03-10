using Application.UseCases.Prestations;
using Application.UseCases.Prestations.Dtos;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
public class PrestationsController : ControllerBase
{
    private readonly UseCaseCreatePrestations _useCaseCreatePrestations;
    private readonly UseCaseDeletePrestations _useCaseDeletePrestations;
    private readonly UseCaseFetchAllPrestations _useCaseFetchAllPrestations;
    private readonly UseCaseFetchByIdPrestations _useCaseFetchByIdPrestations;
    private readonly UseCaseFetchFilterPrestations _useCaseFetchFilterPrestations;
    private readonly UseCaseFetchNextPrestation _useCaseFetchNextPrestation;
    private readonly UseCaseFetchNextSalary _useCaseFetchNextSalary;
    private readonly UseCaseUpdatePrestations _useCaseUpdatePrestations;
    private readonly UseCaseFetchNextPrestations _useCaseFetchNextPrestations;

    public PrestationsController(UseCaseCreatePrestations useCaseCreatePrestations,
        UseCaseFetchAllPrestations useCaseFetchAllPrestations,
        UseCaseUpdatePrestations useCaseUpdatePrestations,
        UseCaseDeletePrestations useCaseDeletePrestations,
        UseCaseFetchByIdPrestations useCaseFetchByIdPrestations,
        UseCaseFetchFilterPrestations useCaseFetchFilterPrestations,
        UseCaseFetchNextPrestation useCaseFetchNextPrestation,
        UseCaseFetchNextSalary useCaseFetchNextSalary,
        UseCaseFetchNextPrestations useCaseFetchNextPrestations)
    {
        _useCaseCreatePrestations = useCaseCreatePrestations;
        _useCaseFetchAllPrestations = useCaseFetchAllPrestations;
        _useCaseUpdatePrestations = useCaseUpdatePrestations;
        _useCaseDeletePrestations = useCaseDeletePrestations;
        _useCaseFetchByIdPrestations = useCaseFetchByIdPrestations;
        _useCaseFetchFilterPrestations = useCaseFetchFilterPrestations;
        _useCaseFetchNextPrestation = useCaseFetchNextPrestation;
        _useCaseFetchNextSalary = useCaseFetchNextSalary;
        _useCaseFetchNextPrestations = useCaseFetchNextPrestations;
    }

    [HttpPost]
    [Route("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public ActionResult<DtoOutputPrestations> Create(DtoInputCreatePrestations dto)
    {        
        return Ok(_useCaseCreatePrestations.Execute(dto.Prestation));
    }

    [HttpGet]
    [Route("fetch/all")]
    public ActionResult<IEnumerable<DtoOutputPrestations>> FetchAll()
    {
        return Ok(_useCaseFetchAllPrestations.Execute());
    }


    [HttpGet]
    [Route("nextPrestations")]
    public ActionResult<IEnumerable<DtoOutputPrestations>> NextPrestations()
    {
        return Ok(_useCaseFetchNextPrestations.Execute());
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

    [HttpGet]
    [Route("nextPrestation")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<DtoOutputNextPrestation> FetchNextPrestation()
    {
        try
        {
            return _useCaseFetchNextPrestation.Execute();
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet]
    [Route("nextSalary/{jour:int}")]
    public ActionResult<DtoOutputNextSalary> NextSalary(int jour)
    {
        return Ok(_useCaseFetchNextSalary.Execute(jour));
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> Delete(int id)
    {
        return _useCaseDeletePrestations.Execute(id);
    }

    [HttpPut]
    [Route("update")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<bool> Update(DtoInputUpdatePrestations dto)
    {
        return _useCaseUpdatePrestations.Execute(dto);
    }
}