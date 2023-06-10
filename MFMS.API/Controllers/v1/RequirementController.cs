using MFMS.API.Handler;
using MFMS.Application.Abstraction;
using MFMS.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

namespace MFMS.API.Controllers.v1
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class RequirementController : ControllerBase
    {
        #region Private member variables
        private readonly IRequirementService _requirementService;
        #endregion

        #region Public Constructor
        public RequirementController(IRequirementService requirementService)
        {
            _requirementService = requirementService;
        }
        #endregion

        #region Public member methods.

        // GET: api/<RequirementController>
        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _requirementService.GetAllRequirement();
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

        // GET api/<RequirementController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _requirementService.GetRequirementById(id);
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

        // PUT api/<RequirementController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] DTORequirement model)
        {
            try
            {
                ResponseType type = ResponseType.NotFound;
                var result = _requirementService.UpdateRequirement(model);
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

        // DELETE api/<RequirementController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _requirementService.DeleteRequirement(id);
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
