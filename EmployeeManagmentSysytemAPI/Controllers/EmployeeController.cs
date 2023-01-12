using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace EmployeeManagmentSysytemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork unitOfWork;

        public EmployeeController(
            IUnitOfWork UnitOfWork,
            IMapper mapper)
        {
            unitOfWork = UnitOfWork;
            _mapper = mapper;
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult List()
        {
            var entitiy = unitOfWork.Employee.GetAll();

            var dtoModel = _mapper.Map<List<DTO.Employee>>(entitiy);
            var countries = unitOfWork.Country.GetAll();
            var departments = unitOfWork.Deparmtnet.GetAll();
            foreach (var item in dtoModel)
            {
                item.DepartmentName = departments.Where(d => d.ID == item.DepartmentId).FirstOrDefault().Name;
                item.CountryName = countries.Where(d => d.ID == item.DepartmentId).FirstOrDefault().Name;
            }

            return Ok(dtoModel.Where(s => s.IsDeleted != true).ToList());
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Add(DTO.Employee dtoModel)
        {
            var entitiy = _mapper.Map<Entities.Employee>(dtoModel);
            entitiy.IsDeleted = false;
            unitOfWork.Employee.Insert(entitiy);
            unitOfWork.Complete();
            unitOfWork.Clear();
            return Ok(entitiy);
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetEmployee(int id)
        {
            var entity = unitOfWork.Employee.Get(id);
            var dtoModel2 = _mapper.Map<Entities.Employee>(entity);
            unitOfWork.Clear();
            unitOfWork.Complete();
            unitOfWork.Clear();
            return Ok(dtoModel2);
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Edit(DTO.Employee dtoModel)
        {
            var entity = unitOfWork.Employee.Get(dtoModel.ID);
            unitOfWork.Clear();
            if (entity != null)
            {
                entity = _mapper.Map<Entities.Employee>(dtoModel);
                unitOfWork.Employee.Update(entity);
                unitOfWork.Complete();
                unitOfWork.Clear();
                return Ok(dtoModel);
            }
            else
            {
                return BadRequest(new
                {
                    ErrorMessage = "ID is not valid"
                }
                );
            }
        }

        [Route("[action]")]
        [HttpGet]
        public IActionResult delete(int id)
        {
            var entity = unitOfWork.Employee.Get(id);
            unitOfWork.Clear();
            if (entity != null)
            {
                entity.IsDeleted = true;
                unitOfWork.Employee.Update(entity);
                unitOfWork.Complete();
                unitOfWork.Clear();
                return Ok();
            }
            else
            {
                return BadRequest
                (
                    new
                    {
                        ErrorMessage = "ID is not valid"
                    }
                );
            }
        }
    }

}
