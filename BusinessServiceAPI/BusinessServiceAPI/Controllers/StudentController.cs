using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessServiceDomain;
using BusinessServiceData.Repositories;
using BusinessService.Services;
using System.Net.Mime;

namespace BusinessServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("Get/{id}")]
        [ResponseCache(Duration =60,Location =ResponseCacheLocation.Any)]
        public async Task<ActionResult<StudentViewModel>> Get(int id)
        {
                     
            var student = await studentService.GetAsync(id);
            try
            {
                if (student == null)
            {
                return NotFound();
            }
            }
            catch (Exception ex)
            {
                ErrorLog.Errorlogs("Get Acttion", ex.Message);
            }
            return Ok(student);
        }

        [HttpGet("GetAll")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult<IEnumerable<StudentViewModel>>> GetAll()
        {
            var students = await studentService.GetAllAsync();

            return Ok(students);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("Insert")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult<int>> Insert(StudentViewModel student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await studentService.InsertAsync(student);

                return Ok(result); ;
            }
            catch (Exception ex)
            {
                ErrorLog.Errorlogs("Insert", ex.Message);
            }
            return Ok();
        }

        [HttpPost("Update")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult<int>> Update(StudentViewModel student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await studentService.UpdateAsync(student);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ErrorLog.Errorlogs("Update", ex.Message);
            }
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult<int>> Delete(int id)
        {
            try
            {
                var student = await studentService.GetAsync(id);

                if (student == null)
                {
                    return NotFound();
                }

                var result = await studentService.DeleteAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                ErrorLog.Errorlogs("Delete", ex.Message);
            }
            return Ok();
        }


    }
}
