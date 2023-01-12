using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace EmployeeManagmentSysytemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork unitOfWork;

        public DepartmentController(
            IUnitOfWork UnitOfWork,
            IMapper mapper)
        {
            unitOfWork = UnitOfWork;
            _mapper = mapper;
        }


        [Route("[action]")]
        [HttpPost]
        public IActionResult Add(DTO.Department dtoModel)
        {
            var entitiy = _mapper.Map<Entities.Department>(dtoModel);
            entitiy.IsDeleted = false;
            unitOfWork.Deparmtnet.Insert(entitiy);
            unitOfWork.Complete();
            unitOfWork.Clear();
            return Ok(entitiy);
        }

    }
}
