namespace SchoolServerMain.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;

    using School.Abstract;
    using School.BL.Place;
    using School.Database;
    using School.Dto;
    using School.Dto.Cabinetes;

    [Route("api/[controller]")]
    public class CabineteController : CrudController<CreateCabineteDto, CabineteDto, Cabinete>
    {
        /// <summary>
        /// Контруктор.
        /// </summary>
        public CabineteController(IMapper mapper,
            CabinetService crudService)
            : base(mapper, crudService)
        {
        }
    }
}