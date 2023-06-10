using MFMS.API.Handler;
using MFMS.Application.Abstraction;
using MFMS.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

namespace MFMS.API.Controllers.v1
{
    public class ClientSubscriptionDetailController : ControllerBase
    {
        #region Private member variables
        private readonly IClientSubscriptionDetailService _clientSubscriptionDetailService;
        #endregion

        #region Public Constructor
        public ClientSubscriptionDetailController(IClientSubscriptionDetailService clientSubscriptionDetailService)
        {
            _clientSubscriptionDetailService = clientSubscriptionDetailService;
        }
        #endregion

        #region Public member methods.

        // GET: api/<ClientSubscriptionDetailController>
        [HttpGet]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _clientSubscriptionDetailService.GetAllClientSubscriptionDetail();
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

        // GET api/<ClientSubscriptionDetailController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _clientSubscriptionDetailService.GetClientSubscriptionDetailById(id);
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

        // PUT api/<ClientSubscriptionDetailController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] DTOClientSubscriptionDetail model)
        {
            try
            {
                ResponseType type = ResponseType.NotFound;
                var result = _clientSubscriptionDetailService.UpdateClientSubscriptionDetail(model);
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

        // DELETE api/<ClientSubscriptionDetailController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                var response = _clientSubscriptionDetailService.DeleteClientSubscriptionDetail(id);
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
