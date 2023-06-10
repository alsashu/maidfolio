using MFMS.API.Handler;
using MFMS.Application.Abstraction;
using MFMS.DataTransferObject;
using MFMS.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MFMS.API.Controllers.v1
{

    [Route("v1/api/[controller]")]
    [ApiController]
    public class SubscriptionTypeController : ControllerBase
    {
        #region Private member variables
        private readonly ISubscriptionTypeService _subscriptionTypeService;
        #endregion

        #region Public Constructor
        public SubscriptionTypeController(ISubscriptionTypeService subscriptionTypeService)
        {
            _subscriptionTypeService = subscriptionTypeService;
        }
        #endregion

        #region Public member methods.

        // GET: api/<SubscriptionTypeController>
        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _subscriptionTypeService.GetAllSubscriptionType();
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

        // GET api/<SubscriptionTypeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _subscriptionTypeService.GetSubscriptionTypeById(id);
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

        // PUT api/<SubscriptionTypeController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] DTOSubscriptionType model)
        {
            try
            {
                ResponseType type = ResponseType.NotFound;
                var result = _subscriptionTypeService.UpdateSubscriptionType(model);
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

        // DELETE api/<SubscriptionTypeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _subscriptionTypeService.DeleteSubscriptionType(id);
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
