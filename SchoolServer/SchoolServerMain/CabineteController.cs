using Microsoft.AspNetCore.Mvc;

namespace SchoolServerMain
{
    using System.Threading.Tasks;

    using School.AbstractService;
    using School.BL;
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