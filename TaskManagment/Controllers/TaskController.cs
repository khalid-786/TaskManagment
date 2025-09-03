using AutoMapper;
using Core.Entities;
using Domain;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace TaskManagment.Controllers
{
    public class TaskController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        public TaskController(IUnitOfWork unitOfWork , IMapper mapper) {
         _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var row = await _unitOfWork.TaskManageService.GetByIdAsync(id);
                return Ok(_mapper.Map<TaskDto>(row));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Filter")]
        public async Task<IActionResult> GetAllAsync([FromBody] TaskFilterDto model)
        {
            try
            {
                Expression<Func<TaskManage, bool>> criteria = t => t.IsDeleted == false && t.Title.Contains(model.Title) && t.Status == model.Status;
                var (tasksList, totalCount) =  await _unitOfWork.TaskManageService.FindAllAsync(criteria ,model.Take ,model.Skip);
                var tasks = _mapper.Map<List<TaskDto>>(tasksList);
                return Ok(new
                {
                    tasks ,
                    totalCount 
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost("Create")]
        public async Task<ActionResult> PostAsync([FromBody] TaskDto model)
        {
            try
            {
                var newRow = _mapper.Map<TaskManage>(model);
                var done = await _unitOfWork.TaskManageService.AddAsync(newRow);
                if (done > 0)
                    return Ok(new { Code = 200, Description = "Saved Success" });
                else
                    return Ok(new { Code = 409, Description = "Saved Fail" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult> PutAsync([FromBody] TaskDto model, int Id)
        {
            try
            {
                TaskManage getRow = await _unitOfWork.TaskManageService.GetByIdAsync(Id);
                if (getRow == null)
                {
                    return Ok(new { Code = 200, Description = "Task Not Found" });
                }
                else
                {
                    var newRow = _mapper.Map<TaskDto, TaskManage>(model, getRow);
                    int done = await _unitOfWork.TaskManageService.Update(newRow);
                    if (done > 0)
                        return Ok(new { Code = 200, Description = "Updatet Success" });
                    else
                        return Ok(new { Code = 408, Description = "Updated Fail" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteAsync(int Id)
        {
            try
            {
                TaskManage task = await _unitOfWork.TaskManageService.GetByIdAsync(Id);
                if (task == null)
                {
                    return NotFound(new { Code = 404, Description = "Task Not Found" });
                }
                else
                {
                    task.IsDeleted = true;
                    int done = await _unitOfWork.TaskManageService.Update(task);
                    if (done > 0)
                        return Ok(new { Code = 200, Description = "Deleted Success" });
                    else
                        return Ok(new { Code = 410 , Description = "Deleted Fail" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
