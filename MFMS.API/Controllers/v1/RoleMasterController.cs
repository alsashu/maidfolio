using MFMS.API.Handler;
using MFMS.Application.Abstraction;
using MFMS.DataTransferObject;
using MFMS.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MFMS.API.Controllers.v1
{

    [Route("v1/api/[controller]")]
    [ApiController]
    public class RoleMasterController : ControllerBase
    {
        #region Private member variables
        private readonly IRoleMasterService _roleMasterService;
        #endregion

        #region Public Constructor
        public RoleMasterController(IRoleMasterService roleMasterService)
        {
            _roleMasterService = roleMasterService;
        }
        #endregion

        #region Public member methods.

        // GET: api/<RoleMasterController>
        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _roleMasterService.GetAllRoleMaster();
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

        // GET api/<RoleMasterController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _roleMasterService.GetRoleMasterById(id);
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

        // PUT api/<RoleMasterController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] DTORoleMaster model)
        {
            try
            {
                ResponseType type = ResponseType.NotFound;
                var result = _roleMasterService.UpdateRoleMaster(model);
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

        // DELETE api/<RoleMasterController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _roleMasterService.DeleteRoleMaster(id);
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
