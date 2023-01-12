using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace EmployeeManagmentSysytemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork unitOfWork;

        public CountryController(
            IUnitOfWork UnitOfWork,
            IMapper mapper)
        {
            unitOfWork = UnitOfWork;
            _mapper = mapper;
        }


        [Route("[action]")]
        [HttpPost]
        public IActionResult Add(DTO.Country dtoModel)
        {
            var entitiy = _mapper.Map<Entities.Country>(dtoModel);
            entitiy.IsDeleted = false;
            unitOfWork.Country.Insert(entitiy);
            unitOfWork.Complete();
            unitOfWork.Clear();
            return Ok(entitiy);
        }

    }
}
