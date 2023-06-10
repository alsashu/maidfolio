using MFMS.API.Handler;
using MFMS.Application.Abstraction;
using MFMS.DataTransferObject;
using MFMS.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MFMS.API.Controllers.v1
{

    [Route("v1/api/[controller]")]
    [ApiController]
    public class WorkingHourController : ControllerBase
    {
        #region Private member variables
        private readonly IWorkingHourService _workingHourService;
        #endregion

        #region Public Constructor
        public WorkingHourController(IWorkingHourService workingHourService)
        {
            _workingHourService = workingHourService;
        }
        #endregion

        #region Public member methods.

        // GET: api/<WorkingHourController>
        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _workingHourService.GetAllWorkingHour();
                if (response == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, response));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<WorkingHourController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _workingHourService.GetWorkingHourById(id);
                if (response == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, response));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<WorkingHourController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] DTOWorkingHour model)
        {
            try
            {
                ResponseType type = ResponseType.NotFound;
                var result = _workingHourService.UpdateWorkingHour(model);
                if (result != null)
                {
                    type = ResponseType.Success;
                }
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<WorkingHourController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _workingHourService.DeleteWorkingHour(id);
                if (response == false)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, response));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        #endregion
    }

}
