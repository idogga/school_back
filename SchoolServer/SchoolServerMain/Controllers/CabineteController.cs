namespace SchoolServerMain.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using School.BL.Place;
    using School.Database;
    using School.Dto;

    [Route("api/[controller]")]
    public class CabineteController : CrudController<CabineteDto, Cabinete>
    {
        public CabineteController(CabineteMapper mapper,
            CabinetService crudService)
            : base(mapper, crudService)
        {
        }
    }
}